import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PrimeNGModule } from '../prime-ng.module';

import { UfCidadeComponent } from './uf-cidade/uf-cidade.component';
import { DatePickerMaskComponent } from './date-picker-mask/date-picker-mask.component';
import { DateTimePickerMaskComponent } from './date-time-picker-mask/date-time-picker-mask.component';


@NgModule({
  declarations: [
    UfCidadeComponent,
    DatePickerMaskComponent,
    DateTimePickerMaskComponent
  ],
  imports: [
    CommonModule,
    PrimeNGModule,
    FormsModule
  ],
  exports: [
    UfCidadeComponent,
    DatePickerMaskComponent,
    DateTimePickerMaskComponent
  ]
})
export class ComponentsModule { }
