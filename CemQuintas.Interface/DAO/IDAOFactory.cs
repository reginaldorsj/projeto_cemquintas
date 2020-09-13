
using System;

namespace CemQuintas.DAO
{
	/// <summary>
	/// Classe que expõe os DAO's.
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
    public interface IDAOFactory : IDisposable
    {
		/// <summary>
		/// Acesso a classe CartorioDAO.
		/// </summary>
		/// <returns></returns>
		ICartorioDAO CartorioDAO();
		/// <summary>
		/// Acesso a classe CidadaoDAO.
		/// </summary>
		/// <returns></returns>
		ICidadaoDAO CidadaoDAO();
		/// <summary>
		/// Acesso a classe CidadeDAO.
		/// </summary>
		/// <returns></returns>
		ICidadeDAO CidadeDAO();
		/// <summary>
		/// Acesso a classe DocumentoDAO.
		/// </summary>
		/// <returns></returns>
		IDocumentoDAO DocumentoDAO();
		/// <summary>
		/// Acesso a classe ExumacaoDAO.
		/// </summary>
		/// <returns></returns>
		IExumacaoDAO ExumacaoDAO();
		/// <summary>
		/// Acesso a classe FunerariaDAO.
		/// </summary>
		/// <returns></returns>
		IFunerariaDAO FunerariaDAO();
		/// <summary>
		/// Acesso a classe LogOperacaoDAO.
		/// </summary>
		/// <returns></returns>
		ILogOperacaoDAO LogOperacaoDAO();
		/// <summary>
		/// Acesso a classe PerfilDAO.
		/// </summary>
		/// <returns></returns>
		IPerfilDAO PerfilDAO();
		/// <summary>
		/// Acesso a classe QuadraDAO.
		/// </summary>
		/// <returns></returns>
		IQuadraDAO QuadraDAO();
		/// <summary>
		/// Acesso a classe QuadroDAO.
		/// </summary>
		/// <returns></returns>
		IQuadroDAO QuadroDAO();
		/// <summary>
		/// Acesso a classe RacaDAO.
		/// </summary>
		/// <returns></returns>
		IRacaDAO RacaDAO();
		/// <summary>
		/// Acesso a classe ResponsavelDAO.
		/// </summary>
		/// <returns></returns>
		IResponsavelDAO ResponsavelDAO();
		/// <summary>
		/// Acesso a classe SepultamentoDAO.
		/// </summary>
		/// <returns></returns>
		ISepultamentoDAO SepultamentoDAO();
		/// <summary>
		/// Acesso a classe SexoDAO.
		/// </summary>
		/// <returns></returns>
		ISexoDAO SexoDAO();
		/// <summary>
		/// Acesso a classe TestemunhaDAO.
		/// </summary>
		/// <returns></returns>
		ITestemunhaDAO TestemunhaDAO();
		/// <summary>
		/// Acesso a classe TipoLogradouroDAO.
		/// </summary>
		/// <returns></returns>
		ITipoLogradouroDAO TipoLogradouroDAO();
		/// <summary>
		/// Acesso a classe UfDAO.
		/// </summary>
		/// <returns></returns>
		IUfDAO UfDAO();
		/// <summary>
		/// Acesso a classe UsuarioDAO.
		/// </summary>
		/// <returns></returns>
		IUsuarioDAO UsuarioDAO();

    }
}
