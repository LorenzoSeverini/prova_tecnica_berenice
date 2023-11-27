<!-- Create a documentation file to the project -->

## Documentation

#### For a better view of this file use the shortcut: `Ctrl + Shift + V` in Visual Studio Code.

### Technologies
- Visual studio 2022 / VS Code
- Angular 18
- .Net 7
- EntityFramework Core
- Postgresql

### Backend functionalities

- The backend is a REST API that exposes the following endpoints:
    - `GET /api/ToDoItem` - returns all the ToDoItem items
    - `GET /api/ToDoItem/{id}` - returns the ToDoItem item with the given id
    - `POST /api/ToDoItem` - creates a new ToDoItem item
    - `PUT /api/ToDoItem/{id}` - updates the ToDoItem item with the given id
    - `DELETE /api/ToDoItem/{id}` - deletes the ToDoItem item with the given id

- The ToDoList object is defined as:

```
{
    guid : "Id"
    string : "Title",
    string : "Contents",
    boolean :  "IsMarked",
    datetime : "CreatedAt",
    datetime : "UpdatedAt",
}
```

### Functional requirements

- home page with a welcome page and a link to the ToDoList page
- The user can see the list of ToDoItem items
- The user can create a new ToDoItem item
- The user can update an existing ToDoItem item
- The user can delete an existing ToDoItem item
- The user can mark an existing ToDoItem item as completed


### The structure of server-side project is the following:

```
- Connected Services
- Dependencies
- Properties
- Controllers
    - ToDoItemController.cs
- Models 
    - Dto
    - Entities
- Migrations
- Repositories
    - Implementation
    - Interfaces
- appsettings.json
- Program.cs
```

The MVC pattern is used in the project. The controllers are responsible for handling the incoming HTTP requests, validating the input, and returning the response to the client. The controllers are located in the Controllers folder. The models are located in the Models folder. The repositories are located in the Repositories folder. The appsettings.json file contains the configuration data for the application. The Program.cs file contains the entry point of the application.

### Frontend functionalities (Angular)

- The frontend is a SPA, with 2 views to allow the user to display, insert, delete, edit ToDoItem, and a Home view. 


### The structure of client-side project is the following:

```
- node_modules
- src
    - app
        - core
            - components
                - home 
                    - home.component.css
                    - home.component.html
                    - home.component.ts
                    - home.module.ts
                navbar
                    - navbar.component.css
                    - navbar.component.html
                    - navbar.component.ts
                    - navbar.module.ts
        - features
            - ToDo 
                - models
                    - add-toDoItem-request.model.ts
                    - toDoitem.model.ts
                    - update-toDoItem-request.model.ts
                - services
                    -to-do-item.service.spec.ts
                    - to-do-item.service.ts
                todo-list
                    - todo-list.component.css
                    - todo-list.component.html
                    - todo-list.component.ts
                    - todo-list.module.ts
        - app-routing.module.ts
        - app.component.css
        - app.component.html
        - app-component.spec.ts
        - app.component.ts
        - app.module.ts
    - assets
    - environments
    - index.html
    - main.ts
    - ecc...
```

### In the Client side on Agular, in the app folder there are two subfolders: core and features.

- Core folder there are the components that are used in the app, in this case the navbar and the home component.

- In the features folder there are the components that are used in the app, in this case the todo-list component. Here is handle the logic of the toDoItem, get, post, put, delete, and the logic of the checkbox.