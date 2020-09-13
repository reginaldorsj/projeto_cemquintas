import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImpressaoExumacaoComponent } from './impressao-exumacao.component';

describe('ImpressaoExumacaoComponent', () => {
  let component: ImpressaoExumacaoComponent;
  let fixture: ComponentFixture<ImpressaoExumacaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImpressaoExumacaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImpressaoExumacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
