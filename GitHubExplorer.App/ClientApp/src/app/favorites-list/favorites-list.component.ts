import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Page } from '../services/models/page.model';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { FavReposService } from '../services/fav-repos.service';
import { GitRepoListItem } from '../services/models/git-repo-list-item.model';

@Component({
  selector: 'app-favorites-list',
  templateUrl: './favorites-list.component.html',
  styleUrls: ['./favorites-list.component.css']
})
export class FavoritesListComponent implements OnInit {
  favReposPage: Page<GitRepoListItem> = null;
  loading = false;

  constructor(
    private favReposService: FavReposService,
    private route: ActivatedRoute,
    private router: Router,
    public location: Location
  ) { }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
        const page = params.has('page') ? +params.get('page') : 1;
        this.loading = true;
        return this.favReposService.getFavs(page);
      })
    ).subscribe(favReposPage => {
      this.favReposPage = favReposPage;
      this.loading = false;
      if (window)
        window.scroll(0, 0);
    }, _ => this.loading = false);
  }

  loadPreviousPage(): void {
    this.router.navigate(['/favorites', { page: this.favReposPage.number - 1 }], { replaceUrl: true });
  }

  loadNextPage(): void {
    this.router.navigate(['/favorites', { page: this.favReposPage.number + 1 }], { replaceUrl: true });
  }
}
