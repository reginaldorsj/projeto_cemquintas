
export class Pesquisa {
  private _id_sepultamento: number;
  private _nome: string;
  private _numero_controle: string;
  private _ano: number;
  private _cidade: string;
  private _uf: string;
  private _causa_obito: string;
  public get IdSepultamento(): number {
    return this._id_sepultamento;
  }
  public set IdSepultamento(value: number) {
    this._id_sepultamento = value;
  }
  public get Nome(): string {
    return this._nome;
  }
  public set Nome(value: string) {
    this._nome = value;
  }
  public get NumeroControle(): string {
    return this._numero_controle;
  }
  public set NumeroControle(value: string) {
    this._numero_controle = value;
  }
  public get Ano(): number {
    return this._ano;
  }
  public set Ano(value: number) {
    this._ano = value;
  }
  public get Cidade(): string {
    return this._cidade;
  }
  public set Cidade(value: string) {
    this._cidade = value;
  }
  public get Uf(): string {
    return this._uf;
  }
  public set Uf(value: string) {
    this._uf = value;
  }
  public get CausaObito(): string {
    return this._causa_obito;
  }
  public set CausaObito(value: string) {
    this._causa_obito = value;
  }
}
