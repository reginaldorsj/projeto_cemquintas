import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FunerariasComponent } from './funerarias.component';

describe('QuadrosComponent', () => {
  let component: FunerariasComponent;
  let fixture: ComponentFixture<FunerariasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FunerariasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FunerariasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
