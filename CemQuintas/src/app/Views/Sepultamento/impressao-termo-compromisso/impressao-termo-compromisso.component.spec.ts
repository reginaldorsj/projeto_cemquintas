import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImpressaoTermoCompromissoComponent } from './impressao-termo-compromisso.component';

describe('ImpressaoTermoCompromissoComponent', () => {
  let component: ImpressaoTermoCompromissoComponent;
  let fixture: ComponentFixture<ImpressaoTermoCompromissoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImpressaoTermoCompromissoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImpressaoTermoCompromissoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
