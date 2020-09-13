import { NgModule } from '@angular/core';

import { ToastModule } from 'primeng/toast';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { ProgressBarModule } from 'primeng/progressbar';
import { DropdownModule } from 'primeng/dropdown';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ListboxModule } from 'primeng/listbox';
import { CalendarModule } from 'primeng/calendar';
import { InputNumberModule } from 'primeng/inputnumber';
import { CheckboxModule } from 'primeng/checkbox';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputMaskModule } from 'primeng/inputmask';

@NgModule({
  declarations: [
  ],
  imports: [
    DropdownModule,
    InputTextModule,
    ButtonModule,
    ProgressBarModule,
    ToastModule,
    TableModule,
    ConfirmDialogModule,
    ListboxModule,
    CalendarModule,
    InputNumberModule,
    CheckboxModule,
    InputTextareaModule,
    InputMaskModule
  ],
  exports: [
    DropdownModule,
    InputTextModule,
    ButtonModule,
    ProgressBarModule,
    ToastModule,
    TableModule,
    ConfirmDialogModule,
    ListboxModule,
    CalendarModule,
    InputNumberModule,
    CheckboxModule,
    InputTextareaModule,
    InputMaskModule
  ],
  providers: [
  ]
})
export class PrimeNGModule { }
