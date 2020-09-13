import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TermosVencidosComponent } from './termos-vencidos.component';

describe('TermosVencidosComponent', () => {
  let component: TermosVencidosComponent;
  let fixture: ComponentFixture<TermosVencidosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TermosVencidosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TermosVencidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
