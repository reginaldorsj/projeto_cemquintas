

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CemQuintas.OR;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe <see cref='ICidadaoDAO'/> para acesso a dados
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface ICidadaoDAO : Regisoft.Camadas.Generic.IBaseDAO<Cidadao, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sexo">O(A) sexo.</param>
		/// <returns>A lista.</returns>
		IList<Cidadao> ListarPorSexo(Sexo sexo);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="raca">O(A) raca.</param>
		/// <returns>A lista.</returns>
		IList<Cidadao> ListarPorRaca(Raca raca);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		IList<Cidadao> ListarPorCidade(Cidade cidade);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		IList<Cidadao> ListarPorUf(Uf uf);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="nome"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Cidadao> ListarPor(string nome);
			
	}
}
