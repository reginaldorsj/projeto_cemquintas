
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
	public class CartorioDAO : BaseDAO<Cartorio, long>, CemQuintas.DAO.ICartorioDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="CartorioDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public CartorioDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="CartorioDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public CartorioDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="CartorioDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public CartorioDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="CartorioDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public CartorioDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="tipologradouro">O(A) tipologradouro.</param>
		/// <returns>A lista.</returns>
		public IList<Cartorio> ListarPorTipoLogradouro(TipoLogradouro tipologradouro)
		{
			return Listar("IdTipoLogradouro","IdTipoLogradouro",tipologradouro.IdTipoLogradouro,"IdTipoLogradouro");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		public IList<Cartorio> ListarPorCidade(Cidade cidade)
		{
			return Listar("IdCidade","IdCidade",cidade.IdCidade,"IdCidade");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="nome"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Cartorio> ListarPor(string nome)
		{
			ICriteria crit = Get<ICriteria>()
				.Add(Expression.InsensitiveLike("Nome",nome,MatchMode.Anywhere))
				.AddOrder(Order.Asc("Nome"));
			return crit.List<Cartorio>();
		}
	}
}
