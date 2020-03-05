using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Models
{
    /// <summary>
    /// Detalhes de um repositório
    /// </summary>
    public class GitRepo
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
        /// Autor do repositório
        /// </summary>
        public GitUser Author { get; set; }
        /// <summary>
        /// Número de estrelas do repositório
        /// </summary>
        public int StarCount { get; set; }
        /// <summary>
        /// Número de pendências do repositório
        /// </summary>
        public int OpenIssuesCount { get; set; }
        /// <summary>
        /// Principal linguagem de programação usada no repositório
        /// </summary>
        public string MainProgrammingLanguage { get; set; }
        /// <summary>
        /// Data de criação do repositório
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Indica se o repositório é favorito
        /// </summary>
        public bool IsFavorite { get; set; }
    }
}
