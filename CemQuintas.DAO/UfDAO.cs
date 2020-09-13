
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
	public class UfDAO : BaseDAO<Uf, long>, CemQuintas.DAO.IUfDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UfDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public UfDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="UfDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public UfDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UfDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public UfDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UfDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public UfDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sigla"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Uf> ListarPor(string sigla)
		{
			throw new NotImplementedException("Não implementado.");
		}
	}
}
