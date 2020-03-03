using Xunit;
using GitHubExplorer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubExplorer.Services.Tests
{
    public class GitHubReposServiceTests
    {
        [Fact()]
        public void GetRepoTest()
        {
            var service = new GitHubReposService();

            var repoId = "Andrevmatias/GitHubExplorer";

            var repo = service.GetRepo(repoId);

            Assert.Equal("GitHubExplorer", repo.Name);

            var nullRepo = service.GetRepo("NONEXISTENTID_____________I_HOPE");

            Assert.Null(nullRepo);
        }

        [Fact()]
        public void GetReposPageTest()
        {
            var service = new GitHubReposService();

            var repos = service.GetUserReposPage("GitHubExplorer", 1);

            Assert.NotEmpty(repos.Items);
        }

        [Fact()]
        public void GetUserReposPageTest()
        {
            var service = new GitHubReposService();

            var repos = service.GetUserReposPage("Andrevmatias", 1);

            Assert.NotEmpty(repos.Items);
        }
    }
}