import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { TodoListComponent } from './features/ToDo/todo-list/todo-list.component';
import { HomeComponent } from './core/components/home/home.component';
import { FormsModule } from '@angular/forms';
import { PageNotFoundComponent } from './core/components/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    TodoListComponent,
    HomeComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
