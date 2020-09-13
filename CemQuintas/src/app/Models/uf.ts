
export class Uf {
	private _id_uf: number;
	private _sigla: string;
	private _descricao: string;

	public get IdUf(): number {
		return this._id_uf;
	}

	public set IdUf(idUf: number) {
		this._id_uf = idUf;
	}

	public get Sigla(): string {
		return this._sigla;
	}

	public set Sigla(sigla: string) {
		this._sigla = sigla;
	}

	public get Descricao(): string {
		return this._descricao;
	}

	public set Descricao(descricao: string) {
		this._descricao = descricao;
	}

}
