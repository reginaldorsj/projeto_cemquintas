
export class Sexo {
	private _id_sexo: number;
	private _descricao: string;

	public get IdSexo(): number {
		return this._id_sexo;
	}

	public set IdSexo(idSexo: number) {
		this._id_sexo = idSexo;
	}

	public get Descricao(): string {
		return this._descricao;
	}

	public set Descricao(descricao: string) {
		this._descricao = descricao;
	}

}
