using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Models
{
    public class GitHubRepo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public int StarCount { get; set; }
        public int OpenIssuesCount { get; set; }
        public string MainLanguage { get; set; }
        public DateTime CreationDate { get; set; }
        public IList<GitHubRepoListItem> AuthorRepos { get; set; }
    }
}
