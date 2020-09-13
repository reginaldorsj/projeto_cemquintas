using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using CemQuintas.OR;

namespace CemQuintas.API
{
	/// <summary>
	/// Controller da classe <see cref='FunerariaController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class FunerariaController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("funeraria/selecionarporid/{id}")]
		public CemQuintas.OR.Funeraria SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().FunerariaBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("funeraria/listar")]
		public IList<CemQuintas.OR.Funeraria> Listar()
		{
			return BOAccess.getBOFactory().FunerariaBO().Listar("Nome");
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="funeraria">O(A) funeraria.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("funeraria/inserir")]
		public CemQuintas.OR.Funeraria Inserir(CemQuintas.OR.Funeraria funeraria)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().FunerariaBO().InserirAlterar(u, funeraria, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="funeraria">O(A) funeraria.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("funeraria/alterar")]
		public CemQuintas.OR.Funeraria Alterar(CemQuintas.OR.Funeraria funeraria)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().FunerariaBO().InserirAlterar(u, funeraria, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="funeraria">O(A) funeraria.</param>
		[HttpDelete]
		[Route("funeraria/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Funeraria funeraria = BOAccess.getBOFactory().FunerariaBO().SelecionarPorId(id);
			BOAccess.getBOFactory().FunerariaBO().Excluir(u, funeraria);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("funeraria/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Funeraria> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().FunerariaBO().Excluir(u, lst);
		}
	}
}
