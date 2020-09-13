import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Router, ActivatedRoute } from '@angular/router';

import { Sepultamento } from '../../../Models/sepultamento';
import { SepultamentoService } from '../../../Services/sepultamento.service';

@Component({
  selector: 'app-termos-vencidos',
  templateUrl: './termos-vencidos.component.html',
  styleUrls: ['./termos-vencidos.component.css']
})
export class TermosVencidosComponent implements OnInit {
  dataInicial: Date = new Date();
  dataFinal: Date = new Date();

  stringDateInicial: string;
  stringDateFinal: string;

  viewAtualizar: boolean = false;

  sepultamentos: Sepultamento[];

  constructor(public sepultamentoService: SepultamentoService, private messageService: MessageService,
    private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {

    let op: string = this.activatedRoute.snapshot.queryParams['op'];
    if (op == 'listar')
      this.listar(); 
  }

  listar() {
    if (!this.dataInicial) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: "Informe a DATA INICIAL." });
    }
    if (!this.dataFinal) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: "Informe a DATA FINAL." });
    }

    if (!this.dataInicial || !this.dataFinal) {
      return;
    }

    this.viewAtualizar = true;
    this.sepultamentoService.listarTermosDataLimite(this.dataInicial, this.dataFinal).subscribe(sepultamentos => {
      this.sepultamentos = sepultamentos;

      if (this.sepultamentos.length == 0) {
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Infelizmente!', detail: "Nenhum registro encontrado." });
      }

      this.viewAtualizar = false;
    }, (error: any) => {
      this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: error.message });
        this.viewAtualizar = false;
    });
  }

  getTwo(numero: number): string {
    return numero.toString().substring(2, 4);
  }

  select(sepultamento: Sepultamento): void {
    this.router.navigate([`/sepultamento/alterar/${sepultamento.IdSepultamento}`]);
  }

  recebeDataInicial(date: Date) {
    if (date)
      this.stringDateInicial = date.toLocaleDateString('pt-BR');
    else
      this.stringDateInicial = undefined;
    this.dataInicial = date;
  }

  recebeDataFinal(date: Date) {
    if (date)
      this.stringDateFinal = date.toLocaleDateString('pt-BR');
    else
      this.stringDateFinal = undefined;
    this.dataFinal = date;
  }
}
