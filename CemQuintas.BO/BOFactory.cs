
using System;
using Microsoft.Practices.Unity;

namespace CemQuintas.BO
{
	/// <summary>
	/// Classe que expõe os BO's.
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
    public class BOFactory : MarshalByRefObject, CemQuintas.BO.IBOFactory
    {
		/// <summary>
		/// Container para injeção de dependência.
		/// </summary>
        private UnityContainer unityContainer;
		/// <summary>
		/// Instância da classe para acesso estático.
		/// </summary>
        private static BOFactory instance = null;

		/// <summary>
		/// Inicializa uma instância de <see cref="BOFactory"/>.
		/// </summary>
		public BOFactory()
		{
			Inicialize();
		}

		/// <summary>
		/// Lê/Cria uma instância da classe.
		/// </summary>
		/// <returns></returns>
        public static BOFactory getInstance()
        {
            if (instance == null)
            {
                instance = new BOFactory();
            }
            return instance;
        }
		/// <summary>
		/// Inicializa esta instância.
		/// </summary>
		private void Inicialize() 
		{
			unityContainer = new UnityContainer();
			unityContainer.RegisterType<ICartorioBO, CartorioBO>();
			unityContainer.RegisterType<ICidadaoBO, CidadaoBO>();
			unityContainer.RegisterType<ICidadeBO, CidadeBO>();
			unityContainer.RegisterType<IDocumentoBO, DocumentoBO>();
			unityContainer.RegisterType<IExumacaoBO, ExumacaoBO>();
			unityContainer.RegisterType<IFunerariaBO, FunerariaBO>();
			unityContainer.RegisterType<ILogOperacaoBO, LogOperacaoBO>();
			unityContainer.RegisterType<IPerfilBO, PerfilBO>();
			unityContainer.RegisterType<IQuadraBO, QuadraBO>();
			unityContainer.RegisterType<IQuadroBO, QuadroBO>();
			unityContainer.RegisterType<IRacaBO, RacaBO>();
			unityContainer.RegisterType<IResponsavelBO, ResponsavelBO>();
			unityContainer.RegisterType<ISepultamentoBO, SepultamentoBO>();
			unityContainer.RegisterType<ISexoBO, SexoBO>();
			unityContainer.RegisterType<ITestemunhaBO, TestemunhaBO>();
			unityContainer.RegisterType<ITipoLogradouroBO, TipoLogradouroBO>();
			unityContainer.RegisterType<IUfBO, UfBO>();
			unityContainer.RegisterType<IUsuarioBO, UsuarioBO>();
		}

		#region IDAOFactory Members
		/// <summary>
		/// Acesso a classe CartorioBO.
		/// </summary>
		/// <returns></returns>
        public ICartorioBO CartorioBO()
        {
			return unityContainer.Resolve<CartorioBO>();
        }
		/// <summary>
		/// Acesso a classe CidadaoBO.
		/// </summary>
		/// <returns></returns>
        public ICidadaoBO CidadaoBO()
        {
			return unityContainer.Resolve<CidadaoBO>();
        }
		/// <summary>
		/// Acesso a classe CidadeBO.
		/// </summary>
		/// <returns></returns>
        public ICidadeBO CidadeBO()
        {
			return unityContainer.Resolve<CidadeBO>();
        }
		/// <summary>
		/// Acesso a classe DocumentoBO.
		/// </summary>
		/// <returns></returns>
        public IDocumentoBO DocumentoBO()
        {
			return unityContainer.Resolve<DocumentoBO>();
        }
		/// <summary>
		/// Acesso a classe ExumacaoBO.
		/// </summary>
		/// <returns></returns>
        public IExumacaoBO ExumacaoBO()
        {
			return unityContainer.Resolve<ExumacaoBO>();
        }
		/// <summary>
		/// Acesso a classe FunerariaBO.
		/// </summary>
		/// <returns></returns>
        public IFunerariaBO FunerariaBO()
        {
			return unityContainer.Resolve<FunerariaBO>();
        }
		/// <summary>
		/// Acesso a classe LogOperacaoBO.
		/// </summary>
		/// <returns></returns>
        public ILogOperacaoBO LogOperacaoBO()
        {
			return unityContainer.Resolve<LogOperacaoBO>();
        }
		/// <summary>
		/// Acesso a classe PerfilBO.
		/// </summary>
		/// <returns></returns>
        public IPerfilBO PerfilBO()
        {
			return unityContainer.Resolve<PerfilBO>();
        }
		/// <summary>
		/// Acesso a classe QuadraBO.
		/// </summary>
		/// <returns></returns>
        public IQuadraBO QuadraBO()
        {
			return unityContainer.Resolve<QuadraBO>();
        }
		/// <summary>
		/// Acesso a classe QuadroBO.
		/// </summary>
		/// <returns></returns>
        public IQuadroBO QuadroBO()
        {
			return unityContainer.Resolve<QuadroBO>();
        }
		/// <summary>
		/// Acesso a classe RacaBO.
		/// </summary>
		/// <returns></returns>
        public IRacaBO RacaBO()
        {
			return unityContainer.Resolve<RacaBO>();
        }
		/// <summary>
		/// Acesso a classe ResponsavelBO.
		/// </summary>
		/// <returns></returns>
        public IResponsavelBO ResponsavelBO()
        {
			return unityContainer.Resolve<ResponsavelBO>();
        }
		/// <summary>
		/// Acesso a classe SepultamentoBO.
		/// </summary>
		/// <returns></returns>
        public ISepultamentoBO SepultamentoBO()
        {
			return unityContainer.Resolve<SepultamentoBO>();
        }
		/// <summary>
		/// Acesso a classe SexoBO.
		/// </summary>
		/// <returns></returns>
        public ISexoBO SexoBO()
        {
			return unityContainer.Resolve<SexoBO>();
        }
		/// <summary>
		/// Acesso a classe TestemunhaBO.
		/// </summary>
		/// <returns></returns>
        public ITestemunhaBO TestemunhaBO()
        {
			return unityContainer.Resolve<TestemunhaBO>();
        }
		/// <summary>
		/// Acesso a classe TipoLogradouroBO.
		/// </summary>
		/// <returns></returns>
        public ITipoLogradouroBO TipoLogradouroBO()
        {
			return unityContainer.Resolve<TipoLogradouroBO>();
        }
		/// <summary>
		/// Acesso a classe UfBO.
		/// </summary>
		/// <returns></returns>
        public IUfBO UfBO()
        {
			return unityContainer.Resolve<UfBO>();
        }
		/// <summary>
		/// Acesso a classe UsuarioBO.
		/// </summary>
		/// <returns></returns>
        public IUsuarioBO UsuarioBO()
        {
			return unityContainer.Resolve<UsuarioBO>();
        }

        #endregion
		
    }
}
