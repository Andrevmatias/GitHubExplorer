import { Component } from '@angular/core';
import { GitRepoListItem, GitReposService } from '../services/git-repos.service';
import { Page } from '../services/models/page.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  formFilter: string = '';

  currentFilter: string = '';

  gitReposPage: Page<GitRepoListItem> = null;
  searching = false;

  constructor(
    private gitReposService: GitReposService
  ) { }

  search(searchForm: NgForm) {
    if (searchForm.invalid) {
      searchForm.control.markAllAsTouched();
      return;
    }

    this.currentFilter = this.formFilter;
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
