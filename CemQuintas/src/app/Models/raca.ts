
export class Raca {
	private _id_raca: number;
	private _descricao: string;

	public get IdRaca(): number {
		return this._id_raca;
	}

	public set IdRaca(idRaca: number) {
		this._id_raca = idRaca;
	}

	public get Descricao(): string {
		return this._descricao;
	}

	public set Descricao(descricao: string) {
		this._descricao = descricao;
	}

}
