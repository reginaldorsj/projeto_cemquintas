import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdutividadeDigitadoresComponent } from './produtividade-digitadores.component';

describe('ProdutividadeDigitadoresComponent', () => {
  let component: ProdutividadeDigitadoresComponent;
  let fixture: ComponentFixture<ProdutividadeDigitadoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdutividadeDigitadoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdutividadeDigitadoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
