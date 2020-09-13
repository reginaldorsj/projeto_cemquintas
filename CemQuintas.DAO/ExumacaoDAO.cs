
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
	public class ExumacaoDAO : BaseDAO<Exumacao, long>, CemQuintas.DAO.IExumacaoDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="ExumacaoDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public ExumacaoDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="ExumacaoDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public ExumacaoDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="ExumacaoDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public ExumacaoDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="ExumacaoDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public ExumacaoDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sepultamento">O(A) sepultamento.</param>
		/// <returns>A lista.</returns>
		public IList<Exumacao> ListarPorSepultamento(Sepultamento sepultamento)
		{
			return Listar("IdSepultamento","IdSepultamento",sepultamento.IdSepultamento,"IdSepultamento");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		public IList<Exumacao> ListarPorUf(Uf uf)
		{
			return Listar("IdUfRg","IdUf",uf.IdUf,"IdUfRg");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		public IList<Exumacao> ListarPorCidade(Cidade cidade)
		{
			return Listar("IdCidade","IdCidade",cidade.IdCidade,"IdCidade");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="idsepultamento"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Exumacao> ListarPor(string idsepultamento)
		{
			throw new NotImplementedException("Não implementado.");
		}
	}
}
