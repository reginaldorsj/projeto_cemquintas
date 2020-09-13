

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CemQuintas.OR;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe <see cref='IUsuarioDAO'/> para acesso a dados
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface IUsuarioDAO : Regisoft.Camadas.Generic.IBaseDAO<Usuario, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="perfil">O(A) perfil.</param>
		/// <returns>A lista.</returns>
		IList<Usuario> ListarPorPerfil(Perfil perfil);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="idcidadao"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Usuario> ListarPor(string idcidadao);
			
	}
}
