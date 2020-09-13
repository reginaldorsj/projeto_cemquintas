import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UfCidadeComponent } from './uf-cidade.component';

describe('UfCidadeComponent', () => {
  let component: UfCidadeComponent;
  let fixture: ComponentFixture<UfCidadeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UfCidadeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UfCidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
