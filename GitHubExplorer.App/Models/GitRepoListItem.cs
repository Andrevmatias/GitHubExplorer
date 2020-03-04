using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Models
{
    /// <summary>
    /// Informações para listagem de repositórios
    /// </summary>
    public class GitRepoListItem
    {
        /// <summary>
        /// ID do repositório
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Nome do repositório
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Descrição do repositório
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Nome do autor do repositório
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// Número de estrelas do repositório
        /// </summary>
        public int StarCount { get; set; }
    }
}
