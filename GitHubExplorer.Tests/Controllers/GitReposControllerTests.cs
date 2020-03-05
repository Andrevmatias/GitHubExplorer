using Xunit;
using GitHubExplorer.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using GitHubExplorer.Tests.MockServices;
using Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GitHubExplorer.Controllers.Tests
{
    public class GitReposControllerTests
    {
        private static GitReposController GetController()
        {
            return new GitReposController(new MockGitReposService());
        }

        [Fact()]
        public void GitReposControllerTest()
        {
            GetController();
            Assert.True(true);
        }

        [Fact()]
        public async Task SearchTest()
        {
            var controller = GetController();

            var pageResponse = await controller.Search("1");

            var reposPage = pageResponse.Value;
            Assert.Equal(1, reposPage.Number);
            Assert.Equal(1, reposPage.Items.Count);

            var repo = reposPage.Items[0];
            Assert.Equal(1, repo.Id);

            var repo3Response = await controller.Search("3");
            Assert.IsType<NoContentResult>(repo3Response.Result);

            var page2Response = await controller.Search("1", 2);
            Assert.IsType<NoContentResult>(page2Response.Result);

            var page0Response = await controller.Search("1", 0);
            Assert.IsType<BadRequestObjectResult>(page0Response.Result);

            var nullSearchResponse = await controller.Search(null);
            Assert.IsType<BadRequestObjectResult>(nullSearchResponse.Result);
        }

        [Fact()]
        public async Task SearchByUserTest()
        {
            var controller = GetController();

            var pageResponse = await controller.SearchByUser("2");

            var reposPage = pageResponse.Value;
            Assert.Equal(1, reposPage.Number);
            Assert.Equal(1, reposPage.Items.Count);

            var repo = reposPage.Items[0];
            Assert.Equal(2, repo.Id);

            var user3Response = await controller.SearchByUser("3");
            Assert.IsType<NoContentResult>(user3Response.Result);

            var page2Response = await controller.SearchByUser("1", 2);
            Assert.IsType<NoContentResult>(page2Response.Result);

            var page0Response = await controller.SearchByUser("1", 0);
            Assert.IsType<BadRequestObjectResult>(page0Response.Result);
        }

        [Fact()]
        public async Task GetTest()
        {
            var controller = GetController();

            var repoResponse = await controller.Get(2);
            var repo = repoResponse.Value;
            Assert.Equal(2, repo.Id);

            var repo3Response = await controller.Get(3);
            Assert.IsType<NotFoundResult>(repo3Response.Result);
        }
    }
}