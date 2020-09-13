import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InserirSepultamentoComponent } from './inserir-sepultamento.component';

describe('InserirSepultamentoComponent', () => {
  let component: InserirSepultamentoComponent;
  let fixture: ComponentFixture<InserirSepultamentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InserirSepultamentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InserirSepultamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
