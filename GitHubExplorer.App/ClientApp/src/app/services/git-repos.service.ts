import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface GitRepoListItem {
  id: number;
  name: string;
  description: string;
  authorName: string;
  starCount: number;
}

export interface GitRepo {
  id: number;
  name: string;
  description: string;
  starCount: number;
  author: GitUser;
  openIssuesCount: number;
  mainProgrammingLanguage: string;
  creationDate: Date;
}

export interface GitUser {
  id: string;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class GitReposService {
  private _serviceBaseUrl = "/gitrepos"

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this._serviceBaseUrl = baseUrl + this._serviceBaseUrl;
  }
}
