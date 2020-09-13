import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';

import { Quadra } from '../Models/quadra';


@Injectable({
  providedIn: 'root'
})
export class QuadraService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }
  listar(): Observable<Quadra[]> {
    return this.http
      .get(`${environment.webapiUrl}quadra/listar`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Quadra = new Quadra();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  inserir(quadra: Quadra): Observable<Quadra> {
    return this.http
      .post(`${environment.webapiUrl}quadra/inserir`, quadra)
      .pipe(
        map((data: any) => {
          let x: Quadra = new Quadra();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  alterar(quadra: Quadra): Observable<Quadra> {
    return this.http
      .put(`${environment.webapiUrl}quadra/alterar`, quadra)
      .pipe(
        map((data: any) => {
          let x: Quadra = new Quadra();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  excluir(id: number): Observable<any> {
    return this.http
      .delete(`${environment.webapiUrl}quadra/excluir/${id}`)
      .pipe(catchError((e) => this.errorHandler(e)));
  }
}

