// Model for updating a ToDoItem
export interface UpdateToDoItemRequest {
  title: string;
  content: string;
  isMarked: boolean;
}
