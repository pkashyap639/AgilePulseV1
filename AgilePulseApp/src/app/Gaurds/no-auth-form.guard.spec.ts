import { TestBed } from '@angular/core/testing';
import { CanDeactivateFn } from '@angular/router';

import { noAuthFormGuard } from './no-auth-form.guard';

describe('noAuthFormGuard', () => {
  const executeGuard: CanDeactivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => noAuthFormGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
