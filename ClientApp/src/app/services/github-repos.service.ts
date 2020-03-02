import { Injectable } from '@angular/core';

export class GitHubRepoListItem {
  id: string;
  name: string;
  description: string;
  authorName: string;
  starCount: number = 0;
}

@Injectable({
  providedIn: 'root'
})
export class GitHubReposService {

  constructor() { }
}
