
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
	public class CidadeDAO : BaseDAO<Cidade, long>, CemQuintas.DAO.ICidadeDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="CidadeDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public CidadeDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="CidadeDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public CidadeDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="CidadeDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public CidadeDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="CidadeDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public CidadeDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		public IList<Cidade> ListarPorUf(Uf uf)
		{
			return Listar("IdUf","IdUf",uf.IdUf,"IdUf");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="iduf"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Cidade> ListarPor(string iduf)
		{
			throw new NotImplementedException("Não implementado.");
		}
		public IList<Cidade> ListarPorNome(Uf uf, string nomeCidade)
		{
			ICriteria crit = Get<ICriteria>()
					.Add(Expression.InsensitiveLike("Descricao", nomeCidade, MatchMode.Start))
					.Add(Expression.Eq("IdUf", uf))
					.AddOrder(Order.Asc("Descricao"));
			return crit.List<Cidade>();
		}
		public Cidade SelecionarPorNome(Uf uf, string nomeCidade)
		{
			ICriteria crit = Get<ICriteria>()
					.Add(Expression.Eq("Descricao", nomeCidade))
					.Add(Expression.Eq("IdUf", uf));
			return crit.UniqueResult<Cidade>();
		}

	}
}
