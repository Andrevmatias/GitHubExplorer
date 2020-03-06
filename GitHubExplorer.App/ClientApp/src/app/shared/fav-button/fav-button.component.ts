import { FavReposService } from '../../services/fav-repos.service';
import { Output, Input, Component, EventEmitter, HostListener } from '@angular/core';

@Component({
  selector: 'fav-button',
  templateUrl: './fav-button.component.html',
  styleUrls: ['./fav-button.component.css']
})
export class FavButtonComponent {
  isFavValue = false;

  @Input() repoId: number;

  @Output() favChange = new EventEmitter();
  @Input()
  get isFavorite() {
    return this.isFavValue;
  }
  set isFavorite(val: boolean) {
    this.isFavValue = val;
    this.favChange.emit(this.isFavValue);
  }

  constructor(
    private favReposService: FavReposService,
  ) { }

  toggleFav() {
    if (!this.isFavorite) {
      this.favReposService.setAsFav(this.repoId)
        .subscribe(_ => this.isFavorite = true);
    } else {
      this.favReposService.setAsNotFav(this.repoId)
        .subscribe(_ => this.isFavorite = false);
    }
  }

  @HostListener("click", ["$event"])
  public onClick(event: any): void {
    event.stopPropagation();
  }
}
