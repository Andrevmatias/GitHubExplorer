using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubExplorer.Models;
using GitHubExplorer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitHubExplorer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavReposController : ControllerBase
    {
        private readonly IFavReposService _favReposService;
        private readonly IGitReposService _gitReposService;

        public FavReposController(IFavReposService favReposService, 
            IGitReposService gitReposService)
        {
            _favReposService = favReposService;
            _gitReposService = gitReposService;
        }

        /// <summary>
        /// Retorna uma página de repositórios favoritos
        /// </summary>
        /// <returns>Página de repositórios favoritos</returns>
        [HttpGet]
        public async Task<ActionResult<Page<GitRepoListItem>>> Get(int page = 1)
        {
            if (page <= 0)
                return BadRequest("A página deve ser maior que 0.");

            var idsPage = await _favReposService.GetPage(page);

            var repos = await _gitReposService.GetRepos(idsPage.Items);

            return new Page<GitRepoListItem>(repos, page, idsPage.ItemsPerPage, idsPage.TotalItems);
        }

        /// <summary>
        /// Adiciona um repositório aos favoritos
        /// </summary>
        /// <param name="repoId">ID do repositório</param>
        [HttpPost("{repoId}")]
        public async Task<ActionResult> Post(long repoId)
        {
            var result = await _favReposService.Add(repoId);

            if (result)
                return Ok();
            else
                return Conflict("Repositório já é favorito.");
        }

        /// <summary>
        /// Retira um repositório dos favoritos
        /// </summary>
        /// <param name="repoId">ID do repositório</param>
        [HttpDelete("{repoId}")]
        public async Task<ActionResult> Delete(long repoId)
        {
            var result = await _favReposService.Remove(repoId);

            if (result)
                return Ok();
            else
                return NotFound("Repositório não é favorito.");
        }
    }
}
