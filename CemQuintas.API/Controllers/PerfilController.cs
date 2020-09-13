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
	/// Controller da classe <see cref='PerfilController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class PerfilController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("perfil/selecionarporid/{id}")]
		public CemQuintas.OR.Perfil SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().PerfilBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("perfil/listar")]
		public IList<CemQuintas.OR.Perfil> Listar()
		{
			return BOAccess.getBOFactory().PerfilBO().Listar("Descricao");
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="perfil">O(A) perfil.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("perfil/inserir")]
		public CemQuintas.OR.Perfil Inserir(CemQuintas.OR.Perfil perfil)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().PerfilBO().InserirAlterar(u, perfil, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="perfil">O(A) perfil.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("perfil/alterar")]
		public CemQuintas.OR.Perfil Alterar(CemQuintas.OR.Perfil perfil)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().PerfilBO().InserirAlterar(u, perfil, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="perfil">O(A) perfil.</param>
		[HttpDelete]
		[Route("perfil/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Perfil perfil = BOAccess.getBOFactory().PerfilBO().SelecionarPorId(id);
			BOAccess.getBOFactory().PerfilBO().Excluir(u, perfil);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("perfil/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Perfil> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().PerfilBO().Excluir(u, lst);
		}
	}
}
