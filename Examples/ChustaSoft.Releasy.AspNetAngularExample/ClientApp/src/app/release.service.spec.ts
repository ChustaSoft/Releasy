import { TestBed } from '@angular/core/testing';

import { ReleaseService } from './release.service';

describe('ReleaseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ReleaseService = TestBed.get(ReleaseService);
    expect(service).toBeTruthy();
  });
});
