
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
	public class TestemunhaDAO : BaseDAO<Testemunha, long>, CemQuintas.DAO.ITestemunhaDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="TestemunhaDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public TestemunhaDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="TestemunhaDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public TestemunhaDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="TestemunhaDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public TestemunhaDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="TestemunhaDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public TestemunhaDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="nome"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Testemunha> ListarPor(string nome)
		{
			ICriteria crit = Get<ICriteria>()
				.Add(Expression.InsensitiveLike("Nome",nome,MatchMode.Anywhere))
				.AddOrder(Order.Asc("Nome"));
			return crit.List<Testemunha>();
		}
	}
}
