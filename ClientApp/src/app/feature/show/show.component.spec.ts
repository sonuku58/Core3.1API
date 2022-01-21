import { ComponentFixture, TestBed } from '@angular/core/testing';
import {FormGroup, ReactiveFormsModule, FormsModule, FormBuilder} from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ShowComponent } from './show.component';
import {studentApi } from 'src/app/shared/studentApi.service';

describe('ShowComponent', () => {
  let component: ShowComponent;
  let fixture: ComponentFixture<ShowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports:[HttpClientTestingModule,
      FormsModule,
    ReactiveFormsModule],
      declarations: [ ShowComponent ],
      providers:[studentApi]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
