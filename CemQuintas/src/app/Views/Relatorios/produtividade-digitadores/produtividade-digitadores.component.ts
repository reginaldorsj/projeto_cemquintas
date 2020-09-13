import { Component, OnInit } from '@angular/core';

import { SepultamentoService } from '../../../Services/sepultamento.service';
import { MessageService } from 'primeng/api';

import { Produtividade } from '../../../Models/produtividade';

@Component({
  selector: 'app-produtividade-digitadores',
  templateUrl: './produtividade-digitadores.component.html',
  styleUrls: ['./produtividade-digitadores.component.css']
})
export class ProdutividadeDigitadoresComponent implements OnInit {
  stringDateInicial: string;
  stringDateFinal: string;

  dataInicial: Date;
  dataFinal: Date;

  viewAtualizar: boolean = false;

  produtividade: Produtividade[];

  constructor(public sepultamentoService: SepultamentoService, private messageService: MessageService) { }

  ngOnInit(): void {
    var d: Date = new Date();
    this.dataInicial = d;
    this.dataFinal = d;
    this.stringDateInicial = this.dataInicial.toLocaleDateString('pt-BR');
    this.stringDateFinal = this.dataFinal.toLocaleDateString('pt-BR');
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
    this.sepultamentoService.listarProdutividade(this.dataInicial, this.dataFinal).subscribe(produtividade => {
      this.produtividade = produtividade;

      if (this.produtividade.length == 1) {
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Infelizmente!', detail: "Nenhum registro encontrado." });
      }

      this.viewAtualizar = false;
    }, (error: any) => {
      this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: error.message });
      this.viewAtualizar = false;
    });
  }

  ver(prod: Produtividade): void {
    this.viewAtualizar = true;
    this.sepultamentoService.downloadPdfProdutividade(prod.Login, this.dataInicial, this.dataFinal).subscribe(arquivoPdf => {
      const blob = new Blob([arquivoPdf], { type: 'application/pdf' });
      const url = window.URL.createObjectURL(blob);
      window.open(url);
      this.viewAtualizar = false;
    }, (error: any) => {
      this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: error.message });
      this.viewAtualizar = false;
    });
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
