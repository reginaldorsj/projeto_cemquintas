
using System;

namespace CemQuintas.BO
{
	/// <summary>
	/// Classe que expõe os BO's.
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
    public interface IBOFactory
    {
		/// <summary>
		/// Acesso a classe CartorioBO.
		/// </summary>
		/// <returns></returns>
		ICartorioBO CartorioBO();
		/// <summary>
		/// Acesso a classe CidadaoBO.
		/// </summary>
		/// <returns></returns>
		ICidadaoBO CidadaoBO();
		/// <summary>
		/// Acesso a classe CidadeBO.
		/// </summary>
		/// <returns></returns>
		ICidadeBO CidadeBO();
		/// <summary>
		/// Acesso a classe DocumentoBO.
		/// </summary>
		/// <returns></returns>
		IDocumentoBO DocumentoBO();
		/// <summary>
		/// Acesso a classe ExumacaoBO.
		/// </summary>
		/// <returns></returns>
		IExumacaoBO ExumacaoBO();
		/// <summary>
		/// Acesso a classe FunerariaBO.
		/// </summary>
		/// <returns></returns>
		IFunerariaBO FunerariaBO();
		/// <summary>
		/// Acesso a classe LogOperacaoBO.
		/// </summary>
		/// <returns></returns>
		ILogOperacaoBO LogOperacaoBO();
		/// <summary>
		/// Acesso a classe PerfilBO.
		/// </summary>
		/// <returns></returns>
		IPerfilBO PerfilBO();
		/// <summary>
		/// Acesso a classe QuadraBO.
		/// </summary>
		/// <returns></returns>
		IQuadraBO QuadraBO();
		/// <summary>
		/// Acesso a classe QuadroBO.
		/// </summary>
		/// <returns></returns>
		IQuadroBO QuadroBO();
		/// <summary>
		/// Acesso a classe RacaBO.
		/// </summary>
		/// <returns></returns>
		IRacaBO RacaBO();
		/// <summary>
		/// Acesso a classe ResponsavelBO.
		/// </summary>
		/// <returns></returns>
		IResponsavelBO ResponsavelBO();
		/// <summary>
		/// Acesso a classe SepultamentoBO.
		/// </summary>
		/// <returns></returns>
		ISepultamentoBO SepultamentoBO();
		/// <summary>
		/// Acesso a classe SexoBO.
		/// </summary>
		/// <returns></returns>
		ISexoBO SexoBO();
		/// <summary>
		/// Acesso a classe TestemunhaBO.
		/// </summary>
		/// <returns></returns>
		ITestemunhaBO TestemunhaBO();
		/// <summary>
		/// Acesso a classe TipoLogradouroBO.
		/// </summary>
		/// <returns></returns>
		ITipoLogradouroBO TipoLogradouroBO();
		/// <summary>
		/// Acesso a classe UfBO.
		/// </summary>
		/// <returns></returns>
		IUfBO UfBO();
		/// <summary>
		/// Acesso a classe UsuarioBO.
		/// </summary>
		/// <returns></returns>
		IUsuarioBO UsuarioBO();

    }
}
