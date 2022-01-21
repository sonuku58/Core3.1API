import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { studentApi } from './studentApi.service';

describe('studentApi', () => {
  let service: studentApi;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule]
    });
    service = TestBed.inject(studentApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
