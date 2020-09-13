

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CemQuintas.OR;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe <see cref='IPerfilDAO'/> para acesso a dados
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface IPerfilDAO : Regisoft.Camadas.Generic.IBaseDAO<Perfil, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="descricao"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Perfil> ListarPor(string descricao);
			
	}
}
