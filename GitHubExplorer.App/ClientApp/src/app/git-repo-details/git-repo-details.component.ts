import { Component, OnInit } from '@angular/core';
import { switchMap } from 'rxjs/operators';
import { GitRepo, GitReposService, GitRepoListItem } from '../services/git-repos.service';
import { Page } from '../services/models/page.model';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-git-repo-details',
  templateUrl: './git-repo-details.component.html',
  styleUrls: ['./git-repo-details.component.css']
})
export class GitRepoDetailsComponent implements OnInit {
  repo: GitRepo = null;
  authorReposPage: Page<GitRepoListItem> = null;

  constructor(
    private gitReposService: GitReposService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.gitReposService.get(+params.get('id'))),
      switchMap(repo => {
        this.repo = repo;
        return this.gitReposService.getByUser(repo.author.id);
      })
    ).subscribe(authorReposPage => this.authorReposPage = authorReposPage);
  }

}
