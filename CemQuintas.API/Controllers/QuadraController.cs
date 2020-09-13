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
	/// Controller da classe <see cref='QuadraController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class QuadraController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("quadra/selecionarporid/{id}")]
		public CemQuintas.OR.Quadra SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().QuadraBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("quadra/listar")]
		public IList<CemQuintas.OR.Quadra> Listar()
		{
			return BOAccess.getBOFactory().QuadraBO().Listar("Descricao");
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="quadra">O(A) quadra.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("quadra/inserir")]
		public CemQuintas.OR.Quadra Inserir(CemQuintas.OR.Quadra quadra)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().QuadraBO().InserirAlterar(u, quadra, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="quadra">O(A) quadra.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("quadra/alterar")]
		public CemQuintas.OR.Quadra Alterar(CemQuintas.OR.Quadra quadra)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().QuadraBO().InserirAlterar(u, quadra, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="quadra">O(A) quadra.</param>
		[HttpDelete]
		[Route("quadra/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Quadra quadra = BOAccess.getBOFactory().QuadraBO().SelecionarPorId(id);
			BOAccess.getBOFactory().QuadraBO().Excluir(u, quadra);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("quadra/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Quadra> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().QuadraBO().Excluir(u, lst);
		}
	}
}
