using GitHubExplorer.Models;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Services
{
    public class GitHubReposService : IGitReposService
    {
        private static ProductHeaderValue _productInformation = new ProductHeaderValue("Andrevmatias-GitHubExplorer");

        public async Task<GitRepo> GetRepo(long id)
        {
            var client = new GitHubClient(_productInformation);
            try
            {
                var repo = await client.Repository.Get(id);
                return ConvertRepo(repo);
            } 
            catch (Octokit.NotFoundException)
            {
                return null;
            }
        }

        public async Task<Page<GitRepoListItem>> GetReposPage(string filter, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<Page<GitRepoListItem>> GetUserReposPage(long userId, int page)
        {
            throw new NotImplementedException();
        }

        private GitRepo ConvertRepo(Repository repo)
        {
            if (repo == null)
                return null;

            return new GitRepo
            {
                Author = ConvertUser(repo.Owner),
                CreationDate = repo.CreatedAt.DateTime,
                Description = repo.Description,
                Id = repo.Id,
                MainProgrammingLanguage = repo.Language,
                Name = repo.Name,
                OpenIssuesCount = repo.OpenIssuesCount,
                StarCount = repo.StargazersCount
            };
        }

        private GitUser ConvertUser(User user)
        {
            if (user == null)
                return null;

            return new GitUser
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
