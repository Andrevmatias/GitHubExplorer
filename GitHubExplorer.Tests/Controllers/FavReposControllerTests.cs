using Xunit;
using GitHubExplorer.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitHubExplorer.Tests.MockServices;

namespace GitHubExplorer.Controllers.Tests
{
    public class FavReposControllerTests
    {
        [Fact()]
        public void FavReposControllerTest()
        {
            GetController();

            Assert.True(true);
        }

        [Fact()]
        public async Task GetTest()
        {
            var controller = GetController();

            var favRepos = (await controller.Get()).Value;

            Assert.Equal(1, favRepos.Number);
            Assert.Equal(1, favRepos.Items.Count);

            var invalidResponse = await controller.Get(0);
            Assert.IsType<BadRequestObjectResult>(invalidResponse.Result);
        }

        [Fact()]
        public void PostTest()
        {
            var controller = GetController();
        }

        [Fact()]
        public void DeleteTest()
        {
            var controller = GetController();
        }

        private FavReposController GetController()
        {
            return new FavReposController(new MockFavReposService());
        }
    }
}