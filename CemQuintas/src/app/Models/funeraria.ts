
export class Funeraria {
	private _id_funeraria: number;
	private _nome: string;

	public get IdFuneraria(): number {
		return this._id_funeraria;
	}

	public set IdFuneraria(idFuneraria: number) {
		this._id_funeraria = idFuneraria;
	}

	public get Nome(): string {
		return this._nome;
	}

	public set Nome(nome: string) {
		this._nome = nome;
	}

}
