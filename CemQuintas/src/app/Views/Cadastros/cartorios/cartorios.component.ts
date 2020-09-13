import { Component, OnInit, SimpleChanges } from '@angular/core';

import { MessageService, ConfirmationService } from 'primeng/api';
import { CartorioService } from '../../../Services/cartorio.service';
import { TipoLogradouroService } from '../../../Services/tipo-logradouro.service';
import { CidadeService } from '../../../Services/cidade.service';

import { Cartorio } from '../../../Models/cartorio';
import { Cidade } from '../../../Models/cidade';
import { Uf } from '../../../Models/uf';


@Component({
  selector: 'app-cartorios',
  templateUrl: './cartorios.component.html',
  styleUrls: ['./cartorios.component.css']
})
export class CartoriosComponent implements OnInit {

  view: string = "browse";
  cartorio: Cartorio;

  cartorios: Cartorio[];
  tiposLogradouros = [];

  viewAtualizar: boolean = false;

  uf: Uf;
  nomeCidade: string;
  cidade: Cidade;

  constructor(private cartorioService: CartorioService, private messageService: MessageService,
    private confirmationService: ConfirmationService, private tipoLogradouroService: TipoLogradouroService,
    private cidadeService: CidadeService) { }

  ngOnInit(): void {
    this.tipoLogradouroService.listar().subscribe(tiposlogradouros => {
      tiposlogradouros.forEach((tipoLogradouro) => {
        this.tiposLogradouros.push({ "label": tipoLogradouro.Descricao, "value": tipoLogradouro })
      })
    });

    this.atualizar();

    this.cartorio = new Cartorio();
  }

  atualizar(): void {
    this.viewAtualizar = true;
    this.cartorioService.listar().subscribe(cartorios => {
      this.cartorios = cartorios;
      this.viewAtualizar = false;
    });
  }

  desistir(): void {
    this.view = "browse";

    this.cidade = undefined;
    this.atualizar();
  }

  inserir(): void {
    this.view = "insert";
    this.cartorio = new Cartorio();
  }

  gravar(): void {
    var promisse = new Promise((resolve, reject) => {
      if (this.uf != undefined && (this.nomeCidade != undefined && this.nomeCidade != '')) {
        this.cidadeService.selecionar(this.uf.Sigla, this.nomeCidade).subscribe(cidade => {
          resolve(cidade);
        });
      } else {
        resolve(null);
      }
    });

    promisse.then((cidade: Cidade) => {
      this.cartorio.Cidade = cidade;

      if (this.cartorio.IdCartorio == undefined) {
        this.cartorioService.inserir(this.cartorio).subscribe(cartorio => {
          this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Inclusão realizada com sucesso.' });
          this.atualizar();
          this.desistir();
        });
      } else {
        this.cartorioService.alterar(this.cartorio).subscribe(cartorio => {
          this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Alteração realizada com sucesso.' });
          this.atualizar();
          this.desistir();
        });
      }
    })
  }

  excluir(cartorio: Cartorio) {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão?',
      rejectLabel: "Não",
      acceptLabel: "Sim",
      accept: () => {
        this.cartorioService.excluir(cartorio.IdCartorio).subscribe(() => {
          this.atualizar();
        });
      }
    });
  }
  alterar(cartorio: Cartorio): void {
    this.view = "insert";
    this.cartorio = cartorio;

    this.cidade = cartorio.Cidade;
  }

  recebeNomeCidade(nomeCidade: string): void {
    this.nomeCidade = nomeCidade;
  }

  recebeUf(uf: Uf): void {
    this.uf = uf;
  }
}
