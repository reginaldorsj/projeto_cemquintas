import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SepultamentoService } from '../../Services/sepultamento.service';

@Component({
  selector: 'app-date-picker-mask',
  templateUrl: './date-picker-mask.component.html',
  styleUrls: ['./date-picker-mask.component.css']
})
export class DatePickerMaskComponent implements OnInit {

  @Input() stringDate: string;
  date: Date;
  @Output() dataEnviada = new EventEmitter();

  show: boolean;

  constructor(public sepultamentoService: SepultamentoService) { }

  ngOnInit(): void {
    this.show = false;
  }

  mostraCalendar(): void {
    this.show = !this.show;
    this.dataAtual();
  }

  select(): void {
    this.show = false;
    this.stringDate = this.date.toLocaleDateString("pt-BR");
    this.dataEnviada.emit(this.date);
  }

  clearClick(): void {
    this.show = false;
    this.stringDate = undefined;
    this.date = undefined;
    this.dataEnviada.emit();
  }

  complete(): void {
    this.show = false;
    this.dataAtual();
  }

  input(): void {
    this.show = false;
  }

  blur(): void {
    this.dataAtual();
  }

  private dataAtual(): void {
    if (!this.stringDate)
      return;

    let arrayDate = this.stringDate.split('/');
    var dataAtual = new Date(Number.parseInt(arrayDate[2]), Number.parseInt(arrayDate[1]) - 1, Number.parseInt(arrayDate[0]));
    if (this.stringDate == dataAtual.toLocaleDateString("pt-BR")) {
      this.date = dataAtual;
      this.dataEnviada.emit(this.date);
    } else {
      this.stringDate = undefined;
      this.date = undefined;
      this.dataEnviada.emit();
    }
  }
}
