import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TodoListComponent } from './features/ToDo/todo-list/todo-list.component';
import { HomeComponent } from './core/components/home/home.component';
import { PageNotFoundComponent } from './core/components/page-not-found/page-not-found.component';

// routes for the app components
const routes: Routes = [
  // home page
  {
    path: '',
    component: HomeComponent,
  },
  // todo list page
  {
    path: 'todo-list',
    component: TodoListComponent,
  },
  // not foun 404 page
  {
    path: '**',
    component: PageNotFoundComponent,
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
