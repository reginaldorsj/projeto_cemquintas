import { Component, OnInit, Input, SimpleChanges, EventEmitter, Output } from '@angular/core';

import { UfService } from '../../Services/uf.service';
import { CidadeService } from '../../Services/cidade.service';
import { MessageService } from 'primeng/api';

import { Uf } from '../../Models/uf';
import { Cidade } from '../../Models/cidade';

@Component({
  selector: 'app-uf-cidade',
  templateUrl: './uf-cidade.component.html',
  styleUrls: ['./uf-cidade.component.css']
})
export class UfCidadeComponent implements OnInit {

  @Input() cidade: Cidade;

  @Output() ufEnviada = new EventEmitter();
  @Output() nomeCidadeEnviada = new EventEmitter();

  uf: Uf;
  nomeCidade: string;

  ufs = [];
  cidades = [];

  constructor(private ufService: UfService, private cidadeService: CidadeService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.ufService.listar().subscribe(ufs => {
      ufs.forEach((uf) => {
        this.ufs.push({ "label": uf.Sigla, "value": uf })
      })

      if (this.uf) {
        let x = this.ufs.find(x => x.value.IdUf == this.uf.IdUf);
        this.uf = x.value;
      }
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.nomeCidade = undefined;
    this.changeNomeCidade();
    this.uf = undefined;
    this.changeUf();

    if (changes.cidade.currentValue != undefined) {
      this.nomeCidade = changes.cidade.currentValue.Descricao;
      this.changeNomeCidade();
      this.uf = changes.cidade.currentValue.Uf;
      this.changeUf();
    }
    else {
      this.cidades = [];
    }
  }

  pesquisar(): void {
    if (this.uf == undefined) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: 'Selecione a UF.' });
      this.cidades = [];
      return;
    }

    if (this.nomeCidade == undefined || this.nomeCidade.length == 0) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: 'Informe o nome da cidade que deseja pesquisar.' });
      this.cidades = [];
      return;
    }

    this.cidadeService.listar(this.uf.Sigla, this.nomeCidade).subscribe(cidades => {
      this.cidades = cidades;
    });
  }

  selecionar(): void {
    this.nomeCidade = this.cidade.Descricao;
    this.changeNomeCidade();
    this.cidades = [];
  }

  changeNomeCidade(): void {
    this.nomeCidadeEnviada.emit(this.nomeCidade);
  }
  changeUf(): void {
    this.ufEnviada.emit(this.uf);
  }
}
