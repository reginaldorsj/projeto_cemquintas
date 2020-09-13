import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { SepultamentoService } from '../../../Services/sepultamento.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ModelService } from '../../../Models/model.service';
import { CidadeService } from '../../../Services/cidade.service';
import { ExumacaoService } from '../../../Services/exumacao.service';
import { UfService } from '../../../Services/uf.service';

import { Sepultamento } from '../../../Models/sepultamento';
import { Exumacao } from '../../../Models/exumacao';
import { Cidade } from '../../../Models/cidade';
import { Uf } from '../../../Models/uf';
import { Cidadao } from '../../../Models/cidadao';

@Component({
  selector: 'app-exumacao',
  templateUrl: './exumacao.component.html',
  styleUrls: ['./exumacao.component.css']
})
export class ExumacaoComponent implements OnInit {

  id: number;
  exumacao: Exumacao;

  ufs = [];

  cidade: Cidade;
  nomeCidade: string;
  uf: Uf;

  constructor(public sepultamentoService: SepultamentoService, private router: Router, private activatedRoute: ActivatedRoute,
    private ufService: UfService, private confirmationService: ConfirmationService, private modelService: ModelService,
    private cidadeService: CidadeService, private exumacaoService: ExumacaoService, private messageService: MessageService) { }

  ngOnInit(): void {

    this.exumacao = new Exumacao();
    this.exumacao.Sepultamento = new Sepultamento();
    this.exumacao.Sepultamento.Cidadao = new Cidadao();

    this.gotoTop();

    Promise.resolve(() => {
      this.ufService.listar().subscribe(ufs => {
        ufs.forEach((uf) => {
          this.ufs.push({ "label": uf.Sigla, "value": uf })
        })
      });
    }).then(() => {
      this.id = this.activatedRoute.snapshot.params['id'];
      if (this.id) {
        this.exumacaoService.selecionarPorSepultamento(this.id).subscribe((exumacao: Exumacao) => {
          if (exumacao != null) {
            this.exumacao = exumacao;
            this.cidade = this.exumacao.Cidade;
          } else {
            this.sepultamentoService.selecionarPorId(this.id).subscribe((sepultamento: Sepultamento) => {
              if (sepultamento != null)
                this.exumacao.Sepultamento = sepultamento;
              else
                this.router.navigate(['/sepultamento/inserir']);
            });
          }
        });
      }
    });
  }

  gotoTop(): void {
    window.scroll(0, 0);
  }

  gravar(): void {
    this.exumacao.Data = this.modelService.convertTimeZone(this.exumacao.Data);
    this.exumacao.DataExpedicaoRg = this.modelService.convertTimeZone(this.exumacao.DataExpedicaoRg);

    var promisse = new Promise((resolve, reject) => {
      if (this.uf != undefined && (this.nomeCidade != undefined && this.nomeCidade != '')) {
        this.cidadeService.selecionar(this.uf.Sigla, this.nomeCidade).subscribe(cidade => {
          resolve(cidade);
        });
      } else {
        resolve(null);
      }
    });

    promisse.then(cidade => {
      this.exumacao.Cidade = cidade as Cidade;

      if (!this.exumacao.IdExumacao) {
        this.exumacaoService.inserir(this.exumacao).subscribe(exumacao => {
          this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Inclusão realizada com sucesso.' });
          this.exumacao = exumacao;
        });
      } else {
        this.exumacaoService.alterar(this.exumacao).subscribe(exumacao => {
          this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Alteração realizada com sucesso.' });
          this.exumacao = exumacao;
        });
      }
    });
  }

  excluir(): void {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão do registro?',
      accept: () => {
        this.exumacaoService.excluir(this.exumacao.IdExumacao).subscribe(exumacao => {
          this.router.navigate([`/sepultamento/alterar/${this.exumacao.Sepultamento.IdSepultamento}`]);
        });
      }
    });
  }

  imprimir(): void {
    this.router.navigate([`/sepultamento/exumacao/impressao/${this.exumacao.Sepultamento.IdSepultamento}`]);
  }

  voltar(): void {
    this.confirmationService.confirm({
      message: 'Deseja retornar para o sepultamento?',
      accept: () => {
        this.router.navigate([`/sepultamento/alterar/${this.exumacao.Sepultamento.IdSepultamento}`]);
      }
    });
  }

  recebeNomeCidade(nomeCidade: string): void {
    this.nomeCidade = nomeCidade;
  }

  recebeUf(uf: Uf): void {
    this.uf = uf;
  }
}
