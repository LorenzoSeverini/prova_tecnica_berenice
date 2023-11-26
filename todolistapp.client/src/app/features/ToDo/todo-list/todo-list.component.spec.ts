import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TodoListComponent } from './todo-list.component';

describe('TodoListComponent', () => {
  let component: TodoListComponent;
  let fixture: ComponentFixture<TodoListComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TodoListComponent ],
      imports: [ HttpClientTestingModule ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TodoListComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve todos from the server', () => {
    const mockToDoItem = [
      { title: 'Todo 1', content: 'Todo 1 content', createdAt: new Date(), updatedAt: new Date(), isCompleted: false },
      { title: 'Todo 2', content: 'Todo 2 content', createdAt: new Date(), updatedAt: new Date(), isCompleted: false }
    ];

    component.ngOnInit();

    const req = httpMock.expectOne('/todo-list');
    expect(req.request.method).toEqual('GET');
    req.flush(mockToDoItem);

    expect(component.toDoItem.length).toEqual(2);
  });
});
