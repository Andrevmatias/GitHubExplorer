import { Component, OnInit } from '@angular/core';
import { GitRepoListItem } from '../services/git-repos.service';
import { Page } from '../services/models/page.model';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { FavReposService } from '../services/fav-repos.service';

@Component({
  selector: 'app-favorites-list',
  templateUrl: './favorites-list.component.html',
  styleUrls: ['./favorites-list.component.css']
})
export class FavoritesListComponent implements OnInit {
  gitReposPage: Page<GitRepoListItem> = null;
  searching = false;

  constructor(
    private favReposService: FavReposService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
        const page = params.has('page') ? +params.get('page') : 1;
        this.searching = true;
        return this.favReposService.getFavs(page);
      })
    ).subscribe(gitReposPage => {
      this.gitReposPage = gitReposPage;
      this.searching = false;
      if (window)
        window.scroll(0, 0);
    }, _ => this.searching = false);
  }

  loadPreviousPage(): void {
    this.router.navigate(['/favorites', { page: this.gitReposPage.number - 1 }], { replaceUrl: true });
  }

  loadNextPage(): void {
    this.router.navigate(['/favorites', { page: this.gitReposPage.number + 1 }], { replaceUrl: true });
  }
}
