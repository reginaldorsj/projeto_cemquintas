
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
	public class LogOperacaoDAO : BaseDAO<LogOperacao, long>, CemQuintas.DAO.ILogOperacaoDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="LogOperacaoDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public LogOperacaoDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="LogOperacaoDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public LogOperacaoDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="LogOperacaoDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public LogOperacaoDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="LogOperacaoDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public LogOperacaoDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="datahora"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<LogOperacao> ListarPor(string datahora)
		{
			throw new NotImplementedException("Não implementado.");
		}
	}
}
