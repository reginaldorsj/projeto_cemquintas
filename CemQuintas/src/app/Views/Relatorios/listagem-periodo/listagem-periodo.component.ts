import { Component, OnInit } from '@angular/core';

import { SepultamentoService } from '../../../Services/sepultamento.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-listagem-periodo',
  templateUrl: './listagem-periodo.component.html',
  styleUrls: ['./listagem-periodo.component.css']
})
export class ListagemPeriodoComponent implements OnInit {
  dataInicial: Date;
  dataFinal: Date;

  stringDateInicial: string;
  stringDateFinal: string;

  viewAtualizar: boolean = false;

  constructor(public sepultamentoService: SepultamentoService, private messageService: MessageService) { }

  ngOnInit(): void {
  }

  listar(): void {
    if (!this.validaPeriodo()) {
      return;
    }

    this.viewAtualizar = true;
    this.sepultamentoService.downloadPdfListagem(this.dataInicial, this.dataFinal).subscribe(arquivoPdf => {
      const blob = new Blob([arquivoPdf], { type: 'application/pdf' });
      const url = window.URL.createObjectURL(blob);
      window.open(url);
      this.viewAtualizar = false;
    }, (error: any) => {
      if (error.blob) {
        const fr = new FileReader();
        fr.onloadend = (e => {
          const errorObj = JSON.parse(fr.result as string);
          this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: errorObj.Message });
          this.viewAtualizar = false;
        });
        fr.readAsText(error.blob, 'utf-8');
      } else {
        this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: error.message });
        this.viewAtualizar = false;
      }
    });
  }

  exportar(): void {
    if (!this.validaPeriodo()) {
      return;
    }

    this.viewAtualizar = true;
    this.sepultamentoService.downloadXlsExportacao(this.dataInicial, this.dataFinal).subscribe(arquivoXls => {
      const blob = new Blob([arquivoXls], { type: 'application/vnd.ms-excel' });
      const url = window.URL.createObjectURL(blob);
      window.open(url);
      this.viewAtualizar = false;
    }, (error: any) => {
        if (error.blob) {
          const fr = new FileReader();
          fr.onloadend = (e => {
            const errorObj = JSON.parse(fr.result as string);
            this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: errorObj.Message });
            this.viewAtualizar = false;
          });
          fr.readAsText(error.blob, 'utf-8');
        } else {
          this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: error.message });
          this.viewAtualizar = false;
        }
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

  private validaPeriodo(): boolean {
    if (!this.dataInicial) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: "Informe a DATA INICIAL." });
    }
    if (!this.dataFinal) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: "Informe a DATA FINAL." });
    }

    if (!this.dataInicial || !this.dataFinal) {
      return false;
    }

    return true;
  }
}
