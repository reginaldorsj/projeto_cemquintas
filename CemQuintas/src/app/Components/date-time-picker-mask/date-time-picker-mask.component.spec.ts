import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DateTimePickerMaskComponent } from './date-time-picker-mask.component';

describe('DateTimePickerMaskComponent', () => {
  let component: DateTimePickerMaskComponent;
  let fixture: ComponentFixture<DateTimePickerMaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DateTimePickerMaskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DateTimePickerMaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
