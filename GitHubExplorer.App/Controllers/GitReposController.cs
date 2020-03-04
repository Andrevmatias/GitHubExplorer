﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubExplorer.Models;
using GitHubExplorer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GitHubExplorer.Controllers
{
    /// <summary>
    /// Controller responsável pelas informações de repositórios
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GitReposController : ControllerBase
    {
        private readonly IGitReposService _gitReposService;

        public GitReposController(IGitReposService gitReposService)
        {
            _gitReposService = gitReposService;
        }

        /// <summary>
        /// Busca por repositórios
        /// </summary>
        /// <param name="filter">Filtro a ser usado</param>
        /// <param name="page">Página a ser retornada</param>
        /// <returns>Página de reposiórios resultados da pesquisa</returns>
        [HttpGet("search")]
        public async Task<ActionResult<Page<GitRepoListItem>>> Search(string filter, int page = 1)
        {
            if (string.IsNullOrEmpty(filter))
                return BadRequest("O filtro não pode ser uma string vazia ou nulo.");

            if (page <= 0)
                return BadRequest("A página deve ser maior que 0.");

            var pageResult = await _gitReposService.GetReposPage(filter, page);

            if (pageResult.Items.Count == 0)
                return NoContent();

            return pageResult;
        }

        /// <summary>
        /// Busca por repositórios de um usuário
        /// </summary>
        /// <param name="userId">ID do usuário autor dos repositórios</param>
        /// <param name="page">Página a ser retornada</param>
        /// <returns>Página de reposiórios de um usuário</returns>
        [HttpGet("search-by-user")]
        public async Task<ActionResult<Page<GitRepoListItem>>> SearchByUser(string userId, int page = 1)
        {
            if (page <= 0)
                return BadRequest("A página deve ser maior que 0.");

            var pageResult = await _gitReposService.GetUserReposPage(userId, page);

            if (pageResult.Items.Count == 0)
                return NoContent();

            return pageResult;
        }

        /// <summary>
        /// Retorna informações sobre um repositório
        /// </summary>
        /// <param name="id">ID do repositório</param>
        /// <returns>Informações do repositório</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GitRepo>> Get(long id)
        {
            var repo = await _gitReposService.GetRepo(id);

            if (repo == null)
                return NotFound();

            return repo;
        }
    }
}
