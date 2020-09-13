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
	/// Controller da classe <see cref='SexoController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class SexoController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("sexo/selecionarporid/{id}")]
		public CemQuintas.OR.Sexo SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().SexoBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("sexo/listar")]
		public IList<CemQuintas.OR.Sexo> Listar()
		{
			return BOAccess.getBOFactory().SexoBO().Listar("Descricao");
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="sexo">O(A) sexo.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("sexo/inserir")]
		public CemQuintas.OR.Sexo Inserir(CemQuintas.OR.Sexo sexo)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().SexoBO().InserirAlterar(u, sexo, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="sexo">O(A) sexo.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("sexo/alterar")]
		public CemQuintas.OR.Sexo Alterar(CemQuintas.OR.Sexo sexo)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().SexoBO().InserirAlterar(u, sexo, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="sexo">O(A) sexo.</param>
		[HttpDelete]
		[Route("sexo/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Sexo sexo = BOAccess.getBOFactory().SexoBO().SelecionarPorId(id);
			BOAccess.getBOFactory().SexoBO().Excluir(u, sexo);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("sexo/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Sexo> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().SexoBO().Excluir(u, lst);
		}
	}
}
