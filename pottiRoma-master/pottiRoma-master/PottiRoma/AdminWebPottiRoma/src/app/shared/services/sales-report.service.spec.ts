import { TestBed, inject } from '@angular/core/testing';

import { SalesReportService } from './sales-report.service';

describe('SalesReportService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SalesReportService]
    });
  });

  it('should be created', inject([SalesReportService], (service: SalesReportService) => {
    expect(service).toBeTruthy();
  }));
});
