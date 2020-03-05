import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { switchMap } from 'rxjs/operators';
import { GitRepo, GitReposService, GitRepoListItem } from '../services/git-repos.service';
import { Page } from '../services/models/page.model';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent {
  constructor(
  ) { }
}
