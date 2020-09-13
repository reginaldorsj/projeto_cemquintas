
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
	public class ResponsavelDAO : BaseDAO<Responsavel, long>, CemQuintas.DAO.IResponsavelDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="ResponsavelDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public ResponsavelDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="ResponsavelDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public ResponsavelDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="ResponsavelDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public ResponsavelDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="ResponsavelDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public ResponsavelDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		public IList<Responsavel> ListarPorUf(Uf uf)
		{
			return Listar("IdUf","IdUf",uf.IdUf,"IdUf");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		public IList<Responsavel> ListarPorCidade(Cidade cidade)
		{
			return Listar("IdCidadeNaturalidade","IdCidade",cidade.IdCidade,"IdCidadeNaturalidade");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="nome"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Responsavel> ListarPor(string nome)
		{
			ICriteria crit = Get<ICriteria>()
				.Add(Expression.InsensitiveLike("Nome",nome,MatchMode.Anywhere))
				.AddOrder(Order.Asc("Nome"));
			return crit.List<Responsavel>();
		}
	}
}
