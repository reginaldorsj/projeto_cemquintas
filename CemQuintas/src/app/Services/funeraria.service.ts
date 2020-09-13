import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';

import { Funeraria } from '../Models/funeraria';


@Injectable({
  providedIn: 'root'
})
export class FunerariaService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }
  listar(): Observable<Funeraria[]> {
    return this.http
      .get(`${environment.webapiUrl}funeraria/listar`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Funeraria = new Funeraria();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  inserir(funeraria: Funeraria): Observable<Funeraria> {
    return this.http
      .post(`${environment.webapiUrl}funeraria/inserir`, funeraria)
      .pipe(
        map((data: any) => {
          let x: Funeraria = new Funeraria();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  alterar(funeraria: Funeraria): Observable<Funeraria> {
    return this.http
      .put(`${environment.webapiUrl}funeraria/alterar`, funeraria)
      .pipe(
        map((data: any) => {
          let x: Funeraria = new Funeraria();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  excluir(id: number): Observable<any> {
    return this.http
      .delete(`${environment.webapiUrl}funeraria/excluir/${id}`)
      .pipe(catchError((e) => this.errorHandler(e)));
  }
}

