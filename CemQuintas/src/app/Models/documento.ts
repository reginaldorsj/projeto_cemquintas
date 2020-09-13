
export class Documento {
	private _id_documento: number;
	private _descricao: string;

	public get IdDocumento(): number {
		return this._id_documento;
	}

	public set IdDocumento(idDocumento: number) {
		this._id_documento = idDocumento;
	}

	public get Descricao(): string {
		return this._descricao;
	}

	public set Descricao(descricao: string) {
		this._descricao = descricao;
	}

}
