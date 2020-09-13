import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { SepultamentoService } from '../../Services/sepultamento.service';

@Component({
  selector: 'app-date-time-picker-mask',
  templateUrl: './date-time-picker-mask.component.html',
  styleUrls: ['./date-time-picker-mask.component.css']
})
export class DateTimePickerMaskComponent implements OnInit {

  @Input() stringDateTime: string;
  date: Date;
  @Output() dataHoraEnviada = new EventEmitter();

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
    this.stringDateTime = this.date.toLocaleString("pt-BR").substring(0, 16);
    this.dataHoraEnviada.emit(this.date);
  }

  clearClick(): void {
    this.show = false;
    this.stringDateTime = undefined;
    this.date = undefined;
    this.dataHoraEnviada.emit();
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
    if (!this.stringDateTime)
      return;

    let arrayDateTime = this.stringDateTime.split(' ');
    let arrayDate = arrayDateTime[0].split('/');
    let arrayTime = arrayDateTime[1].split(':')
    var dataAtual = new Date(Number.parseInt(arrayDate[2]), Number.parseInt(arrayDate[1]) - 1, Number.parseInt(arrayDate[0]), Number.parseInt(arrayTime[0]), Number.parseInt(arrayTime[1]));
    if (this.stringDateTime == dataAtual.toLocaleString("pt-BR").substring(0,16)) {
      this.date = dataAtual;
      this.dataHoraEnviada.emit(this.date);
    } else {
      this.stringDateTime = undefined;
      this.date = undefined;
      this.dataHoraEnviada.emit();
    }
  }
}
