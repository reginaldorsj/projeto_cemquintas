import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';

import { Cidade } from '../Models/cidade';
import { MessageService } from 'primeng/api';
import { Uf } from '../Models/uf';


@Injectable({
  providedIn: 'root'
})
export class CidadeService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }

  listar(siglaUf:string, nomeCidade:string): Observable<Cidade[]> {
    return this.http
      .get(`${environment.webapiUrl}cidade/listar/${siglaUf}/${nomeCidade}`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Cidade = new Cidade();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  selecionar(siglaUf: string, nomeCidade: string): Observable<Cidade> {
    return this.http
      .get(`${environment.webapiUrl}cidade/selecionar/${siglaUf}/${nomeCidade}`)
      .pipe(
        map((data: any) => {
            let x: Cidade = new Cidade();
            this.model.deepCopy(data, x);
            return x
          }), catchError((e) => this.errorHandler(e))
      );
  }
}
