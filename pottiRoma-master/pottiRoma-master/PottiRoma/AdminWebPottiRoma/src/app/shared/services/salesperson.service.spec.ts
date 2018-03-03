import { TestBed, inject } from '@angular/core/testing';

import { SalespersonService } from './salesperson.service';

describe('SalespersonService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SalespersonService]
    });
  });

  it('should be created', inject([SalespersonService], (service: SalespersonService) => {
    expect(service).toBeTruthy();
  }));
});
