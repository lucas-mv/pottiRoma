import { TestBed, inject } from '@angular/core/testing';

import { GamificationService } from './gamification.service';

describe('GamificationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GamificationService]
    });
  });

  it('should be created', inject([GamificationService], (service: GamificationService) => {
    expect(service).toBeTruthy();
  }));
});
