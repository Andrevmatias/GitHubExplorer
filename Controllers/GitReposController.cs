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
        private readonly ILogger<GitReposController> _logger;
        private readonly IGitReposService _gitReposService;

        public GitReposController(ILogger<GitReposController> logger, 
            IGitReposService gitReposService)
        {
            _logger = logger;
            _gitReposService = gitReposService;
        }

        /// <summary>
        /// Busca por repositórios
        /// </summary>
        /// <param name="filter">Filtro a ser usado</param>
        /// <param name="page">Página a ser retornada</param>
        /// <returns>Página de reposiórios resultados da pesquisa</returns>
        [HttpGet]
        public Page<GitRepoListItem> Search(string filter, int page = 1)
        {
            return _gitReposService.GetReposPage(filter, page);
        }

        /// <summary>
        /// Busca por repositórios de um usuário
        /// </summary>
        /// <param name="userId">ID do usuário autor dos repositórios</param>
        /// <param name="page">Página a ser retornada</param>
        /// <returns>Página de reposiórios de um usuário</returns>
        [HttpGet]
        public Page<GitRepoListItem> SearchByUser(string userId, int page = 1)
        {
            return _gitReposService.GetUserReposPage(userId, page);
        }

        /// <summary>
        /// Retorna informações sobre um repositório
        /// </summary>
        /// <param name="id">ID do repositório</param>
        /// <returns>Informações do repositório</returns>
        [HttpGet]
        public GitRepo Get(string id)
        {
            return _gitReposService.GetRepo(id);
        }
    }
}
