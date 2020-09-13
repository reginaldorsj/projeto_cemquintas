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
	/// Controller da classe <see cref='UfController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class UfController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("uf/selecionarporid/{id}")]
		public CemQuintas.OR.Uf SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().UfBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("uf/listar")]
		public IList<CemQuintas.OR.Uf> Listar()
		{
			return BOAccess.getBOFactory().UfBO().Listar("Sigla");
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("uf/inserir")]
		public CemQuintas.OR.Uf Inserir(CemQuintas.OR.Uf uf)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().UfBO().InserirAlterar(u, uf, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("uf/alterar")]
		public CemQuintas.OR.Uf Alterar(CemQuintas.OR.Uf uf)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().UfBO().InserirAlterar(u, uf, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		[HttpDelete]
		[Route("uf/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Uf uf = BOAccess.getBOFactory().UfBO().SelecionarPorId(id);
			BOAccess.getBOFactory().UfBO().Excluir(u, uf);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("uf/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Uf> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().UfBO().Excluir(u, lst);
		}
	}
}
