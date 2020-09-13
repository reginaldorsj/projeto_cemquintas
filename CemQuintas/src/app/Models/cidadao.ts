import { Sexo } from './sexo';
import { Raca } from './raca';
import { Cidade } from './cidade';
import { Uf } from './uf';

export class Cidadao {
  private _id_cidadao: number;
  private _nome: string;
  private _nome_idx: string;
  private _id_sexo: Sexo;
  private _id_raca: Raca;
  private _id_cidade_naturalidade: Cidade;
  private _idade: number;
  private _complemento_idade: string;
  private _nome_mae: string;
  private _nome_pai: string;
  private _rg: string;
  private _data_rg: Date;
  private _id_uf_rg: Uf;
  private _endereco: string;
  private _telefone: string;
  private _observacoes: string;

  public get IdCidadao(): number {
    return this._id_cidadao;
  }

  public set IdCidadao(idCidadao: number) {
    this._id_cidadao = idCidadao;
  }

  public get Nome(): string {
    return this._nome;
  }

  public set Nome(nome: string) {
    this._nome = nome;
  }

  public get NomeIdx(): string {
    return this._nome_idx;
  }

  public set NomeIdx(nomeIdx: string) {
    this._nome_idx = nomeIdx;
  }

  public get Sexo(): Sexo {
    return this._id_sexo;
  }

  public set Sexo(sexo: Sexo) {
    this._id_sexo = sexo;
  }

  public get Raca(): Raca {
    return this._id_raca;
  }

  public set Raca(raca: Raca) {
    this._id_raca = raca;
  }

  public get Cidade(): Cidade {
    return this._id_cidade_naturalidade;
  }

  public set Cidade(cidade: Cidade) {
    this._id_cidade_naturalidade = cidade;
  }

  public get Idade(): number {
    return this._idade;
  }

  public set Idade(idade: number) {
    this._idade = idade;
  }

  public get ComplementoIdade(): string {
    return this._complemento_idade;
  }

  public set ComplementoIdade(complementoIdade: string) {
    this._complemento_idade = complementoIdade;
  }

  public get NomeMae(): string {
    return this._nome_mae;
  }

  public set NomeMae(nomeMae: string) {
    this._nome_mae = nomeMae;
  }

  public get NomePai(): string {
    return this._nome_pai;
  }

  public set NomePai(nomePai: string) {
    this._nome_pai = nomePai;
  }

  public get Rg(): string {
    return this._rg;
  }

  public set Rg(rg: string) {
    this._rg = rg;
  }

  public get DataRg(): Date {
    if (this._data_rg && !(this._data_rg instanceof Date)) {
      this._data_rg = new Date(this._data_rg);
    }
    return this._data_rg;
  }

  public set DataRg(dataRg: Date) {
    this._data_rg = dataRg;
  }

  public get UfRg(): Uf {
    return this._id_uf_rg;
  }

  public set UfRg(uf: Uf) {
    this._id_uf_rg = uf;
  }

  public get Endereco(): string {
    return this._endereco;
  }

  public set Endereco(endereco: string) {
    this._endereco = endereco;
  }

  public get Telefone(): string {
    return this._telefone;
  }

  public set Telefone(telefone: string) {
    this._telefone = telefone;
  }

  public get Observacoes(): string {
    return this._observacoes;
  }

  public set Observacoes(observacoes: string) {
    this._observacoes = observacoes;
  }

}
