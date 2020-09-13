import { Component, OnInit } from '@angular/core';

import { SepultamentoService } from '../../../Services/sepultamento.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-listagem-faixa',
  templateUrl: './listagem-faixa.component.html',
  styleUrls: ['./listagem-faixa.component.css']
})
export class ListagemFaixaComponent implements OnInit {
  ano: number;
  numeroInicial: number;
  numeroFinal: number;
  viewAtualizar: boolean = false;

  constructor(public sepultamentoService: SepultamentoService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.ano = new Date().getFullYear();
  }

  listar(): void {
    if (!this.ano) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: "Informe a ANO." });
    }
    if (!this.numeroInicial) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: "Informe a NÚMERO DE CONTROLE INICIAL." });
    }
    if (!this.numeroFinal) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: "Informe a NÚMERO DE CONTROLE FINAL." });
    }

    if (!this.ano || !this.numeroInicial || !this.numeroFinal) {
      return;
    }

    this.viewAtualizar = true;
    this.sepultamentoService.downloadPdfListagem2(this.ano, this.numeroInicial, this.numeroFinal).subscribe(arquivoPdf => {
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
}
