using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubExplorer.Models;
using GitHubExplorer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GitHubExplorer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubReposController : ControllerBase
    {
        private readonly ILogger<GitHubReposController> _logger;
        private readonly IGitHubReposService _gitReposService;

        public GitHubReposController(ILogger<GitHubReposController> logger, 
            IGitHubReposService gitReposService)
        {
            _logger = logger;
            _gitReposService = gitReposService;
        }

        [HttpGet]
        public Page<GitHubRepoListItem> GetList(string filter, int page = 1)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public GitHubRepo Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
