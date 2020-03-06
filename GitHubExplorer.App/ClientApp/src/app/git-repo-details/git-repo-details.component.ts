import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { switchMap } from 'rxjs/operators';
import { GitReposService } from '../services/git-repos.service';
import { Page } from '../services/models/page.model';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { GitRepoListItem } from '../services/models/git-repo-list-item.model';
import { GitRepo } from '../services/models/git-repo.model';

@Component({
  selector: 'app-git-repo-details',
  templateUrl: './git-repo-details.component.html',
  styleUrls: ['./git-repo-details.component.css']
})
export class GitRepoDetailsComponent implements OnInit {
  repo: GitRepo = null;
  authorReposPage: Page<GitRepoListItem> = null;

  loading = true;

  constructor(
    private gitReposService: GitReposService,
    private route: ActivatedRoute,
    public location: Location
  ) { }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.gitReposService.get(+params.get('id'))),
      switchMap(repo => {
        this.repo = repo;
        return this.gitReposService.getByUser(repo.author.id);
      })
    ).subscribe(authorReposPage => {
      this.authorReposPage = authorReposPage
      this.loading = false;
      if(window)
        window.scroll(0, 0);
    }, _ => this.loading = false);
  }

  loadPreviousPage(): void {
    this.loadPage(this.authorReposPage.number - 1);
  }

  loadNextPage(): void {
    this.loadPage(this.authorReposPage.number + 1);
  }

  loadPage(page: number = 1) {
    this.gitReposService.search(this.repo.author.id, page)
      .subscribe(resultPage => {
        this.authorReposPage = resultPage;
      });
  }

}
