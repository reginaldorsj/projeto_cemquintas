
export class Perfil {
	private _id_perfil: number;
	private _descricao: string;

	public get IdPerfil(): number {
		return this._id_perfil;
	}

	public set IdPerfil(idPerfil: number) {
		this._id_perfil = idPerfil;
	}

	public get Descricao(): string {
		return this._descricao;
	}

	public set Descricao(descricao: string) {
		this._descricao = descricao;
	}

}
