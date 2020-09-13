import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { MessageService, ConfirmationService } from 'primeng/api/';
import { DocumentoService } from '../../../Services/documentos.service';
import { SexoService } from '../../../Services/sexo.service';
import { RacaService } from '../../../Services/raca.service';
import { SepultamentoService } from '../../../Services/sepultamento.service';
import { UfService } from '../../../Services/uf.service';
import { CartorioService } from '../../../Services/cartorio.service';
import { QuadroService } from '../../../Services/quadro.service';
import { QuadraService } from '../../../Services/quadra.service';
import { ModelService } from '../../../Models/model.service';
import { CidadeService } from '../../../Services/cidade.service';

import { Sepultamento } from '../../../Models/sepultamento';
import { Cidadao } from '../../../Models/cidadao';
import { FunerariaService } from '../../../Services/funeraria.service';
import { Responsavel } from '../../../Models/responsavel';
import { Testemunha } from '../../../Models/testemunha';
import { Cidade } from '../../../Models/cidade';
import { Uf } from '../../../Models/uf';

@Component({
  selector: 'app-inserir-sepultamento',
  templateUrl: './inserir-sepultamento.component.html',
  styleUrls: ['./inserir-sepultamento.component.css']
})
export class InserirSepultamentoComponent implements OnInit {

  quadros = [];
  quadras = [];
  locaisSepultamento = [];
  funerarias = [];
  cartorios = [];
  documentos = [];
  sexos = [];
  racas = [];
  ufs = [];
  complementosIdade = [];

  cidadaoCidade: Cidade;
  cidadaoUf: Uf;
  cidadaoNomeCidade: string;

  responsavel1Cidade: Cidade;
  responsavel1Uf: Uf;
  responsavel1NomeCidade: string;

  responsavel2Cidade: Cidade;
  responsavel2Uf: Uf;
  responsavel2NomeCidade: string;

  stringDateRg: string;
  stringDateExumacao: string;
  stringDateGuia: string;
  stringDateTermo: string;
  stringDateRgR1: string;
  stringDateRgR2: string;
  stringDateDocObito: string;
  stringDateLimite: string;
  stringDateTimeFalecimento: string;
  stringDateTimeSepultamento: string;

  cidadaoIgnorado: boolean;
  sepultamento: Sepultamento;
  gravando: boolean

  constructor(public sepultamentoService: SepultamentoService, private sexoService: SexoService, private cartorioService: CartorioService,
    private ufService: UfService, private documentoService: DocumentoService, private racaService: RacaService,
    private funerariaService: FunerariaService, private quadroService: QuadroService, private quadraService: QuadraService,
    private messageService: MessageService, private confirmationService: ConfirmationService, private cidadeService: CidadeService,
    private activatedRoute: ActivatedRoute, private modelService: ModelService, private router: Router) { }

  ngOnInit(): void {

    this.limparTudo();

    this.gotoTop();

    this.complementosIdade = [
      { label: "ano(s)", value: "ano(s)" },
      { label: "mes(es)", value: "mes(es)" },
      { label: "semana(s)", value: "semana(s)" },
      { label: "dia(s)", value: "dia(s)" },
      { label: "hora(s)", value: "hora(s)" }
    ];

    this.locaisSepultamento = [
      { label: "Cova", value: "1" },
      { label: "Carneira", value: "2" }
    ];

    var promiseDocumento = new Promise((resolve, reject) => {
      this.documentoService.listar().subscribe(documentos => {
        documentos.forEach((documento) => {
          this.documentos.push({ "label": documento.Descricao, "value": documento })
        })
        resolve();
      });
    });
    var promiseSexo = new Promise((resolve, reject) => {
      this.sexoService.listar().subscribe(sexos => {
        sexos.forEach((sexo) => {
          this.sexos.push({ "label": sexo.Descricao, "value": sexo })
        })
        resolve();
      });
    });
    var promiseRaca = new Promise((resolve, reject) => {
      this.racaService.listar().subscribe(racas => {
        racas.forEach((raca) => {
          this.racas.push({ "label": raca.Descricao, "value": raca })
        })
        resolve();
      });
    });
    var promiseUf = new Promise((resolve, reject) => {
      this.ufService.listar().subscribe(ufs => {
        ufs.forEach((uf) => {
          this.ufs.push({ "label": uf.Sigla, "value": uf })
        })
        resolve();
      });
    });
    var promiseCartorio = new Promise((resolve, reject) => {
      this.cartorioService.listar().subscribe(cartorios => {
        cartorios.forEach((cartorio) => {
          this.cartorios.push({ "label": cartorio.Nome, "value": cartorio })
        })
        resolve();
      });
    });
    var promiseFuneraria = new Promise((resolve, reject) => {
      this.funerariaService.listar().subscribe(funerarias => {
        funerarias.forEach((funeraria) => {
          this.funerarias.push({ "label": funeraria.Nome, "value": funeraria })
        })
        resolve();
      });
    });
    var promiseQuadro = new Promise((resolve, reject) => {
      this.quadroService.listar().subscribe(quadros => {
        quadros.forEach((quadro) => {
          this.quadros.push({ "label": quadro.Descricao, "value": quadro })
        })
        resolve();
      });
    });
    var promiseQuadra = new Promise((resolve, reject) => {
      this.quadraService.listar().subscribe(quadras => {
        quadras.forEach((quadra) => {
          this.quadras.push({ "label": quadra.Descricao, "value": quadra })
        })
        resolve();
      });
    });

    Promise.all([promiseDocumento, promiseSexo, promiseRaca, promiseUf, promiseCartorio, promiseFuneraria, promiseQuadro, promiseQuadra])
      .then(([]) => {
        var id: number = this.activatedRoute.snapshot.params['id'];
        if (id) {
          this.sepultamentoService.selecionarPorId(id).subscribe((sepultamento: Sepultamento) => {
            if (!sepultamento.IdSepultamento)
              this.router.navigate(['/page-not-found']);

            if (!sepultamento.Responsavel1)
              sepultamento.Responsavel1 = new Responsavel();
            if (!sepultamento.Responsavel2)
              sepultamento.Responsavel2 = new Responsavel();

            if (!sepultamento.Testemunha1)
              sepultamento.Testemunha1 = new Testemunha();
            if (!sepultamento.Testemunha2)
              sepultamento.Testemunha2 = new Testemunha();

            this.cidadaoCidade = sepultamento.Cidadao.Cidade;

            if (sepultamento.Responsavel1)
              this.responsavel1Cidade = sepultamento.Responsavel1.Cidade;
            if (sepultamento.Responsavel1)
              this.responsavel2Cidade = sepultamento.Responsavel2.Cidade;

            this.sepultamento = sepultamento;
            if (this.sepultamento.Cidadao.DataRg)
              this.stringDateRg = this.sepultamento.Cidadao.DataRg.toLocaleDateString('pt-BR');
            if (this.sepultamento.DataExumacao)
              this.stringDateExumacao = this.sepultamento.DataExumacao.toLocaleDateString('pt-BR');
            if (this.sepultamento.DataGuia)
              this.stringDateGuia = this.sepultamento.DataGuia.toLocaleDateString('pt-BR');
            if (this.sepultamento.DataTermo)
              this.stringDateTermo = this.sepultamento.DataTermo.toLocaleDateString('pt-BR');
            if (this.sepultamento.Responsavel1.DataRg)
              this.stringDateRgR1 = this.sepultamento.Responsavel1.DataRg.toLocaleDateString('pt-BR');
            if (this.sepultamento.Responsavel2.DataRg)
              this.stringDateRgR2 = this.sepultamento.Responsavel2.DataRg.toLocaleDateString('pt-BR');
            if (this.sepultamento.DataDocumentoObito)
              this.stringDateDocObito = this.sepultamento.DataDocumentoObito.toLocaleDateString('pt-BR');
            if (this.sepultamento.DataLimite)
              this.stringDateLimite = this.sepultamento.DataLimite.toLocaleDateString('pt-BR');
            if (this.sepultamento.DataHoraFalecimento)
              this.stringDateTimeFalecimento = this.sepultamento.DataHoraFalecimento.toLocaleString('pt-BR').substring(0, 16);
            if (this.sepultamento.DataHoraSepultamento)
              this.stringDateTimeSepultamento = this.sepultamento.DataHoraSepultamento.toLocaleString('pt-BR').substring(0, 16);

            this.cidadaoIgnorado = (this.sepultamento.Cidadao.Nome == 'IGNORADO');
          });
        }
      });
  }

  limparTudo(): void {
    this.gravando = false;
    this.cidadaoIgnorado = false;

    this.sepultamento = new Sepultamento();
    this.sepultamento.Cidadao = new Cidadao();
    this.sepultamento.Responsavel1 = new Responsavel();
    this.sepultamento.Responsavel2 = new Responsavel();
    this.sepultamento.Testemunha1 = new Testemunha();
    this.sepultamento.Testemunha2 = new Testemunha();

    this.stringDateExumacao = undefined;
    this.stringDateRg = undefined;
    this.stringDateGuia = undefined;
    this.stringDateDocObito = undefined;
    this.stringDateRgR1 = undefined;
    this.stringDateRgR2 = undefined;
    this.stringDateTermo = undefined;
    this.stringDateLimite = undefined;
    this.stringDateTimeSepultamento = undefined;
    this.stringDateTimeFalecimento = undefined;

    this.responsavel1Cidade = undefined;
    this.responsavel2Cidade = undefined;
    this.cidadaoCidade = undefined;
  }

  inserir(): void {
    this.limparTudo();
  }

  gravar(): void {
    this.gravando = true;

    var promisseCidadao = new Promise((resolve, reject) => {
      if (this.cidadaoUf != undefined && (this.cidadaoNomeCidade != undefined && this.cidadaoNomeCidade != '')) {
        this.cidadeService.selecionar(this.cidadaoUf.Sigla, this.cidadaoNomeCidade).subscribe(cidade => {
          resolve(cidade);
        });
      } else {
        resolve(null);
      }
    });

    var promisseResponsavel1 = new Promise((resolve, reject) => {
      if (this.responsavel1Uf != undefined && (this.responsavel1NomeCidade != undefined && this.responsavel1NomeCidade != '')) {
        this.cidadeService.selecionar(this.responsavel1Uf.Sigla, this.responsavel1NomeCidade).subscribe(cidade => {
          resolve(cidade);
        });
      } else {
        resolve(null);
      }
    });

    var promisseResponsavel2 = new Promise((resolve, reject) => {
      if (this.responsavel2Uf != undefined && (this.responsavel2NomeCidade != undefined && this.responsavel2NomeCidade != '')) {
        this.cidadeService.selecionar(this.responsavel2Uf.Sigla, this.responsavel2NomeCidade).subscribe(cidade => {
          resolve(cidade);
        });
      } else {
        resolve(null);
      }
    });


    Promise.all([promisseCidadao, promisseResponsavel1, promisseResponsavel2])
      .then(([cidadeCidadao, cidadeResponsavel1, cidadeResponsavel2]) => {
        this.sepultamento.Cidadao.Cidade = cidadeCidadao as Cidade;
        this.sepultamento.Responsavel1.Cidade = cidadeResponsavel1 as Cidade;
        this.sepultamento.Responsavel2.Cidade = cidadeResponsavel2 as Cidade;

        if (!this.sepultamento.IdSepultamento) {
          this.sepultamentoService.inserir(this.sepultamento).subscribe(sepultamento => {
            this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Inclusão realizada com sucesso.' });
            this.sepultamento = sepultamento;
            this.setNotNull();
          }, null, () => { this.gravando = false; });
        } else {
          this.sepultamentoService.alterar(this.sepultamento).subscribe(sepultamento => {
            this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Alteração realizada com sucesso.' });
            this.sepultamento = sepultamento;
            this.setNotNull();
          }, null, () => { this.gravando = false; });
        }
      });
  }

  reiniciar(): void {
    this.confirmationService.confirm({
      message: 'Deseja limpar tudo e reiniciar a digitação?',
      accept: () => {
        this.router.navigate(['/sepultamento/inserir']);
      }
    });
  }

  excluir(): void {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão do registro?',
      accept: () => {
        this.sepultamentoService.excluir(this.sepultamento.IdSepultamento).subscribe(sepultamento => {
          this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Exclusão realizada com sucesso.' });
          this.limparTudo();
          var x = setInterval(() => {
            this.router.navigate(['/sepultamento/inserir']);
            clearInterval(x);
          }, 1000)
        }, null, () => { this.gravando = false; });
      }
    });
  }

  recebeCidadaoNomeCidade(nomeCidade: string): void {
    this.cidadaoNomeCidade = nomeCidade;
  }

  recebeCidadaoUf(uf: Uf): void {
    this.cidadaoUf = uf;
  }

  recebeResponsavel1NomeCidade(nomeCidade: string): void {
    this.responsavel1NomeCidade = nomeCidade;
  }

  recebeResponsavel1Uf(uf: Uf): void {
    this.responsavel1Uf = uf;
  }

  recebeResponsavel2NomeCidade(nomeCidade: string): void {
    this.responsavel2NomeCidade = nomeCidade;
  }

  recebeResponsavel2Uf(uf: Uf): void {
    this.responsavel2Uf = uf;
  }

  recebeDataExumacao(date: Date) {
    if (date)
      this.stringDateExumacao = date.toLocaleDateString('pt-BR');
    else
      this.stringDateExumacao = undefined;
    this.sepultamento.DataExumacao = date;
  }

  recebeDataRg(date: Date) {
    if (date)
      this.stringDateRg = date.toLocaleDateString('pt-BR');
    else
      this.stringDateRg = undefined;
    this.sepultamento.Cidadao.DataRg = date;
  }

  recebeDataGuia(date: Date) {
    if (date)
      this.stringDateGuia = date.toLocaleDateString('pt-BR');
    else
      this.stringDateGuia = undefined;
    this.sepultamento.DataGuia = date;
  }

  recebeDataTermo(date: Date) {
    if (date)
      this.stringDateTermo = date.toLocaleDateString('pt-BR');
    else
      this.stringDateTermo = undefined;
    this.sepultamento.DataTermo = date;
  }

  recebeDataLimite(date: Date) {
    if (date)
      this.stringDateLimite = date.toLocaleDateString('pt-BR');
    else
      this.stringDateLimite = undefined;
    this.sepultamento.DataLimite = date;
  }

  recebeDataRgR1(date: Date) {
    if (date)
      this.stringDateRgR1 = date.toLocaleDateString('pt-BR');
    else
      this.stringDateRgR1 = undefined;
    this.sepultamento.Responsavel1.DataRg = date;
  }

  recebeDataRgR2(date: Date) {
    if (date)
      this.stringDateRgR2 = date.toLocaleDateString('pt-BR');
    else
      this.stringDateRgR2 = undefined;
    this.sepultamento.Responsavel2.DataRg = date;
  }
  recebeDataDocObito(date: Date) {
    if (date)
      this.stringDateDocObito = date.toLocaleDateString('pt-BR');
    else
      this.stringDateDocObito = undefined;
    this.sepultamento.DataDocumentoObito = date;
  }

  imprimir(): void {
    if (this.sepultamento.Documento.IdDocumento == 1)
      this.router.navigate([`/sepultamento/impressao-termo/${this.sepultamento.IdSepultamento}`]);
    else
      this.router.navigate([`/sepultamento/impressao-sepultamento/${this.sepultamento.IdSepultamento}`]);
  }

  recebeDataHoraFalecimento(date: Date) {
    if (date)
      this.stringDateTimeFalecimento = date.toLocaleString('pt-BR').substring(0, 16);
    else
      this.stringDateTimeFalecimento = undefined;
    this.sepultamento.DataHoraFalecimento = date;
  }

  recebeDataHoraSepultamento(date: Date) {
    if (date)
      this.stringDateTimeSepultamento = date.toLocaleString('pt-BR').substring(0, 16);
    else
      this.stringDateTimeSepultamento = undefined;
    this.sepultamento.DataHoraSepultamento = date;
  }

  exumar(): void {
    this.router.navigate([`/sepultamento/exumacao/${this.sepultamento.IdSepultamento}`]);
  }

  changeIgnorado(): void {
    if (this.cidadaoIgnorado == true) {
      this.sepultamento.Cidadao.Nome = 'IGNORADO';
    }
  }

  private setNotNull(): void {
    if (!this.sepultamento.Responsavel1)
      this.sepultamento.Responsavel1 = new Responsavel();
    if (!this.sepultamento.Responsavel2)
      this.sepultamento.Responsavel2 = new Responsavel();
    if (!this.sepultamento.Testemunha1)
      this.sepultamento.Testemunha1 = new Testemunha();
    if (!this.sepultamento.Testemunha2)
      this.sepultamento.Testemunha2 = new Testemunha();
  }

  private gotoTop(): void {
    //window.scroll(0, 0);
    let scrollToTop = window.setInterval(() => {
      let pos = window.pageYOffset;
      if (pos > 0) {
        window.scrollTo(0, pos - 50); // how far to scroll on each step
      } else {
        window.clearInterval(scrollToTop);
      }
    }, 16);
  }
}
