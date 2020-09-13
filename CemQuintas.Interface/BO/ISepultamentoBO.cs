

using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using CemQuintas.OR;

namespace CemQuintas.BO
{
	/// <summary>
	/// Regras de negócio para gerenciamento da classe <see cref='ISepultamentoBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface ISepultamentoBO : IDisposable
	{
		IList ListarPorNumeroIml(string numeroIml, int page);
		IList ListarPorNome(string nome, int page);
		IList<Sepultamento> Listar(DateTime dtInicial, DateTime dtFinal);
		IList<Sepultamento> Listar(int ano, int numeroControleInicial, int numeroControleFinal);
		IList ListarProdutividade(DateTime dtInicial, DateTime dtFinal);
		IList<Sepultamento> ListarProdutividade(string login, DateTime dtInicial, DateTime dtFinal);
		IList<Sepultamento> ListarTermosDataLimite(DateTime dtInicial, DateTime dtFinal);
		/// <summary>
		/// Selecionar objeto.
		/// </summary>
		/// <param name="id">O id.</param>
		/// <returns></returns>
		CemQuintas.OR.Sepultamento SelecionarPorId(object id);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		CemQuintas.OR.Sepultamento SelecionarPor(string propertyName, object value);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		CemQuintas.OR.Sepultamento SelecionarPor(string propertyName1, object value1,string propertyName2, object value2);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		CemQuintas.OR.Sepultamento SelecionarPor(string[] propertyName, object[] value);
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		DataTable ToDataTable(IList<CemQuintas.OR.Sepultamento> lst);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidadao">O(A) cidadao.</param>
		/// <returns>A lista.</returns>
		IList<CemQuintas.OR.Sepultamento> ListarPorCidadao(CemQuintas.OR.Cidadao cidadao);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cartorio">O(A) cartorio.</param>
		/// <returns>A lista.</returns>
		IList<CemQuintas.OR.Sepultamento> ListarPorCartorio(CemQuintas.OR.Cartorio cartorio);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="quadro">O(A) quadro.</param>
		/// <returns>A lista.</returns>
		IList<CemQuintas.OR.Sepultamento> ListarPorQuadro(CemQuintas.OR.Quadro quadro);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="quadra">O(A) quadra.</param>
		/// <returns>A lista.</returns>
		IList<CemQuintas.OR.Sepultamento> ListarPorQuadra(CemQuintas.OR.Quadra quadra);
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="sepultamento">O(A) sepultamento.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		CemQuintas.OR.Sepultamento InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Sepultamento sepultamento, Regisoft.Operacao op);
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="sepultamento">O(A) sepultamento.</param>
		void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Sepultamento sepultamento);
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Sepultamento> lst);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Sepultamento> ListarPor(string dado);
					
	}
}
