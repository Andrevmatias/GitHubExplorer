namespace GitHubExplorer.Models
{
    /// <summary>
    /// Informações de um usuário do GitHub
    /// </summary>
    public class GitUser
    {
        /// <summary>
        /// ID do usuário
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Name { get; set; }
    }
}