

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CemQuintas.OR;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe <see cref='IExumacaoDAO'/> para acesso a dados
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface IExumacaoDAO : Regisoft.Camadas.Generic.IBaseDAO<Exumacao, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sepultamento">O(A) sepultamento.</param>
		/// <returns>A lista.</returns>
		IList<Exumacao> ListarPorSepultamento(Sepultamento sepultamento);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		IList<Exumacao> ListarPorUf(Uf uf);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		IList<Exumacao> ListarPorCidade(Cidade cidade);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="idsepultamento"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Exumacao> ListarPor(string idsepultamento);
			
	}
}
