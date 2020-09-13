import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LocalizarSepultamentoComponent } from './localizar-sepultamento.component';

describe('LocalizarSepultamentoComponent', () => {
  let component: LocalizarSepultamentoComponent;
  let fixture: ComponentFixture<LocalizarSepultamentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LocalizarSepultamentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LocalizarSepultamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
