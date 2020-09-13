import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';

import { Quadro } from '../Models/quadro';


@Injectable({
  providedIn: 'root'
})
export class QuadroService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }
  listar(): Observable<Quadro[]> {
    return this.http
      .get(`${environment.webapiUrl}quadro/listar`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Quadro = new Quadro();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  inserir(quadro: Quadro): Observable<Quadro> {
    return this.http
      .post(`${environment.webapiUrl}quadro/inserir`, quadro)
      .pipe(
        map((data: any) => {
          let x: Quadro = new Quadro();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  alterar(quadro: Quadro): Observable<Quadro> {
    return this.http
      .put(`${environment.webapiUrl}quadro/alterar`, quadro)
      .pipe(
        map((data: any) => {
          let x: Quadro = new Quadro();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  excluir(id: number): Observable<any> {
    return this.http
      .delete(`${environment.webapiUrl}quadro/excluir/${id}`)
      .pipe(catchError((e) => this.errorHandler(e)));
  }
}

