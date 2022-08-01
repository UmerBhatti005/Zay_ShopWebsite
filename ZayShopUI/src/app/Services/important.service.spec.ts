import { TestBed } from '@angular/core/testing';

import { ImportantService } from './important.service';

describe('ImportantService', () => {
  let service: ImportantService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImportantService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
