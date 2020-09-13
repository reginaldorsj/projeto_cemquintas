import {Uf} from './uf';
import {Cidade} from './cidade';

export class Responsavel {
	private _id_responsavel: number;
	private _nome: string;
	private _telefone: string;
	private _pai: string;
	private _mae: string;
	private _endereco: string;
	private _id_uf: Uf;
	private _rg: string;
	private _data_rg: Date;
	private _id_cidade_naturalidade: Cidade;

	public get IdResponsavel(): number {
		return this._id_responsavel;
	}

	public set IdResponsavel(idResponsavel: number) {
		this._id_responsavel = idResponsavel;
	}

	public get Nome(): string {
		return this._nome;
	}

	public set Nome(nome: string) {
		this._nome = nome;
	}

	public get Telefone(): string {
		return this._telefone;
	}

	public set Telefone(telefone: string) {
		this._telefone = telefone;
	}

	public get Pai(): string {
		return this._pai;
	}

	public set Pai(pai: string) {
		this._pai = pai;
	}

	public get Mae(): string {
		return this._mae;
	}

	public set Mae(mae: string) {
		this._mae = mae;
	}

	public get Endereco(): string {
		return this._endereco;
	}

	public set Endereco(endereco: string) {
		this._endereco = endereco;
	}

	public get Uf(): Uf {
		return this._id_uf;
	}

	public set Uf(uf) {
		this._id_uf = uf;
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

	public get Cidade(): Cidade {
		return this._id_cidade_naturalidade;
	}

	public set Cidade(cidade:Cidade) {
		this._id_cidade_naturalidade = cidade;
	}

}
