import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CartoriosComponent } from './cartorios.component';

describe('CartoriosComponent', () => {
  let component: CartoriosComponent;
  let fixture: ComponentFixture<CartoriosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CartoriosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CartoriosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
