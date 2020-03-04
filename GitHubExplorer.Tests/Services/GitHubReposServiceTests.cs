﻿using Xunit;
using GitHubExplorer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Services.Tests
{
    public class GitHubReposServiceTests
    {
        [Fact()]
        public async Task GetRepoTest()
        {
            var service = new GitHubReposService();

            var repoId = 243658391;

            var repo = await service.GetRepo(repoId);

            Assert.Equal("GitHubExplorer", repo.Name);

            var nullRepo = await service.GetRepo(1243123412341234123);

            Assert.Null(nullRepo);
        }

        [Fact()]
        public async Task GetReposPageTest()
        {
            var service = new GitHubReposService();

            var repos = await service.GetReposPage("GitHubExplorer", 1);

            Assert.NotEmpty(repos.Items);
        }

        [Fact()]
        public async Task GetUserReposPageTest()
        {
            var service = new GitHubReposService();

            var userId = 1480319;

            var repos = await service.GetUserReposPage(userId, 1);

            Assert.NotEmpty(repos.Items);
            Assert.Equal("Andrevmatias", repos.Items[0].AuthorName);
        }
    }
}