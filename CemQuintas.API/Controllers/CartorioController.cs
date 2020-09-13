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
	/// Controller da classe <see cref='CartorioController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class CartorioController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("cartorio/selecionarporid/{id}")]
		public CemQuintas.OR.Cartorio SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().CartorioBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("cartorio/listar")]
		public IList<CemQuintas.OR.Cartorio> Listar()
		{
			return BOAccess.getBOFactory().CartorioBO().Listar("Nome");
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="cartorio">O(A) cartorio.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("cartorio/inserir")]
		public CemQuintas.OR.Cartorio Inserir(CemQuintas.OR.Cartorio cartorio)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().CartorioBO().InserirAlterar(u, cartorio, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="cartorio">O(A) cartorio.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("cartorio/alterar")]
		public CemQuintas.OR.Cartorio Alterar(CemQuintas.OR.Cartorio cartorio)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().CartorioBO().InserirAlterar(u, cartorio, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="cartorio">O(A) cartorio.</param>
		[HttpDelete]
		[Route("cartorio/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Cartorio cartorio = BOAccess.getBOFactory().CartorioBO().SelecionarPorId(id);
			BOAccess.getBOFactory().CartorioBO().Excluir(u, cartorio);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("cartorio/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Cartorio> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().CartorioBO().Excluir(u, lst);
		}
	}
}
