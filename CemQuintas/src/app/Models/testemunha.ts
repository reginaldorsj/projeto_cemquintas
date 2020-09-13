
export class Testemunha {
	private _id_testemunha: number;
	private _nome: string;
	private _rg: string;
	private _telefone: string;

	public get IdTestemunha(): number {
		return this._id_testemunha;
	}

	public set IdTestemunha(idTestemunha: number) {
		this._id_testemunha = idTestemunha;
	}

	public get Nome(): string {
		return this._nome;
	}

	public set Nome(nome: string) {
		this._nome = nome;
	}

	public get Rg(): string {
		return this._rg;
	}

	public set Rg(rg: string) {
		this._rg = rg;
	}

	public get Telefone(): string {
		return this._telefone;
	}

	public set Telefone(telefone: string) {
		this._telefone = telefone;
	}

}
