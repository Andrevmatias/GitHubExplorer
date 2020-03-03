import { Component } from '@angular/core';
import { GitRepoListItem } from '../services/git-repos.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  gitRepos: Array<GitRepoListItem> = [];

}
