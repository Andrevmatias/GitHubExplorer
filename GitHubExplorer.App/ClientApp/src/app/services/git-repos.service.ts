import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Page } from './models/page.model';
import { GitRepoListItem } from './models/git-repo-list-item.model';
import { GitRepo } from './models/git-repo.model';

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
