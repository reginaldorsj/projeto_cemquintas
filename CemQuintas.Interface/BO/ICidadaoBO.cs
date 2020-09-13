

using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using CemQuintas.OR;

namespace CemQuintas.BO
{
	/// <summary>
	/// Regras de negócio para gerenciamento da classe <see cref='ICidadaoBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface ICidadaoBO : IDisposable
	{
		/// <summary>
		/// Selecionar objeto.
		/// </summary>
		/// <param name="id">O id.</param>
		/// <returns></returns>
		CemQuintas.OR.Cidadao SelecionarPorId(object id);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="propertyOrder">A propriedade ordem.</param>
		/// <returns>A lista ordenada.</returns>
		System.Collections.Generic.IList<CemQuintas.OR.Cidadao> Listar(string propertyOrder);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		CemQuintas.OR.Cidadao SelecionarPor(string propertyName, object value);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		CemQuintas.OR.Cidadao SelecionarPor(string propertyName1, object value1,string propertyName2, object value2);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		CemQuintas.OR.Cidadao SelecionarPor(string[] propertyName, object[] value);
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		DataTable ToDataTable(IList<CemQuintas.OR.Cidadao> lst);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sexo">O(A) sexo.</param>
		/// <returns>A lista.</returns>
		IList<CemQuintas.OR.Cidadao> ListarPorSexo(CemQuintas.OR.Sexo sexo);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="raca">O(A) raca.</param>
		/// <returns>A lista.</returns>
		IList<CemQuintas.OR.Cidadao> ListarPorRaca(CemQuintas.OR.Raca raca);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		IList<CemQuintas.OR.Cidadao> ListarPorCidade(CemQuintas.OR.Cidade cidade);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		IList<CemQuintas.OR.Cidadao> ListarPorUf(CemQuintas.OR.Uf uf);
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="cidadao">O(A) cidadao.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		CemQuintas.OR.Cidadao InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Cidadao cidadao, Regisoft.Operacao op);
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="cidadao">O(A) cidadao.</param>
		void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Cidadao cidadao);
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Cidadao> lst);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Cidadao> ListarPor(string dado);
					
	}
}
