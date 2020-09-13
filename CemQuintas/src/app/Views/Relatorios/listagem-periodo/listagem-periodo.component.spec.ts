import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListagemPeriodoComponent } from './listagem-periodo.component';

describe('ListagemPeriodoComponent', () => {
  let component: ListagemPeriodoComponent;
  let fixture: ComponentFixture<ListagemPeriodoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListagemPeriodoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListagemPeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
