import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TodoListComponent } from './features/ToDo/todo-list/todo-list.component';
import { HomeComponent } from './core/components/home/home.component';

const routes: Routes = [
  // home page route
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'todo-list',
    component: TodoListComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
