import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Page } from './models/page.model';
import { GitRepoListItem } from './models/git-repo-list-item.model';

@Injectable({
  providedIn: 'root'
})
export class FavReposService {
  private _serviceBaseUrl = "favrepos"

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this._serviceBaseUrl = baseUrl + this._serviceBaseUrl;
  }

  public setAsFav(repoId: number): Observable<any> {
    return this.http.post<any>(`${this._serviceBaseUrl}/${repoId}`, {});
  }

  public setAsNotFav(repoId: number): Observable<any> {
    return this.http.delete<any>(`${this._serviceBaseUrl}/${repoId}`);
  }

  public getFavs(page: number = 1): Observable<Page<GitRepoListItem>> {
    return this.http.get<Page<GitRepoListItem>>(`${this._serviceBaseUrl}/?page=${page}`);
  }
}
