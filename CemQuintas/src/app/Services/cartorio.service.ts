import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';

import { Cartorio } from '../Models/cartorio';

@Injectable({
  providedIn: 'root'
})
export class CartorioService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }
  listar(): Observable<Cartorio[]> {
    return this.http
      .get(`${environment.webapiUrl}cartorio/listar`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Cartorio = new Cartorio();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  inserir(cartorio: Cartorio): Observable<Cartorio> {
    return this.http
      .post(`${environment.webapiUrl}cartorio/inserir`, cartorio)
      .pipe(
        map((item: any) => {
          let x: Cartorio = new Cartorio();
          this.model.deepCopy(item, x);
          return x
        }), catchError((e) => this.errorHandler(e) )
      );
  }
  excluir(id: number): Observable<any> {
    return this.http
      .delete(`${environment.webapiUrl}cartorio/excluir/${id}`)
      .pipe(catchError((e) => this.errorHandler(e)));
  }
  alterar(cartorio: Cartorio): Observable<Cartorio> {
    return this.http
      .put(`${environment.webapiUrl}cartorio/alterar`, cartorio)
      .pipe(
        map((item: any) => {
          let x: Cartorio = new Cartorio();
          this.model.deepCopy(item, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }

}
