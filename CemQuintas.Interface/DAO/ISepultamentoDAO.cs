

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CemQuintas.OR;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe <see cref='ISepultamentoDAO'/> para acesso a dados
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface ISepultamentoDAO : Regisoft.Camadas.Generic.IBaseDAO<Sepultamento, long>
	{
        IList ListarPorNumeroIml(string numeroIML, int page);
		IList ListarPorNome(string nome, int page);
		IList<Sepultamento> Listar(int ano, int numeroControleInicial, int numeroControleFinal);
		IList<Sepultamento> Listar(DateTime dtInicial, DateTime dtFinal);
		IList ListarProdutividade(DateTime dtInicial, DateTime dtFinal);
		IList<Sepultamento> ListarProdutividade(string login, DateTime dtInicial, DateTime dtFinal);

		IList<Sepultamento> ListarTermosDataLimite(DateTime dtInicial, DateTime dtFinal);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidadao">O(A) cidadao.</param>
		/// <returns>A lista.</returns>
		IList<Sepultamento> ListarPorCidadao(Cidadao cidadao);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cartorio">O(A) cartorio.</param>
		/// <returns>A lista.</returns>
		IList<Sepultamento> ListarPorCartorio(Cartorio cartorio);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="quadro">O(A) quadro.</param>
		/// <returns>A lista.</returns>
		IList<Sepultamento> ListarPorQuadro(Quadro quadro);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="quadra">O(A) quadra.</param>
		/// <returns>A lista.</returns>
		IList<Sepultamento> ListarPorQuadra(Quadra quadra);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="numerocontrole"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Sepultamento> ListarPor(string numerocontrole);
			
	}
}
