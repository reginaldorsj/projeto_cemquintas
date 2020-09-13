import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BotoesSepultamentoComponent } from './botoes-sepultamento.component';

describe('BotoesSepultamentoComponent', () => {
  let component: BotoesSepultamentoComponent;
  let fixture: ComponentFixture<BotoesSepultamentoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BotoesSepultamentoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BotoesSepultamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
