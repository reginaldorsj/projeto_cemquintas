import { Injectable } from '@angular/core';

import { Cartorio } from './cartorio';
import { Cidadao } from './cidadao';
import { Cidade } from './cidade';
import { Documento } from './documento';
import { Exumacao } from './exumacao';
import { Perfil } from './perfil';
import { Quadra } from './quadra';
import { Quadro } from './quadro';
import { Raca } from './raca';
import { Responsavel } from './responsavel';
import { Sepultamento } from './sepultamento';
import { Sexo } from './sexo';
import { Testemunha } from './testemunha';
import { TipoLogradouro } from './tipo-logradouro';
import { Uf } from './uf';
import { Usuario } from './usuario';
import { Funeraria } from './funeraria';

@Injectable({
  providedIn: 'root'
})
export class ModelService {

  private classes = {
    Funeraria,
    Cartorio,
    Cidadao,
    Cidade,
    Documento,
    Exumacao,
    Perfil,
    Quadra,
    Quadro,
    Raca,
    Responsavel,
    Sepultamento,
    Sexo,
    Testemunha,
    TipoLogradouro,
    Uf,
    Usuario
  };

  constructor() { }

  convertTimeZone(date: Date): Date {
    if (date)
      return new Date(date.getTime() - (date.getTimezoneOffset() * 60000));
    return date;
  }

  deepCopy(sourceObject, destinationObject) {
    for (const key in sourceObject) {
      if (typeof sourceObject[key] != 'object') {
        destinationObject[key] = sourceObject[key];
      } else if (sourceObject[key] != null && sourceObject[key] != undefined) {
        let keys: string[] = Object.keys(sourceObject[key]);
        destinationObject[key] = this.get(keys[0]);
        this.deepCopy(sourceObject[key], destinationObject[key]);
      }
    }
  }

  protected get(_id_classe: string): any {
    let classe: string = this.getClassName(_id_classe);
    return new this.classes[classe];
  }

  protected getClassName(idProperty: string): string {

    let ret: string = '';
    let i: number = 3;
    while (i < idProperty.length) {
      if (idProperty[i] == '_') {
        ret = ret + idProperty[i + 1].toUpperCase();
        i++;
      }
      else {
        ret = ret + idProperty[i];
      }
      i++;
    }
    return ret;
  }
}

