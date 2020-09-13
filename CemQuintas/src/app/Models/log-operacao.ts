
export class LogOperacao {
	private _id_log_operacao: number;
	private _data_hora: Date;
	private _ip: string;
	private _operacao: string;
	private _nome: string;
	private _login: string;
	private _dados: byte[];

	public get IdLogOperacao(): number {
		return this._id_log_operacao;
	}

	public set IdLogOperacao(idLogOperacao: number) {
		this._id_log_operacao = idLogOperacao;
	}

	public get DataHora(): Date {
		if (this._data_hora && !(this._data_hora instanceof Date)) {
			this._data_hora = new Date(this._data_hora);
		}
		return this._data_hora; 
	}

	public set DataHora(dataHora: Date) {
		this._data_hora = dataHora;
	}

	public get Ip(): string {
		return this._ip;
	}

	public set Ip(ip: string) {
		this._ip = ip;
	}

	public get Operacao(): string {
		return this._operacao;
	}

	public set Operacao(operacao: string) {
		this._operacao = operacao;
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

	public get Dados(): byte[] {
		return this._dados;
	}

	public set Dados(dados: byte[]) {
		this._dados = dados;
	}

}
