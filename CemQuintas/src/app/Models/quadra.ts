
export class Quadra {
	private _id_quadra: number;
	private _descricao: string;

	public get IdQuadra(): number {
		return this._id_quadra;
	}

	public set IdQuadra(idQuadra: number) {
		this._id_quadra = idQuadra;
	}

	public get Descricao(): string {
		return this._descricao;
	}

	public set Descricao(descricao: string) {
		this._descricao = descricao;
	}

}
