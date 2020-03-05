using GitHubExplorer.Models;
using GitHubExplorer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Tests.MockServices
{
    class MockFavReposService : IFavReposService
    {
        private const int _ITENS_PER_PAGE = 1;

        private IList<GitRepoListItem> _repos = new List<GitRepoListItem>
        {
            new GitRepoListItem
            {
                Id = 1,
                AuthorName = "Author1",
                Description = "Description1",
                Name = "Name1",
                StarCount = 1
            }
        };

        public Task<Page<GitRepoListItem>> GetPage(int page = 1)
        {
            var items = _repos;

            var total = items.Count();

            var pageItems = items.Skip(_ITENS_PER_PAGE * (page - 1))
                .Take(_ITENS_PER_PAGE)
                .ToList();

            return Task.FromResult(
                new Page<GitRepoListItem>(pageItems, page, _ITENS_PER_PAGE, total)
            );
        }

        public Task<bool> Add(long repoId)
        {
            if (_repos.Any(e => e.Id == repoId))
                return Task.FromResult(false);

            _repos.Add(new GitRepoListItem
            {
                AuthorName = "Author" + repoId,
                Description = "Description" + repoId,
                Id = repoId,
                Name = "Name" + repoId,
                StarCount = 0
            });

            return Task.FromResult(true);
        }

        public Task<bool> Remove(long repoId)
        {
            var repo = _repos.SingleOrDefault(e => e.Id == repoId);
            if (repo == null)
                return Task.FromResult(false);

            _repos.Remove(repo);

            return Task.FromResult(true);
        }
    }
}
