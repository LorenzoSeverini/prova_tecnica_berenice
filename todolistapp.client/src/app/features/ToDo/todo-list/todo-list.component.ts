import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToDoItemService } from '../services/to-do-item.service';
import { ToDoItem } from '../models/todoItem.model';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs';
import { AddTodoItemRequest } from '../models/add-todoItem-request.model';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit, OnDestroy {

  // -------------------------------------
  // starter logic for todo list component
  id: string | null = null;

  editableId: string | null = null;

  editedToDoItems: { [key: string]: ToDoItem } = {};

  isAddingNew = false;

  newToDoItemTitle = '';

  newToDoItemContent = '';

  paramsSubscription?: Subscription;

  editToDoItemSubscription?: Subscription;

  toDoItems$?: Observable<ToDoItem[]>;

  //--------------------------------------
  // constructor function that run when the component is created
  constructor(
    private toDoItemService: ToDoItemService,
    private toDoitemService: ToDoItemService,) {
  }

  // on init
  ngOnInit(): void {
    this.toDoItems$ = this.toDoItemService.getAllToDoItems();
  }

  //-------------------------------------
  // Add new todo item
  toggleAddNew() {
    this.isAddingNew = true;
  }

  cancelAddNew() {
    this.isAddingNew = false;
    this.newToDoItemTitle = '';
    this.newToDoItemContent = '';
  }

  // Submit new todo item form event
  onSubmitNewToDoItem() {
    const newTodo: AddTodoItemRequest = {
      title: this.newToDoItemTitle,
      content: this.newToDoItemContent
    };

    this.toDoItemService.addToDoItem(newTodo)
      .subscribe(() => {
        this.toDoItems$ = this.toDoItemService.getAllToDoItems();
        this.cancelAddNew();
      }, error => {
        console.error('Error while adding new item:', error);
      });
  }

  // Edit and Update logic
  //-------------------------------------
  // is in edit mode
  isInEditMode(id: string): boolean {
    return this.editableId === id;
  }

  onEdit(toDoItem: ToDoItem): void {
    // Use the todoItem parameter here
    console.log(toDoItem);
    this.editableId = toDoItem.id.toString();
    this.editedToDoItems[toDoItem.id] = { ...toDoItem };
  }

  // Save on click event
  onSave(toDoItem: ToDoItem): void {
    this.toDoItemService.updateToDoItem(toDoItem.id.toString(), toDoItem)
      .subscribe((response) => {
        console.log('Updated:', response);
        this.editableId = null;
      });
  }

  // Cancel on click event
  onCancel(): void {
    this.editableId = null;
  }
  //-------------------------------------

  //-------------------------------------
  // Delete on click event
  onDelete(id: string): void {
    this.toDoItemService.deleteToDoItem(id)
      .subscribe({
        next: () => {
          console.log('Deleted', id);
          this.toDoItems$ = this.toDoItemService.getAllToDoItems();
      }
    });
  }

  //-------------------------------------
  // destroy
  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editToDoItemSubscription?.unsubscribe();
  }
}
