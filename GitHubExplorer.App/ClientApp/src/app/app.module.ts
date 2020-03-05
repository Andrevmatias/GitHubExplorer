import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GitRepoListComponent } from './git-repo-list/git-repo-list.component';
import { GitRepoDetailsComponent } from './git-repo-details/git-repo-details.component';
import { NotFoundComponent } from './not-found/not-found.component';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';

registerLocaleData(localePt);

const routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'repo/:id', component: GitRepoDetailsComponent },
  { path: '404', component: NotFoundComponent },
  { path: '**', redirectTo: '/404' }
]

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GitRepoListComponent,
    GitRepoDetailsComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
