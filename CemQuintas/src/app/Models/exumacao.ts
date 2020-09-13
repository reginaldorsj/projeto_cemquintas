import { Sepultamento } from './sepultamento';
import { Uf } from './uf';
import { Cidade } from './cidade';

export class Exumacao {
  private _id_exumacao: number;
  private _id_sepultamento: Sepultamento;
  private _data: Date;
  private _funcionario: string;
  private _livro_geral_numero: string;
  private _livro_geral_folhas: string;
  private _nome_requerente: string;
  private _nacionalidade: string;
  private _naturalidade: string;
  private _profissao: string;
  private _rg: string;
  private _id_uf_rg: Uf;
  private _data_expedicao_rg: Date;
  private _logradouro: string;
  private _numero: string;
  private _apartamento: string;
  private _bairro: string;
  private _id_cidade: Cidade;
  private _telefone: string;
  private _grau_parentesco: string;
  private _responsavel_abertura: string;
  private _cemiterio_destino: string;
  private _data_digitacao: Date;

  public get IdExumacao(): number {
    return this._id_exumacao;
  }

  public set IdExumacao(idExumacao: number) {
    this._id_exumacao = idExumacao;
  }

  public get Sepultamento(): Sepultamento {
    return this._id_sepultamento;
  }

  public set Sepultamento(sepultamento: Sepultamento) {
    this._id_sepultamento = sepultamento;
  }

  public get Data(): Date {
    if (this._data && !(this._data instanceof Date)) {
      this._data = new Date(this._data);
    }
    return this._data;
  }

  public set Data(data: Date) {
    this._data = data;
  }

  public get Funcionario(): string {
    return this._funcionario;
  }

  public set Funcionario(funcionario: string) {
    this._funcionario = funcionario;
  }

  public get LivroGeralNumero(): string {
    return this._livro_geral_numero;
  }

  public set LivroGeralNumero(livroGeralNumero: string) {
    this._livro_geral_numero = livroGeralNumero;
  }

  public get LivroGeralFolhas(): string {
    return this._livro_geral_folhas;
  }

  public set LivroGeralFolhas(livroGeralFolhas: string) {
    this._livro_geral_folhas = livroGeralFolhas;
  }

  public get NomeRequerente(): string {
    return this._nome_requerente;
  }

  public set NomeRequerente(nomeRequerente: string) {
    this._nome_requerente = nomeRequerente;
  }

  public get Nacionalidade(): string {
    return this._nacionalidade;
  }

  public set Nacionalidade(nacionalidade: string) {
    this._nacionalidade = nacionalidade;
  }

  public get Naturalidade(): string {
    return this._naturalidade;
  }

  public set Naturalidade(naturalidade: string) {
    this._naturalidade = naturalidade;
  }

  public get Profissao(): string {
    return this._profissao;
  }

  public set Profissao(profissao: string) {
    this._profissao = profissao;
  }

  public get Rg(): string {
    return this._rg;
  }

  public set Rg(rg: string) {
    this._rg = rg;
  }

  public get Uf(): Uf {
    return this._id_uf_rg;
  }

  public set Uf(uf: Uf) {
    this._id_uf_rg = uf;
  }

  public get DataExpedicaoRg(): Date {
    if (this._data_expedicao_rg && !(this._data_expedicao_rg instanceof Date)) {
      this._data_expedicao_rg = new Date(this._data_expedicao_rg);
    }
    return this._data_expedicao_rg;
  }

  public set DataExpedicaoRg(dataExpedicaoRg: Date) {
    this._data_expedicao_rg = dataExpedicaoRg;
  }

  public get Logradouro(): string {
    return this._logradouro;
  }

  public set Logradouro(logradouro: string) {
    this._logradouro = logradouro;
  }

  public get Numero(): string {
    return this._numero;
  }

  public set Numero(numero: string) {
    this._numero = numero;
  }

  public get Apartamento(): string {
    return this._apartamento;
  }

  public set Apartamento(apartamento: string) {
    this._apartamento = apartamento;
  }

  public get Bairro(): string {
    return this._bairro;
  }

  public set Bairro(bairro: string) {
    this._bairro = bairro;
  }

  public get Cidade(): Cidade {
    return this._id_cidade;
  }

  public set Cidade(cidade) {
    this._id_cidade = cidade;
  }

  public get Telefone(): string {
    return this._telefone;
  }

  public set Telefone(telefone: string) {
    this._telefone = telefone;
  }

  public get GrauParentesco(): string {
    return this._grau_parentesco;
  }

  public set GrauParentesco(grauParentesco: string) {
    this._grau_parentesco = grauParentesco;
  }

  public get ResponsavelAbertura(): string {
    return this._responsavel_abertura;
  }

  public set ResponsavelAbertura(responsavelAbertura: string) {
    this._responsavel_abertura = responsavelAbertura;
  }

  public get CemiterioDestino(): string {
    return this._cemiterio_destino;
  }

  public set CemiterioDestino(cemiterioDestino: string) {
    this._cemiterio_destino = cemiterioDestino;
  }

  public get DataDigitacao(): Date {
    if (this._data_digitacao && !(this._data_digitacao instanceof Date)) {
      this._data_digitacao = new Date(this._data_digitacao);
    }
    return this._data_digitacao;
  }

  public set DataDigitacao(dataDigitacao: Date) {
    this._data_digitacao = dataDigitacao;
  }

}
