using GitHubExplorer.Models;
using System.Collections.Generic;
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
        /// Retorna uma lista de repositórios pelos seus IDs
        /// </summary>
        /// <param name="ids">IDs dos repositórios</param>
        /// <returns>Lista de repositórios dos IDs. IDs não encontrados são descartados.</returns>
        Task<IList<GitRepoListItem>> GetRepos(IEnumerable<long> ids);
        /// <summary>
        /// Retorna uma página de repositórios de um usuário
        /// </summary>
        /// <param name="userId">ID do usuário</param>
        /// <param name="page">Número da página a ser retornada</param>
        /// <returns>Página de repositórios do usuário</returns>
        Task<Page<GitRepoListItem>> GetUserReposPage(string userId, int page);
    }
}