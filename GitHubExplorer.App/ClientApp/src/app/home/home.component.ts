import { Component, OnInit } from '@angular/core';
import { GitRepoListItem, GitReposService } from '../services/git-repos.service';
import { Page } from '../services/models/page.model';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { empty } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  formFilter: string = '';

  currentFilter: string = '';

  gitReposPage: Page<GitRepoListItem> = null;
  searching = false;

  constructor(
    private gitReposService: GitReposService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
        if (params.has('filter')) {
          this.searching = true;
          this.currentFilter = this.formFilter = params.get('filter');
          const page = params.has('page') ? +params.get('page') : 1;
          return this.gitReposService.search(this.currentFilter, page);
        } else {
          return empty();
        }
      })
    ).subscribe(gitReposPage => {
      this.gitReposPage = gitReposPage;
      this.searching = false;
    }, _ => this.searching = false);
  }

  search(searchForm: NgForm) {
    if (searchForm.invalid) {
      searchForm.control.markAllAsTouched();
      return;
    }

    this.currentFilter = this.formFilter;
    this.router.navigate(['/home', { filter: this.formFilter, page: 1 }], { replaceUrl: true });
  }

  loadPreviousPage(): void {
    this.router.navigate(['/home', { filter: this.formFilter, page: this.gitReposPage.number - 1 }], { replaceUrl: true });
  }

  loadNextPage(): void {
    this.router.navigate(['/home', { filter: this.formFilter, page: this.gitReposPage.number + 1 }], { replaceUrl: true });
  }
}
