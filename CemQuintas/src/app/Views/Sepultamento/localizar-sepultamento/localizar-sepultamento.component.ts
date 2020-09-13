import { Component, OnInit } from '@angular/core';

import { SepultamentoService } from '../../../Services/sepultamento.service';
import { MessageService } from 'primeng/api';

import { Sepultamento } from '../../../Models/sepultamento';
import { Pesquisa } from '../../../Models/pesquisa';
import { Router } from '@angular/router';

@Component({
  selector: 'app-localizar-sepultamento',
  templateUrl: './localizar-sepultamento.component.html',
  styleUrls: ['./localizar-sepultamento.component.css']
})
export class LocalizarSepultamentoComponent implements OnInit {

  pagina: number;
  sepultamentos: Pesquisa[];

  pesquisando: boolean;

  pesquisarPor: string;
  dado: string
  opcoes = [];

  constructor(private sepultamentoService: SepultamentoService, private messageService: MessageService, private router: Router) { }

  ngOnInit(): void {
    this.pesquisando = false;

    this.opcoes = [
      { label: "Nome", value: "0" },
      { label: "Número IML", value: "1" },
    ];
  }

  pesquisar(): void {

    this.sepultamentos = [];
    this.pagina = -1;

    this.executarPesquisa();
  }

  alterar(pesquisa: Pesquisa): void {
    this.router.navigate([`/sepultamento/alterar/${pesquisa.IdSepultamento}`]);

  }

  executarPesquisa(): void {
    if (!this.pesquisarPor || !this.dado || this.dado=='') {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: "Selecione a tipo de pesquisa e informe o dado." });
      return;
    }

    this.pesquisando = true;
    if (this.pesquisarPor == '0') {
      this.sepultamentoService.listarPorNome(this.dado, this.pagina).subscribe((sepultamentos: Pesquisa[]) => {
        this.sepultamentos.push(...sepultamentos);
        this.pesquisando = false;
      }, (error: any) => {
        this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: error.message });
        this.pesquisando = false;
      });
    } else if (this.pesquisarPor == '1') {
      this.sepultamentoService.listarPorNumeroIml(this.dado, this.pagina).subscribe((sepultamentos: Pesquisa[]) => {
        this.sepultamentos.push(...sepultamentos);
        this.pesquisando = false;
      }, (error: any) => {
        this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: error.message });
        this.pesquisando = false;
      });
    }
  }

  onScroll(): void {
    this.pagina++;

    this.executarPesquisa();
  }
}
