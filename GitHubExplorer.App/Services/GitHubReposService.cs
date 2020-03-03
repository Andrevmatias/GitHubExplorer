using GitHubExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Services
{
    public class GitHubReposService : IGitReposService
    {
        public GitRepo GetRepo(string id)
        {
            throw new NotImplementedException();
        }

        public Page<GitRepoListItem> GetReposPage(string filter, int page)
        {
            throw new NotImplementedException();
        }

        public Page<GitRepoListItem> GetUserReposPage(string userId, int page)
        {
            throw new NotImplementedException();
        }
    }
}
