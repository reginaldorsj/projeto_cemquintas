export class Produtividade {
  private _login: string;
  private _quantidade: number;

  public get Login(): string {
    return this._login;
  }
  public set Login(value: string) {
    this._login = value;
  }
  public get Quantidade(): number {
    return this._quantidade;
  }
  public set Quantidade(value: number) {
    this._quantidade = value;
  }
}
