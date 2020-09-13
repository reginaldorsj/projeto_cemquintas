
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
	public class UsuarioDAO : BaseDAO<Usuario, long>, CemQuintas.DAO.IUsuarioDAO
	{
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UsuarioDAO"/>.
		/// </summary>
		/// <param name="factoryConfigPath">A arquivo de configuração do NHibernate.</param>
        public UsuarioDAO(string factoryConfigPath)
            : base(factoryConfigPath, "CemQuintas.OR", null)
        {
        }
		/// <summary>
		/// Inicializa uma instância de <see cref="UsuarioDAO"/>.
		/// </summary>
		[Microsoft.Practices.Unity.InjectionConstructor]
        public UsuarioDAO()
            : base()
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UsuarioDAO"/>.
		/// </summary>
		/// <param name="session">A sessão NHibernate.</param>
		/// <param name="configuration">A configuração.</param>
        public UsuarioDAO(ISession session, Configuration configuration)
            : base(session,configuration)
        {
        }
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UsuarioDAO"/>.
		/// </summary>
		/// <param name="connection">A conexão.</param>
		public UsuarioDAO(System.Data.Common.DbConnection connection)
			: base(connection)
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="perfil">O(A) perfil.</param>
		/// <returns>A lista.</returns>
		public IList<Usuario> ListarPorPerfil(Perfil perfil)
		{
			return Listar("IdPerfil","IdPerfil",perfil.IdPerfil,"IdPerfil");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="idcidadao"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Usuario> ListarPor(string idcidadao)
		{
			throw new NotImplementedException("Não implementado.");
		}
	}
}
