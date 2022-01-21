import { ComponentFixture, TestBed } from '@angular/core/testing';
import {FormGroup, ReactiveFormsModule, FormsModule, FormBuilder} from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { AddstudentComponent } from './addstudent.component';

describe('AddstudentComponent', () => {
  let component: AddstudentComponent;
  let fixture: ComponentFixture<AddstudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports:[  FormsModule,
        ReactiveFormsModule,
      HttpClientTestingModule ],
      declarations: [ AddstudentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddstudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
