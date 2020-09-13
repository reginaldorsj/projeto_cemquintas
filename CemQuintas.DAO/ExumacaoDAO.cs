
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Regisoft.Camadas.Generic;
using System.Data;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg;
using CemQuintas.OR;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe para acesso ao banco de dados utilizando o NHiberante.
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class ExumacaoDAO : BaseDAO<Exumacao, long>, CemQuintas.DAO.IExumacaoDAO
	{
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="ExumacaoDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configura��o do NHibernate.</param>
        public ExumacaoDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia de <see cref="ExumacaoDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public ExumacaoDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="ExumacaoDAO"/>.
		/// </summary>
		/// <param name="session">A sess�o NHibernate.</param>
		/// <param name="configuration">A configura��o.</param>
        public ExumacaoDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="ExumacaoDAO"/>.
		/// </summary>
		/// <param name="connection">A conex�o.</param>
		public ExumacaoDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sepultamento">O(A) sepultamento.</param>
		/// <returns>A lista.</returns>
		public IList<Exumacao> ListarPorSepultamento(Sepultamento sepultamento)
		{
			return Listar("IdSepultamento","IdSepultamento",sepultamento.IdSepultamento,"IdSepultamento");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		public IList<Exumacao> ListarPorUf(Uf uf)
		{
			return Listar("IdUfRg","IdUf",uf.IdUf,"IdUfRg");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		public IList<Exumacao> ListarPorCidade(Cidade cidade)
		{
			return Listar("IdCidade","IdCidade",cidade.IdCidade,"IdCidade");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="idsepultamento"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Exumacao> ListarPor(string idsepultamento)
		{
			throw new NotImplementedException("N�o implementado.");
		}
	}
}
