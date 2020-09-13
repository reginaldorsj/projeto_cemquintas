
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
	public class TipoLogradouroDAO : BaseDAO<TipoLogradouro, long>, CemQuintas.DAO.ITipoLogradouroDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="TipoLogradouroDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public TipoLogradouroDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="TipoLogradouroDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public TipoLogradouroDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="TipoLogradouroDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public TipoLogradouroDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="TipoLogradouroDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public TipoLogradouroDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="descricao"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<TipoLogradouro> ListarPor(string descricao)
		{
			ICriteria crit = Get<ICriteria>()
				.Add(Expression.InsensitiveLike("Descricao",descricao,MatchMode.Anywhere))
				.AddOrder(Order.Asc("Descricao"));
			return crit.List<TipoLogradouro>();
		}
	}
}
