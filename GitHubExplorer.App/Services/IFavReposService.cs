using GitHubExplorer.Models;
using System.Threading.Tasks;

namespace GitHubExplorer.Services
{
    /// <summary>
    /// Serviço de manutenção de repositórios favoritos
    /// </summary>
    public interface IFavReposService
    {
        /// <summary>
        /// Adiciona um repositório favorito
        /// </summary>
        /// <param name="repoId">ID do repositório</param>
        /// <returns><c>True</c> caso tenha sido adicionado com sucesso e <c>False</c> caso já exista nos favoritos</returns>
        Task<bool> Add(long repoId);

        /// <summary>
        /// Retorna uma página de ids de repositórios favoritos
        /// </summary>
        /// <param name="page">Número da página</param>
        /// <returns>Página de ids de favoritos</returns>
        Task<Page<long>> GetPage(int page = 1);

        /// <summary>
        /// Remove um repositório dos favoritos
        /// </summary>
        /// <param name="repoId">ID do repositório</param>
        /// <returns><c>True</c> caso tenha sido removido com sucesso e <c>False</c> caso não tenha sido encontrado</returns>
        Task<bool> Remove(long repoId);
    }
}