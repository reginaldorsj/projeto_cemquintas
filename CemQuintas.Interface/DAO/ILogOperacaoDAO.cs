

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CemQuintas.OR;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe <see cref='ILogOperacaoDAO'/> para acesso a dados
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface ILogOperacaoDAO : Regisoft.Camadas.Generic.IBaseDAO<LogOperacao, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="datahora"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<LogOperacao> ListarPor(string datahora);
			
	}
}
