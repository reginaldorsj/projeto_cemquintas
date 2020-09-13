import { Cidadao } from './cidadao';
import { Documento } from './documento';
import { Responsavel } from './responsavel';
import { Testemunha } from './testemunha';
import { Cartorio } from './cartorio';
import { Quadro } from './quadro';
import { Quadra } from './quadra';
import { Funeraria } from './funeraria';

export class Sepultamento {
  private _id_sepultamento: number;
  private _numero_controle: number;
  private _ano: number;
  private _id_cidadao: Cidadao;
  private _id_documento: Documento;
  private _id_responsavel1: Responsavel;
  private _id_responsavel2: Responsavel;
  private _id_testemunha1: Testemunha;
  private _id_testemunha2: Testemunha;
  private _data_termo: Date;
  private _data_limite: Date;
  private _documento_obito: string;
  private _data_documento_obito: Date;
  private _id_funeraria: Funeraria;
  private _id_cartorio: Cartorio;
  private _livro: string;
  private _folhas: string;
  private _termo: string;
  private _outras_informacoes: string;
  private _data_guia: Date;
  private _data_hora_falecimento: Date;
  private _causa_obito: string;
  private _crm: string;
  private _nome_medico: string;
  private _lugar_obito: string;
  private _cova_carneira: string;
  private _id_quadro: Quadro;
  private _cova: string;
  private _id_quadra: Quadra;
  private _carneira: string;
  private _data_hora_sepultamento: Date;
  private _numero_iml: string;
  private _data_exumacao: Date;
  private _local_exumacao: string;
  private _login_inclusao: string;
  private _data_hora_inclusao: Date;
  private _login_ultima_alteracao: string;
  private _data_hora_ultima_alteracao: Date;

  public get IdSepultamento(): number {
    return this._id_sepultamento;
  }

  public set IdSepultamento(idSepultamento: number) {
    this._id_sepultamento = idSepultamento;
  }

  public get NumeroControle(): number {
    return this._numero_controle;
  }

  public set NumeroControle(numeroControle: number) {
    this._numero_controle = numeroControle;
  }

  public get Ano(): number {
    return this._ano;
  }

  public set Ano(ano: number) {
    this._ano = ano;
  }

  public get Cidadao(): Cidadao {
    return this._id_cidadao;
  }

  public set Cidadao(cidadao: Cidadao) {
    this._id_cidadao = cidadao;
  }

  public get Documento(): Documento {
    return this._id_documento;
  }

  public set Documento(documento: Documento) {
    this._id_documento = documento;
  }

  public get Responsavel1(): Responsavel {
    return this._id_responsavel1;
  }

  public set Responsavel1(responsavel: Responsavel) {
    this._id_responsavel1 = responsavel;
  }

  public get Responsavel2(): Responsavel {
    return this._id_responsavel2;
  }

  public set Responsavel2(responsavel: Responsavel) {
    this._id_responsavel2 = responsavel;
  }

  public get Testemunha1(): Testemunha {
    return this._id_testemunha1;
  }

  public set Testemunha1(testemunha: Testemunha) {
    this._id_testemunha1 = testemunha;
  }

  public get Testemunha2(): Testemunha {
    return this._id_testemunha2;
  }

  public set Testemunha2(testemunha: Testemunha) {
    this._id_testemunha2 = testemunha;
  }

  public get DataTermo(): Date {
    if (this._data_termo && !(this._data_termo instanceof Date)) {
      this._data_termo = new Date(this._data_termo);
    }
    return this._data_termo;
  }

  public set DataTermo(dataTermo: Date) {
    this._data_termo = dataTermo;
  }

  public get DataLimite(): Date {
    if (this._data_limite && !(this._data_limite instanceof Date)) {
      this._data_limite = new Date(this._data_limite);
    }
    return this._data_limite;
  }

  public set DataLimite(dataLimite: Date) {
    this._data_limite = dataLimite;
  }

  public get DocumentoObito(): string {
    return this._documento_obito;
  }

  public set DocumentoObito(documentoObito: string) {
    this._documento_obito = documentoObito;
  }

  public get DataDocumentoObito(): Date {
    if (this._data_documento_obito && !(this._data_documento_obito instanceof Date)) {
      this._data_documento_obito = new Date(this._data_documento_obito);
    }
    return this._data_documento_obito;
  }

  public set DataDocumentoObito(dataDocumentoObito: Date) {
    this._data_documento_obito = dataDocumentoObito;
  }

  public get Funeraria(): Funeraria {
    return this._id_funeraria;
  }

  public set Funeraria(funeraria: Funeraria) {
    this._id_funeraria = funeraria;
  }

  public get Cartorio(): Cartorio {
    return this._id_cartorio;
  }

  public set Cartorio(cartorio: Cartorio) {
    this._id_cartorio = cartorio;
  }

  public get Livro(): string {
    return this._livro;
  }

  public set Livro(livro: string) {
    this._livro = livro;
  }

  public get Folhas(): string {
    return this._folhas;
  }

  public set Folhas(folhas: string) {
    this._folhas = folhas;
  }

  public get Termo(): string {
    return this._termo;
  }

  public set Termo(termo: string) {
    this._termo = termo;
  }

  public get OutrasInformacoes(): string {
    return this._outras_informacoes;
  }

  public set OutrasInformacoes(outrasInformacoes: string) {
    this._outras_informacoes = outrasInformacoes;
  }

  public get DataGuia(): Date {
    if (this._data_guia && !(this._data_guia instanceof Date)) {
      this._data_guia = new Date(this._data_guia);
    }
    return this._data_guia;
  }

  public set DataGuia(dataGuia: Date) {
    this._data_guia = dataGuia;
  }

  public get DataHoraFalecimento(): Date {
    if (this._data_hora_falecimento && !(this._data_hora_falecimento instanceof Date)) {
      this._data_hora_falecimento = new Date(this._data_hora_falecimento);
    }
    return this._data_hora_falecimento;
  }

  public set DataHoraFalecimento(dataHoraFalecimento: Date) {
    this._data_hora_falecimento = dataHoraFalecimento;
  }

  public get CausaObito(): string {
    return this._causa_obito;
  }

  public set CausaObito(causaObito: string) {
    this._causa_obito = causaObito;
  }

  public get Crm(): string {
    return this._crm;
  }

  public set Crm(crm: string) {
    this._crm = crm;
  }

  public get NomeMedico(): string {
    return this._nome_medico;
  }

  public set NomeMedico(nomeMedico: string) {
    this._nome_medico = nomeMedico;
  }

  public get LugarObito(): string {
    return this._lugar_obito;
  }

  public set LugarObito(lugarObito: string) {
    this._lugar_obito = lugarObito;
  }

  public get CovaCarneira(): string {
    return this._cova_carneira;
  }

  public set CovaCarneira(covaCarneira: string) {
    this._cova_carneira = covaCarneira;
  }

  public get Quadro(): Quadro {
    return this._id_quadro;
  }

  public set Quadro(quadro: Quadro) {
    this._id_quadro = quadro;
  }

  public get Cova(): string {
    return this._cova;
  }

  public set Cova(cova: string) {
    this._cova = cova;
  }

  public get Quadra(): Quadra {
    return this._id_quadra;
  }

  public set Quadra(quadra: Quadra) {
    this._id_quadra = quadra;
  }

  public get Carneira(): string {
    return this._carneira;
  }

  public set Carneira(carneira: string) {
    this._carneira = carneira;
  }

  public get DataHoraSepultamento(): Date {
    if (this._data_hora_sepultamento && !(this._data_hora_sepultamento instanceof Date)) {
      this._data_hora_sepultamento = new Date(this._data_hora_sepultamento);
    }
    return this._data_hora_sepultamento;
  }

  public set DataHoraSepultamento(dataHoraSepultamento: Date) {
    this._data_hora_sepultamento = dataHoraSepultamento;
  }

  public get NumeroIml(): string {
    return this._numero_iml;
  }

  public set NumeroIml(numeroIml: string) {
    this._numero_iml = numeroIml;
  }

  public get DataExumacao(): Date {
    if (this._data_exumacao && !(this._data_exumacao instanceof Date)) {
      this._data_exumacao = new Date(this._data_exumacao);
    }
    return this._data_exumacao;
  }

  public set DataExumacao(dataExumacao: Date) {
    this._data_exumacao = dataExumacao;
  }

  public get LocalExumacao(): string {
    return this._local_exumacao;
  }

  public set LocalExumacao(localExumacao: string) {
    this._local_exumacao = localExumacao;
  }

  public get LoginInclusao(): string {
    return this._login_inclusao;
  }

  public set LoginInclusao(loginInclusao: string) {
    this._login_inclusao = loginInclusao;
  }

  public get DataHoraInclusao(): Date {
    if (this._data_hora_inclusao && !(this._data_hora_inclusao instanceof Date)) {
      this._data_hora_inclusao = new Date(this._data_hora_inclusao);
    }
    return this._data_hora_inclusao;
  }

  public set DataHoraInclusao(dataHoraInclusao: Date) {
    this._data_hora_inclusao = dataHoraInclusao;
  }

  public get LoginUltimaAlteracao(): string {
    return this._login_ultima_alteracao;
  }

  public set LoginUltimaAlteracao(loginUltimaAlteracao: string) {
    this._login_ultima_alteracao = loginUltimaAlteracao;
  }

  public get DataHoraUltimaAlteracao(): Date {
    if (this._data_hora_ultima_alteracao && !(this._data_hora_ultima_alteracao instanceof Date)) {
      this._data_hora_ultima_alteracao = new Date(this._data_hora_ultima_alteracao);
    }
    return this._data_hora_ultima_alteracao;
  }

  public set DataHoraUltimaAlteracao(dataHoraUltimaAlteracao: Date) {
    this._data_hora_ultima_alteracao = dataHoraUltimaAlteracao;
  }
}
