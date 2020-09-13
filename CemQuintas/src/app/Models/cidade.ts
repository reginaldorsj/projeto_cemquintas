import { Uf } from './uf';

export class Cidade {
  private _id_cidade: number;
  private _id_uf: Uf;
  private _descricao: string;
  private _cep: string;

  public get IdCidade(): number {
    return this._id_cidade;
  }

  public set IdCidade(idCidade: number) {
    this._id_cidade = idCidade;
  }

  public get Uf(): Uf {
    return this._id_uf;
  }

  public set Uf(uf: Uf) {
    this._id_uf = uf;
  }

  public get Descricao(): string {
    return this._descricao;
  }

  public set Descricao(descricao: string) {
    this._descricao = descricao;
  }

  public get Cep(): string {
    return this._cep;
  }

  public set Cep(cep: string) {
    this._cep = cep;
  }

}
