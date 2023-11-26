import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddTodoItemRequest } from '../models/add-todoItem-request.model';
import { ToDoItem } from '../models/todoItem.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ToDoItemService {

  constructor(private http: HttpClient) {}

  // Add to do item
  addToDoItem(model: AddTodoItemRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/TodoItem`, model);
  }

  // Get all to do items
  getAllToDoItems(): Observable<ToDoItem[]> {
    return this.http.get<ToDoItem[]>(`${environment.apiBaseUrl}/api/TodoItem`)
  }
}

