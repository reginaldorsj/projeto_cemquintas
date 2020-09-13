import {TipoLogradouro} from './tipo-logradouro';
import {Cidade} from './cidade';

export class Cartorio {
	private _id_cartorio: number;
	private _nome: string;
	private _distrito: string;
	private _id_tipo_logradouro: TipoLogradouro;
	private _logradouro: string;
	private _numero: string;
	private _bairro: string;
	private _cep: string;
	private _id_cidade: Cidade;

	public get IdCartorio(): number {
		return this._id_cartorio;
	}

	public set IdCartorio(idCartorio: number) {
		this._id_cartorio = idCartorio;
	}

	public get Nome(): string {
		return this._nome;
	}

	public set Nome(nome: string) {
		this._nome = nome;
	}

	public get Distrito(): string {
		return this._distrito;
	}

	public set Distrito(distrito: string) {
		this._distrito = distrito;
	}

	public get TipoLogradouro(): TipoLogradouro {
		return this._id_tipo_logradouro;
	}

	public set TipoLogradouro(tipoLogradouro) {
		this._id_tipo_logradouro = tipoLogradouro;
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

	public get Bairro(): string {
		return this._bairro;
	}

	public set Bairro(bairro: string) {
		this._bairro = bairro;
	}

	public get Cep(): string {
		return this._cep;
	}

	public set Cep(cep: string) {
		this._cep = cep;
	}

	public get Cidade(): Cidade {
		return this._id_cidade;
	}

	public set Cidade(cidade) {
		this._id_cidade = cidade;
	}

}
