using GitHubExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Services
{
    public class InMemoryFavReposService : IFavReposService
    {
        private const int _RESULTS_PER_PAGE = 15;

        private static readonly IDictionary<string, ISet<long>> _favs = new Dictionary<string, ISet<long>>();

        private ISet<long> _userFavs;

        /// <param name="userId">Código do usuário que está registrando favoritos</param>
        public InMemoryFavReposService(string userId)
        {
            SetupUserFavs(userId);
        }

        public Task<bool> Add(long repoId)
        {
            return Task.FromResult(_userFavs.Add(repoId));
        }

        public Task<Page<long>> GetPage(int page = 1)
        {
            if (page <= 0)
                throw new ArgumentException(nameof(page));

            var reposIds = _userFavs
                .Skip((page - 1) * _RESULTS_PER_PAGE)
                .Take(_RESULTS_PER_PAGE)
                .ToList();

            return Task.FromResult(new Page<long>(reposIds, page, _RESULTS_PER_PAGE, _userFavs.Count));
        }

        public Task<bool> Remove(long repoId)
        {
            return Task.FromResult(_userFavs.Remove(repoId));
        }

        private void SetupUserFavs(string userId)
        {
            if (!_favs.ContainsKey(userId))
                _favs.Add(userId, new HashSet<long>());

            _userFavs = _favs[userId];
        }
    }
}