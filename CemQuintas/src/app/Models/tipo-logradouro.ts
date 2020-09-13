
export class TipoLogradouro {
	private _id_tipo_logradouro: number;
	private _descricao: string;

	public get IdTipoLogradouro(): number {
		return this._id_tipo_logradouro;
	}

	public set IdTipoLogradouro(idTipoLogradouro: number) {
		this._id_tipo_logradouro = idTipoLogradouro;
	}

	public get Descricao(): string {
		return this._descricao;
	}

	public set Descricao(descricao: string) {
		this._descricao = descricao;
	}

}
