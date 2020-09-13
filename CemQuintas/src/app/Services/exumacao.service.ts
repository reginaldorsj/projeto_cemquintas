import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';

import { Exumacao } from '../Models/exumacao';


@Injectable({
  providedIn: 'root'
})
export class ExumacaoService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }
  inserir(exumacao: Exumacao): Observable<Exumacao> {
    return this.http
      .post(`${environment.webapiUrl}exumacao/inserir`, exumacao)
      .pipe(
        map((data: any) => {
          let x: Exumacao = new Exumacao();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  alterar(exumacao: Exumacao): Observable<Exumacao> {
    return this.http
      .put(`${environment.webapiUrl}exumacao/alterar`, exumacao)
      .pipe(
        map((data: any) => {
          let x: Exumacao = new Exumacao();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  excluir(id: number): Observable<any> {
    return this.http
      .delete(`${environment.webapiUrl}exumacao/excluir/${id}`)
      .pipe(catchError((e) => this.errorHandler(e)));
  }
  selecionarPorSepultamento(idSepultamento: number): Observable<Exumacao> {
    return this.http
      .get(`${environment.webapiUrl}exumacao/selecionarporsepultamento/${idSepultamento}`)
      .pipe(
        map((data: any) => {
          if (data != null) {
            let x: Exumacao = new Exumacao();
            this.model.deepCopy(data, x);
            return x
          } else
            return data;
        }), catchError((e) => this.errorHandler(e))
      );
  }
}

