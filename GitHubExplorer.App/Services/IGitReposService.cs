using GitHubExplorer.Models;

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
        Page<GitRepoListItem> GetReposPage(string filter, int page);
        /// <summary>
        /// Retorna detalhes de um repositório
        /// </summary>
        /// <param name="id">ID do repositório</param>
        /// <returns>Detalhes do repositório ou <c>null</c> caso o repositório não tenha sido encontrado</returns>
        GitRepo GetRepo(string id);
        /// <summary>
        /// Retorna uma página de repositórios de um usuário
        /// </summary>
        /// <param name="userId">ID do usuário</param>
        /// <param name="page">Número da página a ser retornada</param>
        /// <returns>Página de repositórios do usuário</returns>
        Page<GitRepoListItem> GetUserReposPage(string userId, int page);
    }
}