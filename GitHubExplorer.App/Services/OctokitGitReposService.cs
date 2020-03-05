using GitHubExplorer.Models;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Services
{
    public class OctokitGitReposService : IGitReposService
    {
        private const int _RESULTS_PER_PAGE = 15;

        private static ProductHeaderValue _productInformation = new ProductHeaderValue("Andrevmatias-GitHubExplorer");
        private GitHubClient _client;

        public OctokitGitReposService()
        {
            _client = new GitHubClient(_productInformation);
        }

        public async Task<GitRepo> GetRepo(long id)
        {
            var repo = await GetGitHubRepo(id);
            return ConvertRepo(repo);
        }

        public async Task<IList<GitRepoListItem>> GetRepos(IEnumerable<long> ids)
        {
            var repos = await Task.WhenAll(ids.Select(async id => await GetGitHubRepo(id)));
            return repos
                .Where(e => e != null)
                .Select(ConvertRepoListItem)
                .ToList();
        }

        public async Task<Page<GitRepoListItem>> GetReposPage(string filter, int page)
        {
            if (string.IsNullOrEmpty(filter))
                throw new ArgumentNullException(nameof(filter));

            if (page <= 0)
                throw new ArgumentException(nameof(page));

            var searchResponse = await _client.Search.SearchRepo(GetSearchRequestParams(filter, page));
            var repos = searchResponse.Items.Select(ConvertRepoListItem).ToList();

            return new Page<GitRepoListItem>(repos, page, _RESULTS_PER_PAGE, searchResponse.TotalCount);
        }

        public async Task<Page<GitRepoListItem>> GetUserReposPage(string userId, int page)
        {
            if (page <= 0)
                throw new ArgumentException(nameof(page));

            var repos = await _client.Repository.GetAllForUser(userId, GetApiOptions(page));
            var reposListItems = repos.Select(ConvertRepoListItem).ToList();
            var userTotalPublicRepos = (await _client.User.Get(userId)).PublicRepos;

            return new Page<GitRepoListItem>(reposListItems, page, _RESULTS_PER_PAGE, userTotalPublicRepos);
        }

        private async Task<Repository> GetGitHubRepo(long id)
        {
            try
            {
                return await _client.Repository.Get(id);
            }
            catch (Octokit.NotFoundException)
            {
                return null;
            }
        }

        private ApiOptions GetApiOptions(int page)
        {
            return new ApiOptions
            {
                PageCount = 1,
                PageSize = _RESULTS_PER_PAGE,
                StartPage = page
            };
        }

        private static SearchRepositoriesRequest GetSearchRequestParams(string filter, int page)
        {
            var searchParams = new SearchRepositoriesRequest(filter);

            searchParams.Page = page;
            searchParams.PerPage = _RESULTS_PER_PAGE;

            return searchParams;
        }

        private GitRepo ConvertRepo(Repository repo)
        {
            if (repo == null)
                return null;

            return new GitRepo
            {
                Author = ConvertUser(repo.Owner),
                CreationDate = repo.CreatedAt.LocalDateTime,
                Description = repo.Description,
                Id = repo.Id,
                MainProgrammingLanguage = repo.Language,
                Name = repo.Name,
                OpenIssuesCount = repo.OpenIssuesCount,
                StarCount = repo.StargazersCount
            };
        }

        private GitRepoListItem ConvertRepoListItem(Repository repo)
        {
            if (repo == null)
                return null;

            return new GitRepoListItem
            {
                AuthorName = repo.Owner?.Name ?? repo.Owner?.Login,
                Description = repo.Description,
                Id = repo.Id,
                Name = repo.Name,
                StarCount = repo.StargazersCount
            };
        }

        private GitUser ConvertUser(User user)
        {
            if (user == null)
                return null;

            return new GitUser
            {
                Id = user.Login,
                Name = user.Name ?? user.Login
            };
        }
    }
}
