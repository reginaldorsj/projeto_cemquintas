import { TestBed } from '@angular/core/testing';

import { ExumacaoService } from './exumacao.service';

describe('ExumacaoService', () => {
  let service: ExumacaoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExumacaoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
