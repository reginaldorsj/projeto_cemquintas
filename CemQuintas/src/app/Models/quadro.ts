
export class Quadro {
	private _id_quadro: number;
	private _descricao: string;

	public get IdQuadro(): number {
		return this._id_quadro;
	}

	public set IdQuadro(idQuadro: number) {
		this._id_quadro = idQuadro;
	}

	public get Descricao(): string {
		return this._descricao;
	}

	public set Descricao(descricao: string) {
		this._descricao = descricao;
	}

}
