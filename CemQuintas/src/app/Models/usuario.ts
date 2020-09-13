import {Perfil} from './perfil';

export class Usuario {
	private _id_usuario: number;
	private _nome: string;
	private _login: string;
	private _senha: string;
	private _id_perfil: Perfil;
	private _data_ultimo_acesso: Date;
	private _data_senha: Date;

	public get IdUsuario(): number {
		return this._id_usuario;
	}

	public set IdUsuario(idUsuario: number) {
		this._id_usuario = idUsuario;
	}

	public get Nome(): string {
		return this._nome;
	}

	public set Nome(nome: string) {
		this._nome = nome;
	}

	public get Login(): string {
		return this._login;
	}

	public set Login(login: string) {
		this._login = login;
	}

	public get Senha(): string {
		return this._senha;
	}

	public set Senha(senha: string) {
		this._senha = senha;
	}

	public get Perfil(): Perfil {
		return this._id_perfil;
	}

	public set Perfil(perfil) {
		this._id_perfil = perfil;
	}

	public get DataUltimoAcesso(): Date {
		if (this._data_ultimo_acesso && !(this._data_ultimo_acesso instanceof Date)) {
			this._data_ultimo_acesso = new Date(this._data_ultimo_acesso);
		}
		return this._data_ultimo_acesso; 
	}

	public set DataUltimoAcesso(dataUltimoAcesso: Date) {
		this._data_ultimo_acesso = dataUltimoAcesso;
	}

	public get DataSenha(): Date {
		if (this._data_senha && !(this._data_senha instanceof Date)) {
			this._data_senha = new Date(this._data_senha);
		}
		return this._data_senha; 
	}

	public set DataSenha(dataSenha: Date) {
		this._data_senha = dataSenha;
	}

}
