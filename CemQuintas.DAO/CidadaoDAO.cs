
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
	public class CidadaoDAO : BaseDAO<Cidadao, long>, CemQuintas.DAO.ICidadaoDAO
	{
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="CidadaoDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configura��o do NHibernate.</param>
        public CidadaoDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia de <see cref="CidadaoDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public CidadaoDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="CidadaoDAO"/>.
		/// </summary>
		/// <param name="session">A sess�o NHibernate.</param>
		/// <param name="configuration">A configura��o.</param>
        public CidadaoDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma inst�ncia da classe <see cref="CidadaoDAO"/>.
		/// </summary>
		/// <param name="connection">A conex�o.</param>
		public CidadaoDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sexo">O(A) sexo.</param>
		/// <returns>A lista.</returns>
		public IList<Cidadao> ListarPorSexo(Sexo sexo)
		{
			return Listar("IdSexo","IdSexo",sexo.IdSexo,"IdSexo");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="raca">O(A) raca.</param>
		/// <returns>A lista.</returns>
		public IList<Cidadao> ListarPorRaca(Raca raca)
		{
			return Listar("IdRaca","IdRaca",raca.IdRaca,"IdRaca");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		public IList<Cidadao> ListarPorCidade(Cidade cidade)
		{
			return Listar("IdCidadeNaturalidade","IdCidade",cidade.IdCidade,"IdCidadeNaturalidade");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		public IList<Cidadao> ListarPorUf(Uf uf)
		{
			return Listar("IdUfRg","IdUf",uf.IdUf,"IdUfRg");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="nome"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Cidadao> ListarPor(string nome)
		{
			ICriteria crit = Get<ICriteria>()
				.Add(Expression.Eq("NomeIdx",nome))
				.AddOrder(Order.Asc("Nome"));
			return crit.List<Cidadao>();
		}
	}
}
