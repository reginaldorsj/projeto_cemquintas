import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListagemFaixaComponent } from './listagem-faixa.component';

describe('ListagemFaixaComponent', () => {
  let component: ListagemFaixaComponent;
  let fixture: ComponentFixture<ListagemFaixaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListagemFaixaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListagemFaixaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
