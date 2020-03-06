import { Component, Input } from '@angular/core';
import { GitRepoListItem } from '../../services/models/git-repo-list-item.model';

@Component({
  selector: 'git-repo-list',
  templateUrl: './git-repo-list.component.html',
  styleUrls: ['./git-repo-list.component.css']
})
export class GitRepoListComponent {
  @Input() repos: GitRepoListItem[] = new Array<GitRepoListItem>();

  constructor() { }
}
