import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddTodoItemRequest } from '../models/add-todoItem-request.model';
import { ToDoItem } from '../models/todoItem.model';
import { environment } from 'src/environments/environment';
import { UpdateToDoItemRequest } from '../models/update-ToDoItem-request.model';

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

  // edit to do item
  getToDoItemById(id: string) : Observable<ToDoItem> {
    return this.http.get<ToDoItem>(`${environment.apiBaseUrl}/api/TodoItem/${id}`);
  }

  // update to do item
  updateToDoItem(id: string, UpdateToDoItemRequest: UpdateToDoItemRequest) : Observable<ToDoItem> {
    return this.http.put<ToDoItem>(`${environment.apiBaseUrl}/api/TodoItem/${id}`, UpdateToDoItemRequest);
  }

  // delete to do item
  deleteToDoItem(id: string): Observable<ToDoItem> {
    return this.http.delete<ToDoItem>(`${environment.apiBaseUrl}/api/TodoItem/${id}`);
  }
}
