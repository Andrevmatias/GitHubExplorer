import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Page } from './models/page.model';

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
  private _serviceBaseUrl = "gitrepos"

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this._serviceBaseUrl = baseUrl + this._serviceBaseUrl;
  }

  public get(repoId: number): Observable<GitRepo> {
    return this.http.get<GitRepo>(`${this._serviceBaseUrl}/${repoId}`);
  }

  public search(filter: string, page: number = 1): Observable<Page<GitRepoListItem>> {
    return this.http.get<Page<GitRepoListItem>>(`${this._serviceBaseUrl}/search?filter=${filter}&page=${page}`);
  }

  public getByUser(userId: string, page: number = 1): Observable<Page<GitRepoListItem>> {
    return this.http.get<Page<GitRepoListItem>>(`${this._serviceBaseUrl}/search-by-user?userId=${userId}&page=${page}`);
  }
}
