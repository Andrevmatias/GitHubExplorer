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
    public class GitReposController : ControllerBase
    {
        private readonly ILogger<GitReposController> _logger;
        private readonly IGitReposService _gitReposService;

        public GitReposController(ILogger<GitReposController> logger, 
            IGitReposService gitReposService)
        {
            _logger = logger;
            _gitReposService = gitReposService;
        }

        [HttpGet]
        public IEnumerable<GitRepoListItem> Get(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
