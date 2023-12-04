import { TestBed, inject } from '@angular/core/testing';

import { FuncionarioFormService } from './funcionario-form.service';

describe('FuncionarioFormService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FuncionarioFormService]
    });
  });

  it('should be created', inject([FuncionarioFormService], (service: FuncionarioFormService) => {
    expect(service).toBeTruthy();
  }));
});
