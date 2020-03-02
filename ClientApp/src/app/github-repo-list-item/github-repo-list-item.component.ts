import { Component, OnInit, Input } from '@angular/core';
import { GitHubRepoListItem } from '../services/github-repos.service';

@Component({
  selector: 'app-github-repo-list-item',
  templateUrl: './github-repo-list-item.component.html',
  styleUrls: ['./github-repo-list-item.component.css']
})
export class GithubRepoListItemComponent implements OnInit {
  @Input() repo: GitHubRepoListItem = new GitHubRepoListItem(); 

  constructor() { }

  ngOnInit(): void {
  }

}
