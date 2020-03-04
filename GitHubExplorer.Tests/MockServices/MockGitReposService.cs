using GitHubExplorer.Models;
using GitHubExplorer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Tests.MockServices
{
    class MockGitReposService : IGitReposService
    {
        private const int _ITENS_PER_PAGE = 1;

        private static IList<GitUser> _gitUsers = new List<GitUser>
        {
            new GitUser
            {
                Id = 1,
                Name = "Author1"
            },
            new GitUser
            {
                Id = 2,
                Name = "Author2"
            }
        };

        private static IList<GitRepo> _repos = new List<GitRepo>
        {
            new GitRepo
            {
                Id = 1,
                Author = _gitUsers[0],
                CreationDate = new DateTime(2001, 01, 01),
                Description = "Description1",
                MainProgrammingLanguage = "MainLanguage1",
                Name = "Name1",
                OpenIssuesCount = 1,
                StarCount = 1
            },
            new GitRepo
            {
                Id = 2,
                Author = _gitUsers[1],
                CreationDate = new DateTime(2002, 02, 02),
                Description = "Description2",
                MainProgrammingLanguage = "MainLanguage2",
                Name = "Name2",
                OpenIssuesCount = 2,
                StarCount = 2
            }
        };

        public Task<GitRepo> GetRepo(long id)
        {
            return Task.FromResult(_repos.SingleOrDefault(e => e.Id == id));
        }

        public Task<Page<GitRepoListItem>> GetReposPage(string filter, int page)
        {
            var items = _repos
                .Where(e => e.Name.Contains(filter, StringComparison.InvariantCultureIgnoreCase));

            var total = items.Count();

            var pageItems = items.Skip(_ITENS_PER_PAGE * (page - 1))
                .Take(_ITENS_PER_PAGE)
                .Select(ConvertToListItem)
                .ToList();

            return Task.FromResult(
                new Page<GitRepoListItem>(pageItems, page, _ITENS_PER_PAGE, total)
            );
        }

        public Task<Page<GitRepoListItem>> GetUserReposPage(long userId, int page)
        {
            var items = _repos
                .Where(e => e.Author.Id == userId);

            var total = items.Count();

            var pageItems = items.Skip(_ITENS_PER_PAGE * (page - 1))
                .Take(_ITENS_PER_PAGE)
                .Select(ConvertToListItem)
                .ToList();

            return Task.FromResult(
                new Page<GitRepoListItem>(pageItems, page, _ITENS_PER_PAGE, total)
            );
        }

        private GitRepoListItem ConvertToListItem(GitRepo repo)
        {
            if (repo == null)
                return null;

            return new GitRepoListItem
            {
                AuthorName = repo.Author.Name,
                Id = repo.Id,
                Name = repo.Name,
                Description = repo.Description,
                StarCount = repo.StarCount
            };
        }
    }
}
