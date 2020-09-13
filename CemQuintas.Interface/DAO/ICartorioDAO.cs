

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CemQuintas.OR;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe <see cref='ICartorioDAO'/> para acesso a dados
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface ICartorioDAO : Regisoft.Camadas.Generic.IBaseDAO<Cartorio, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="tipologradouro">O(A) tipologradouro.</param>
		/// <returns>A lista.</returns>
		IList<Cartorio> ListarPorTipoLogradouro(TipoLogradouro tipologradouro);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		IList<Cartorio> ListarPorCidade(Cidade cidade);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="nome"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Cartorio> ListarPor(string nome);
			
	}
}
