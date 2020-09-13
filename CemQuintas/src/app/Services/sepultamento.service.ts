import { DatePipe } from '@angular/common';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';
import { TotalAnual } from '../Models/total-anual';
import { Sepultamento } from '../Models/sepultamento';
import { Produtividade } from '../Models/produtividade';
import { Pesquisa } from '../Models/pesquisa';

@Injectable({
  providedIn: 'root'
})
export class SepultamentoService {

  br = {
    firstDayOfWeek: 0,
    dayNames: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"],
    dayNamesShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"],
    dayNamesMin: ["Do", "Se", "Te", "Qua", "Qui", "Se", "Sa"],
    monthNames: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
    monthNamesShort: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
    today: 'Hoje',
    clear: 'Limpar',
    dateFormat: 'dd/mm/yy',
    weekHeader: 'SM'
  };

  constructor(private httpClient: HttpClient, private model: ModelService, private messageService: MessageService,
    public datepipe: DatePipe) {

  }

  get Br() {
    return this.br;
  }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }

  selecionarPorId(id: number): Observable<Sepultamento> {
    return this.httpClient
      .get(`${environment.webapiUrl}sepultamento/selecionarporid/${id}`)
      .pipe(
        map((data: any) => {

          if (data == null)
            return null;

          let x: Sepultamento = new Sepultamento();
          this.model.deepCopy(data, x);
          return x;
        }), catchError((e) => this.errorHandler(e))
      );
  }

  listarMapa(): Observable<TotalAnual[]> {
    return this.httpClient
      .get(`${environment.webapiUrl}sepultamento/totais`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: TotalAnual = new TotalAnual();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }

  listarPorNome(nome: string, page: number): Observable<Pesquisa[]> {
    return this.httpClient
      .get(`${environment.webapiUrl}sepultamento/pesquisarpornome/${nome}/${page}`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Pesquisa = new Pesquisa();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => { throw e })
      );
  }

  listarPorNumeroIml(numeroIml: string, page: number): Observable<Pesquisa[]> {
    return this.httpClient
      .get(`${environment.webapiUrl}sepultamento/pesquisarpornumeroiml/${numeroIml}/${page}`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Pesquisa = new Pesquisa();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => { throw e })
      );
  }

  listarTermosDataLimite(dataInicial: Date, dataFinal: Date): Observable<Sepultamento[]> {
    var di = this.datepipe.transform(dataInicial, 'yyyy-MM-dd');
    var df = this.datepipe.transform(dataFinal, 'yyyy-MM-dd');
    return this.httpClient
      .get(`${environment.webapiUrl}sepultamento/termosdatalimite/${di}/${df}`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Sepultamento = new Sepultamento();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => { throw e })
      );
  }
  listarProdutividade(dataInicial: Date, dataFinal: Date): Observable<Produtividade[]> {
    var di = this.datepipe.transform(dataInicial, 'yyyy-MM-dd');
    var df = this.datepipe.transform(dataFinal, 'yyyy-MM-dd');
    return this.httpClient
      .get(`${environment.webapiUrl}sepultamento/produtividade/${di}/${df}`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Produtividade = new Produtividade();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => { throw e })
      );
  }

  downloadPdfProdutividade(login: string, dataInicial: Date, dataFinal: Date): Observable<Blob> {
    var di = this.datepipe.transform(dataInicial, 'yyyy-MM-dd');
    var df = this.datepipe.transform(dataFinal, 'yyyy-MM-dd');

    return this.httpClient
      .get(`${environment.webapiUrl}sepultamento/produtividade/${login}/${di}/${df}`, { responseType: 'blob' })
      .pipe(
        map((data: any) => {
          return data;
        }), catchError((e) => { throw e })
      );
  }
  downloadPdfListagem(dataInicial: Date, dataFinal: Date): Observable<Blob> {
    var di = this.datepipe.transform(dataInicial, 'yyyy-MM-dd');
    var df = this.datepipe.transform(dataFinal, 'yyyy-MM-dd');
    return this.httpClient
      .get(`${environment.webapiUrl}sepultamento/listagem/${di}/${df}`, { responseType: 'blob' })
      .pipe(
        map((data: any) => {
          return data;
        }), catchError((e) => { throw e })
      );
  }
  downloadPdfListagem2(ano: number, numeroControleInicial: number, numeroControleFinal: number): Observable<Blob> {
    return this.httpClient
      .get(`${environment.webapiUrl}sepultamento/listagem/${ano}/${numeroControleInicial}/${numeroControleFinal}`, { responseType: 'blob' })
      .pipe(
        map((data: any) => {
          return data;
        }), catchError((e) => { throw e })
      );
  }
  downloadXlsExportacao(dataInicial: Date, dataFinal: Date): Observable<Blob> {
    var di = this.datepipe.transform(dataInicial, 'yyyy-MM-dd');
    var df = this.datepipe.transform(dataFinal, 'yyyy-MM-dd');

    return this.httpClient
      .get(`${environment.webapiUrl}sepultamento/exportacao/${di}/${df}`, { responseType: 'blob' })
      .pipe(
        map((data: any) => {
          return data;
        }), catchError((e) => { throw e })
      );
  }
  inserir(sepultamento: Sepultamento): Observable<Sepultamento> {
    return this.httpClient
      .post(`${environment.webapiUrl}sepultamento/inserir`, this.updateTimeZone(sepultamento))
      .pipe(
        map((data: any) => {
          let x: Sepultamento = new Sepultamento();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  alterar(sepultamento: Sepultamento): Observable<Sepultamento> {
    return this.httpClient
      .put(`${environment.webapiUrl}sepultamento/alterar`, this.updateTimeZone(sepultamento))
      .pipe(
        map((data: any) => {
          let x: Sepultamento = new Sepultamento();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  excluir(id: number): Observable<any> {
    return this.httpClient
      .delete(`${environment.webapiUrl}sepultamento/excluir/${id}`)
      .pipe(catchError((e) => this.errorHandler(e)));
  }

  private updateTimeZone(sepultamento: Sepultamento): Sepultamento {
    sepultamento.Cidadao.DataRg = this.model.convertTimeZone(sepultamento.Cidadao.DataRg);
    sepultamento.DataDocumentoObito = this.model.convertTimeZone(sepultamento.DataDocumentoObito);
    sepultamento.DataExumacao = this.model.convertTimeZone(sepultamento.DataExumacao);
    sepultamento.DataGuia = this.model.convertTimeZone(sepultamento.DataGuia);
    sepultamento.DataHoraFalecimento = this.model.convertTimeZone(sepultamento.DataHoraFalecimento);
    sepultamento.DataHoraInclusao = this.model.convertTimeZone(sepultamento.DataHoraInclusao);
    sepultamento.DataHoraSepultamento = this.model.convertTimeZone(sepultamento.DataHoraSepultamento);
    sepultamento.DataHoraUltimaAlteracao = this.model.convertTimeZone(sepultamento.DataHoraUltimaAlteracao);
    sepultamento.DataLimite = this.model.convertTimeZone(sepultamento.DataLimite);
    sepultamento.DataTermo = this.model.convertTimeZone(sepultamento.DataTermo);
    sepultamento.Responsavel1.DataRg = this.model.convertTimeZone(sepultamento.Responsavel1.DataRg);
    sepultamento.Responsavel2.DataRg = this.model.convertTimeZone(sepultamento.Responsavel2.DataRg);
    return sepultamento;
  }
}


