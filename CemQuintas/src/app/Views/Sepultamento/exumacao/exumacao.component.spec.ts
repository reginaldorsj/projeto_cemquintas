import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExumacaoComponent } from './exumacao.component';

describe('ExumacaoComponent', () => {
  let component: ExumacaoComponent;
  let fixture: ComponentFixture<ExumacaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExumacaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExumacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
