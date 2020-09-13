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
	/// Controller da classe <see cref='TestemunhaController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class TestemunhaController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("testemunha/selecionarporid/{id}")]
		public CemQuintas.OR.Testemunha SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().TestemunhaBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("testemunha/listar/{propertyOrder}")]
		public IList<CemQuintas.OR.Testemunha> Listar(string propertyOrder)
		{
			return BOAccess.getBOFactory().TestemunhaBO().Listar(propertyOrder);
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="testemunha">O(A) testemunha.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("testemunha/inserir")]
		public CemQuintas.OR.Testemunha Inserir(CemQuintas.OR.Testemunha testemunha)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().TestemunhaBO().InserirAlterar(u, testemunha, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="testemunha">O(A) testemunha.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("testemunha/alterar")]
		public CemQuintas.OR.Testemunha Alterar(CemQuintas.OR.Testemunha testemunha)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().TestemunhaBO().InserirAlterar(u, testemunha, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="testemunha">O(A) testemunha.</param>
		[HttpDelete]
		[Route("testemunha/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Testemunha testemunha = BOAccess.getBOFactory().TestemunhaBO().SelecionarPorId(id);
			BOAccess.getBOFactory().TestemunhaBO().Excluir(u, testemunha);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("testemunha/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Testemunha> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().TestemunhaBO().Excluir(u, lst);
		}
	}
}
