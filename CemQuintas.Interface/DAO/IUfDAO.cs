

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CemQuintas.OR;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe <see cref='IUfDAO'/> para acesso a dados
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface IUfDAO : Regisoft.Camadas.Generic.IBaseDAO<Uf, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sigla"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Uf> ListarPor(string sigla);
			
	}
}
