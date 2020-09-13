
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
	public class PerfilDAO : BaseDAO<Perfil, long>, CemQuintas.DAO.IPerfilDAO
	{
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="PerfilDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configura��o do NHibernate.</param>
        public PerfilDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia de <see cref="PerfilDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public PerfilDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="PerfilDAO"/>.
		/// </summary>
		/// <param name="session">A sess�o NHibernate.</param>
		/// <param name="configuration">A configura��o.</param>
        public PerfilDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="PerfilDAO"/>.
		/// </summary>
		/// <param name="connection">A conex�o.</param>
		public PerfilDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="descricao"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Perfil> ListarPor(string descricao)
		{
			ICriteria crit = Get<ICriteria>()
				.Add(Expression.InsensitiveLike("Descricao",descricao,MatchMode.Anywhere))
				.AddOrder(Order.Asc("Descricao"));
			return crit.List<Perfil>();
		}
	}
}
