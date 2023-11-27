import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToDoItemService } from '../services/to-do-item.service';
import { ToDoItem } from '../models/todoItem.model';
import { Observable, map, of, take } from 'rxjs';
import { Subscription } from 'rxjs';
import { AddTodoItemRequest } from '../models/add-todoItem-request.model';
import { UpdateToDoItemRequest } from '../models/update-ToDoItem-request.model';

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

  newToDoItemTitle = '';

  newToDoItemContent = '';

  paramsSubscription?: Subscription;

  editToDoItemSubscription?: Subscription;

  toDoItems$?: Observable<ToDoItem[]>;

  private addToDoItemSubscription?: Subscription;

  // error message for title and content
  titleErrorMessage: string = '';
  contentErrorMessage: string = '';

  //--------------------------------------
  // constructor function that run when the component is created
  constructor( private toDoItemService: ToDoItemService,) {}

  ngOnInit(): void {
    this.toDoItems$ = this.toDoItemService.getAllToDoItems()
      .pipe(
        map(toDoItems => toDoItems.sort((a, b) => {
          // Sort by createdAt in descending order
          return new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime();
        }))
      );
  }

  //-------------------------------------
  // Add new todo item

  // button disabled logic for add new todo item
  isAddButtonDisabled(): boolean {
    return this.newToDoItemTitle.trim() === '' || this.newToDoItemContent.trim() === '';
  }

  // Update the method to return a boolean value
  onSubmitNewToDoItem(): boolean {
    this.titleErrorMessage = '';
    this.contentErrorMessage = '';

    // Validate the fields
    if (this.newToDoItemTitle.trim() === '') {
      this.titleErrorMessage = 'Title cannot be empty';
      return false;
    }

    if (this.newToDoItemContent.trim() === '') {
      this.contentErrorMessage = 'Content cannot be empty';
      return false;
    }

    const newTodo: AddTodoItemRequest = {
      title: this.newToDoItemTitle,
      content: this.newToDoItemContent
    };

    // Add the new todo item
    this.addToDoItemSubscription = this.toDoItemService.addToDoItem(newTodo)
      .subscribe({
        next: () => {

          if (this.toDoItems$) {
            this.toDoItems$.pipe(take(1)).subscribe(items => {
              items.unshift();
              this.toDoItems$ = of([...items]);
            });
          }

          // reset input value after adding
          this.newToDoItemTitle = '';
          this.newToDoItemContent = '';
        },
        // error: (error) => {
        //   console.error('Error while adding new item:', error);
        // }
      });

    return true;
  }

  // Edit and Update logic
  //-------------------------------------
  // is in edit mode
  isInEditMode(id: string): boolean {
    return this.editableId === id;
  }

  toggleMark(toDoItem: ToDoItem): void {
    // Toggle the local isMarked property
    toDoItem.isMarked = !toDoItem.isMarked;

    // Update the isMarked property in the database
    const updateRequest: UpdateToDoItemRequest = {
      title: toDoItem.title,
      content: toDoItem.content,
      isMarked: toDoItem.isMarked
    };

    this.toDoItemService.updateToDoItem(toDoItem.id.toString(), updateRequest)
      .subscribe(() => {

        // Update the local todo items
        if (this.toDoItems$) {
          this.toDoItems$.pipe(take(1)).subscribe(items => {
            const index = items.findIndex(item => item.id === toDoItem.id);
            items[index] = toDoItem;
            this.toDoItems$ = of([...items]);
          });
        }
      });
  }

  onEdit(toDoItem: ToDoItem): void {
    // Use the todoItem parameter here
    this.editableId = toDoItem.id.toString();
    this.editedToDoItems[toDoItem.id] = { ...toDoItem };
  }

  // Save on click event
  onSave(toDoItem: ToDoItem): void {
    const updateRequest: UpdateToDoItemRequest = {
      title: toDoItem.title,
      content: toDoItem.content,
      isMarked: toDoItem.isMarked
    };

    this.toDoItemService.updateToDoItem(toDoItem.id.toString(), updateRequest)
    .subscribe(() => {
      this.editableId = null;
    });
  }

  // Cancel on click event
  onCancel(): void {
    this.editableId = null;
  }

  //-------------------------------------
  // Delete on click event
  onDelete(id: string): void {
    this.toDoItemService.deleteToDoItem(id)
      .subscribe({
        next: () => {
          this.toDoItems$ = this.toDoItemService.getAllToDoItems();
      }
    });
  }

  //-------------------------------------
  // destroy
  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editToDoItemSubscription?.unsubscribe();
    this.addToDoItemSubscription?.unsubscribe();
  }
}
