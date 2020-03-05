﻿using GitHubExplorer.Models;
using System.Threading.Tasks;

namespace GitHubExplorer.Services
{
    /// <summary>
    /// Serviço de comunicação com o Git
    /// </summary>
    public interface IGitReposService
    {
        /// <summary>
        /// Retorna uma página de uma pesquisa de repositórios
        /// </summary>
        /// <param name="filter">Filtro a ser usado na pesquisa</param>
        /// <param name="page">Número da página a ser retornada</param>
        /// <returns>Página de resultados da pesquisa</returns>
        Task<Page<GitRepoListItem>> GetReposPage(string filter, int page);
        /// <summary>
        /// Retorna detalhes de um repositório
        /// </summary>
        /// <param name="id">ID do repositório</param>
        /// <returns>Detalhes do repositório ou <c>null</c> caso o repositório não tenha sido encontrado</returns>
        Task<GitRepo> GetRepo(long id);
        /// <summary>
        /// Retorna um repositório como um item de lista
        /// </summary>
        /// <param name="id">ID do repositório</param>
        /// <returns>Item de lista do repositório ou <c>null</c> caso o repositório não tenha sido encontrado</returns>
        Task<GitRepoListItem> GetRepoAsListItem(long id);
        /// <summary>
        /// Retorna uma página de repositórios de um usuário
        /// </summary>
        /// <param name="userId">ID do usuário</param>
        /// <param name="page">Número da página a ser retornada</param>
        /// <returns>Página de repositórios do usuário</returns>
        Task<Page<GitRepoListItem>> GetUserReposPage(string userId, int page);
    }
}