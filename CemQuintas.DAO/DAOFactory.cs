
using System;
using Microsoft.Practices.Unity;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe que expõe os DAO's.
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
    public class DAOFactory : MarshalByRefObject, CemQuintas.DAO.IDAOFactory
    {
		/// <summary>
		/// Container para injeção de dependência.
		/// </summary>
        private UnityContainer unityContainer;
		/// <summary>
		/// Inicializa uma instância de <see cref="DAOFactory"/>.
		/// </summary>
        public DAOFactory() 
        {			
			Inicialize();
		}
		/// <summary>
		/// Inicializa esta instância.
		/// </summary>
		private void Inicialize() 
		{
			unityContainer = new UnityContainer();
			unityContainer.RegisterType<ICartorioDAO, CartorioDAO>();
			unityContainer.RegisterType<ICidadaoDAO, CidadaoDAO>();
			unityContainer.RegisterType<ICidadeDAO, CidadeDAO>();
			unityContainer.RegisterType<IDocumentoDAO, DocumentoDAO>();
			unityContainer.RegisterType<IExumacaoDAO, ExumacaoDAO>();
			unityContainer.RegisterType<IFunerariaDAO, FunerariaDAO>();
			unityContainer.RegisterType<ILogOperacaoDAO, LogOperacaoDAO>();
			unityContainer.RegisterType<IPerfilDAO, PerfilDAO>();
			unityContainer.RegisterType<IQuadraDAO, QuadraDAO>();
			unityContainer.RegisterType<IQuadroDAO, QuadroDAO>();
			unityContainer.RegisterType<IRacaDAO, RacaDAO>();
			unityContainer.RegisterType<IResponsavelDAO, ResponsavelDAO>();
			unityContainer.RegisterType<ISepultamentoDAO, SepultamentoDAO>();
			unityContainer.RegisterType<ISexoDAO, SexoDAO>();
			unityContainer.RegisterType<ITestemunhaDAO, TestemunhaDAO>();
			unityContainer.RegisterType<ITipoLogradouroDAO, TipoLogradouroDAO>();
			unityContainer.RegisterType<IUfDAO, UfDAO>();
			unityContainer.RegisterType<IUsuarioDAO, UsuarioDAO>();
		}
		#region IDAOFactory Members
		/// <summary>
		/// Acesso a classe CartorioDAO.
		/// </summary>
		/// <returns></returns>
        public ICartorioDAO CartorioDAO()
        {
			return unityContainer.Resolve<CartorioDAO>();
        }
		/// <summary>
		/// Acesso a classe CidadaoDAO.
		/// </summary>
		/// <returns></returns>
        public ICidadaoDAO CidadaoDAO()
        {
			return unityContainer.Resolve<CidadaoDAO>();
        }
		/// <summary>
		/// Acesso a classe CidadeDAO.
		/// </summary>
		/// <returns></returns>
        public ICidadeDAO CidadeDAO()
        {
			return unityContainer.Resolve<CidadeDAO>();
        }
		/// <summary>
		/// Acesso a classe DocumentoDAO.
		/// </summary>
		/// <returns></returns>
        public IDocumentoDAO DocumentoDAO()
        {
			return unityContainer.Resolve<DocumentoDAO>();
        }
		/// <summary>
		/// Acesso a classe ExumacaoDAO.
		/// </summary>
		/// <returns></returns>
        public IExumacaoDAO ExumacaoDAO()
        {
			return unityContainer.Resolve<ExumacaoDAO>();
        }
		/// <summary>
		/// Acesso a classe FunerariaDAO.
		/// </summary>
		/// <returns></returns>
        public IFunerariaDAO FunerariaDAO()
        {
			return unityContainer.Resolve<FunerariaDAO>();
        }
		/// <summary>
		/// Acesso a classe LogOperacaoDAO.
		/// </summary>
		/// <returns></returns>
        public ILogOperacaoDAO LogOperacaoDAO()
        {
			return unityContainer.Resolve<LogOperacaoDAO>();
        }
		/// <summary>
		/// Acesso a classe PerfilDAO.
		/// </summary>
		/// <returns></returns>
        public IPerfilDAO PerfilDAO()
        {
			return unityContainer.Resolve<PerfilDAO>();
        }
		/// <summary>
		/// Acesso a classe QuadraDAO.
		/// </summary>
		/// <returns></returns>
        public IQuadraDAO QuadraDAO()
        {
			return unityContainer.Resolve<QuadraDAO>();
        }
		/// <summary>
		/// Acesso a classe QuadroDAO.
		/// </summary>
		/// <returns></returns>
        public IQuadroDAO QuadroDAO()
        {
			return unityContainer.Resolve<QuadroDAO>();
        }
		/// <summary>
		/// Acesso a classe RacaDAO.
		/// </summary>
		/// <returns></returns>
        public IRacaDAO RacaDAO()
        {
			return unityContainer.Resolve<RacaDAO>();
        }
		/// <summary>
		/// Acesso a classe ResponsavelDAO.
		/// </summary>
		/// <returns></returns>
        public IResponsavelDAO ResponsavelDAO()
        {
			return unityContainer.Resolve<ResponsavelDAO>();
        }
		/// <summary>
		/// Acesso a classe SepultamentoDAO.
		/// </summary>
		/// <returns></returns>
        public ISepultamentoDAO SepultamentoDAO()
        {
			return unityContainer.Resolve<SepultamentoDAO>();
        }
		/// <summary>
		/// Acesso a classe SexoDAO.
		/// </summary>
		/// <returns></returns>
        public ISexoDAO SexoDAO()
        {
			return unityContainer.Resolve<SexoDAO>();
        }
		/// <summary>
		/// Acesso a classe TestemunhaDAO.
		/// </summary>
		/// <returns></returns>
        public ITestemunhaDAO TestemunhaDAO()
        {
			return unityContainer.Resolve<TestemunhaDAO>();
        }
		/// <summary>
		/// Acesso a classe TipoLogradouroDAO.
		/// </summary>
		/// <returns></returns>
        public ITipoLogradouroDAO TipoLogradouroDAO()
        {
			return unityContainer.Resolve<TipoLogradouroDAO>();
        }
		/// <summary>
		/// Acesso a classe UfDAO.
		/// </summary>
		/// <returns></returns>
        public IUfDAO UfDAO()
        {
			return unityContainer.Resolve<UfDAO>();
        }
		/// <summary>
		/// Acesso a classe UsuarioDAO.
		/// </summary>
		/// <returns></returns>
        public IUsuarioDAO UsuarioDAO()
        {
			return unityContainer.Resolve<UsuarioDAO>();
        }
		public void Dispose()
		{
			// Nada
		}

        #endregion
		
    }
}
