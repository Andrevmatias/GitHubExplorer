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
          return this.gitReposService.search(this.currentFilter);
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
    this.router.navigate(['/home', { filter: this.formFilter }], { replaceUrl: true })
    this.loadPage();
  }

  loadPreviousPage(): void {
    this.loadPage(this.gitReposPage.number - 1);
  }

  loadNextPage(): void {
    this.loadPage(this.gitReposPage.number + 1);
  }

  loadPage(page: number = 1) {
    this.searching = true;
    this.gitReposService.search(this.currentFilter, page)
      .subscribe(resultPage => {
        this.gitReposPage = resultPage;
        this.searching = false;
      }, _ => this.searching = false);
  }
}
