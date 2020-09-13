import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImpressaoSepultamentoComponent } from './impressao-sepultamento.component';

describe('ImpressaoSepultamentoComponent', () => {
  let component: ImpressaoSepultamentoComponent;
  let fixture: ComponentFixture<ImpressaoSepultamentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImpressaoSepultamentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImpressaoSepultamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
