
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
	public class SepultamentoDAO : BaseDAO<Sepultamento, long>, CemQuintas.DAO.ISepultamentoDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="SepultamentoDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public SepultamentoDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="SepultamentoDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public SepultamentoDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="SepultamentoDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public SepultamentoDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="SepultamentoDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public SepultamentoDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidadao">O(A) cidadao.</param>
		/// <returns>A lista.</returns>
		public IList<Sepultamento> ListarPorCidadao(Cidadao cidadao)
		{
			return Listar("IdCidadao","IdCidadao",cidadao.IdCidadao,"IdCidadao");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cartorio">O(A) cartorio.</param>
		/// <returns>A lista.</returns>
		public IList<Sepultamento> ListarPorCartorio(Cartorio cartorio)
		{
			return Listar("IdCartorio","IdCartorio",cartorio.IdCartorio,"IdCartorio");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="quadro">O(A) quadro.</param>
		/// <returns>A lista.</returns>
		public IList<Sepultamento> ListarPorQuadro(Quadro quadro)
		{
			return Listar("IdQuadro","IdQuadro",quadro.IdQuadro,"IdQuadro");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="quadra">O(A) quadra.</param>
		/// <returns>A lista.</returns>
		public IList<Sepultamento> ListarPorQuadra(Quadra quadra)
		{
			return Listar("IdQuadra","IdQuadra",quadra.IdQuadra,"IdQuadra");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="numerocontrole"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Sepultamento> ListarPor(string numerocontrole)
		{
			throw new NotImplementedException("Não implementado.");
		}
		public IList<Sepultamento> ListarTermosDataLimite(DateTime dtInicial, DateTime dtFinal)
		{
			ICriteria crit = Get<ICriteria>()
				.CreateAlias("IdDocumento","documento",NHibernate.SqlCommand.JoinType.InnerJoin)
					.Add(Restrictions.Eq("documento.IdDocumento", (long)1))
				.Add(Expression.Between("DataLimite", dtInicial, dtFinal))
				.AddOrder(Order.Asc("DataLimite"));
			return crit.List<Sepultamento>();
		}
		public IList ListarProdutividade(DateTime dtInicial, DateTime dtFinal)
		{
			string hql = @"select s.LoginInclusao, count(*) from Sepultamento as s 
                where s.DataHoraInclusao between :datainicio  and  :datafim
                group by s.LoginInclusao
                order by s.LoginInclusao";
			IQuery query = Get<ISession>().CreateQuery(hql);
			query.SetDateTime("datainicio", dtInicial);
			query.SetDateTime("datafim", dtFinal.AddDays(1));
			return query.List();
		}
		public IList<Sepultamento> ListarProdutividade(string login, DateTime dtInicial, DateTime dtFinal)
		{
			string hql = @"select s from Sepultamento as s 
                where s.DataHoraInclusao between :datainicio  and  :datafim and
                    s.LoginInclusao = :login
                order by s.IdSepultamento";
			IQuery query = Get<ISession>().CreateQuery(hql);
			query.SetDateTime("datainicio", dtInicial);
			query.SetDateTime("datafim", dtFinal.AddDays(1));
			query.SetAnsiString("login", login);
			return query.List<Sepultamento>();
		}
		public IList<Sepultamento> Listar(DateTime dtInicial, DateTime dtFinal)
		{
			ICriteria crit = Get<ICriteria>()
				.Add(Expression.Between("DataHoraSepultamento", dtInicial, dtFinal.AddDays(1).AddSeconds(-1)))
				.AddOrder(Order.Asc("DataHoraSepultamento"));
			return crit.List<Sepultamento>();
		}
		public IList<Sepultamento> Listar(int ano, int numeroControleInicial, int numeroControleFinal)
		{
			ICriteria crit = Get<ICriteria>()
				.Add(Expression.Eq("Ano", ano))
				.Add(Expression.Between("NumeroControle", numeroControleInicial, numeroControleFinal))
				.AddOrder(Order.Asc("Ano"))
				.AddOrder(Order.Asc("NumeroControle"));
			return crit.List<Sepultamento>();
		}
		public IList ListarPorNome(string nome, int page)
		{
			string hql = @"select s.IdSepultamento, s.NumeroControle, s.Ano, cidade.Descricao, uf.Sigla, s.CausaObito, cidadao.Nome
							from Sepultamento s
							inner join s.IdCidadao cidadao
							left join cidadao.IdCidadeNaturalidade cidade
							left join cidade.IdUf uf
							where cidadao.NomeIdx like :nome
							order by cidadao.Nome";

			IQuery query = Get<ISession>().CreateQuery(hql);
			return query.SetString("nome", nome + "%")
				.SetFirstResult(page * 25)
				.SetMaxResults(25)
				.List();

			/*
			ICriteria crit = Get<ICriteria>()
				.SetFirstResult(page * 25)
				.SetMaxResults(25)
				.CreateAlias("IdCidadao", "cidadao", NHibernate.SqlCommand.JoinType.InnerJoin)
					.Add(Restrictions.InsensitiveLike("cidadao.NomeIdx", nome, MatchMode.Start))
				.AddOrder(Order.Asc("cidadao.Nome"));
			return crit.List<Sepultamento>();
			*/
		}
		public IList ListarPorNumeroIml(string numeroIml, int page)
		{
			string hql = @"select s.IdSepultamento, s.NumeroControle, s.Ano, cidade.Descricao, uf.Sigla, s.CausaObito, cidadao.Nome
							from Sepultamento s
							inner join s.IdCidadao cidadao
							left join cidadao.IdCidadeNaturalidade cidade
							left join cidade.IdUf uf
							where s.NumeroIml like :numero";

			IQuery query = Get<ISession>().CreateQuery(hql);
			return query.SetString("numero", numeroIml + "%")
				.SetFirstResult(page * 25)
				.SetMaxResults(25)
				.List();

			/*
			ICriteria crit = Get<ICriteria>()
				.SetFirstResult(page * 25)
				.SetMaxResults(25)
				.Add(Restrictions.InsensitiveLike("NumeroIml", numeroIml, MatchMode.Start));
			return crit.List<Sepultamento>();
			*/
		}
	}
}
