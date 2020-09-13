

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CemQuintas.OR;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe <see cref='IFunerariaDAO'/> para acesso a dados
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface IFunerariaDAO : Regisoft.Camadas.Generic.IBaseDAO<Funeraria, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="nome"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Funeraria> ListarPor(string nome);
			
	}
}
