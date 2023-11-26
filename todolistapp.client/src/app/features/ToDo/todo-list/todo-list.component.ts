import { Component, OnInit } from '@angular/core';
import { ToDoItemService } from '../services/to-do-item.service';
import { ToDoItem } from '../models/todoItem.model';
import { Observable } from 'rxjs';
// import { HttpClient } from '@angular/common/http';
// import { ToDoItemService } from '../services/to-do-item.service';
// import { ViewTodoItemRequest } from '../models/todoItem.model';
// import { AddTodoItemRequest } from '../models/add-todoItem-request.model';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  // toDoItems?: ToDoItem [];
  toDoItems$?: Observable<ToDoItem[]>;

  constructor(private toDoItemService: ToDoItemService) {}

  ngOnInit(): void {
    this.toDoItems$ = this.toDoItemService.getAllToDoItems();
    // .subscribe({
    //   next: (response) => {
    //     this.toDoItems = response;
    //   }
    // });
  }
}
