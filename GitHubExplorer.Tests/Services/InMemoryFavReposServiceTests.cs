using Xunit;
using GitHubExplorer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using GitHubExplorer.Tests.MockServices;
using System.Threading.Tasks;

namespace GitHubExplorer.Services.Tests
{
    public class InMemoryFavReposServiceTests
    {
        [Fact()]
        public void InMemoryFavReposServiceTest()
        {
            GetService();

            Assert.True(true);
        }

        [Fact()]
        public async Task AddTest()
        {
            var service = GetService();

            var result = await service.Add(2);
            Assert.True(result);

            var resultFalse = await service.Add(2);
            Assert.False(resultFalse);
        }

        [Fact()]
        public async Task GetPageTest()
        {
            var service = GetService();

            var result = await service.GetPage();
            Assert.Equal(1, result.Number);

            await Assert.ThrowsAsync<ArgumentException>(async () => await service.GetPage(0));
        }

        [Fact()]
        public async Task RemoveTest()
        {
            var service = GetService();

            var resultFalse = await service.Remove(0);
            Assert.False(resultFalse);

            await service.Add(10);

            var result = await service.Remove(10);
            Assert.True(result);
        }

        private InMemoryFavReposService GetService()
        {
            return new InMemoryFavReposService("test_user", new MockGitReposService());
        }
    }
}