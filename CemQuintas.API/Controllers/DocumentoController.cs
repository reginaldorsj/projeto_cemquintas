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
	/// Controller da classe <see cref='DocumentoController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class DocumentoController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("documento/selecionarporid/{id}")]
		public CemQuintas.OR.Documento SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().DocumentoBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("documento/listar")]
		public IList<CemQuintas.OR.Documento> Listar()
		{
			return BOAccess.getBOFactory().DocumentoBO().Listar("Descricao");
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="documento">O(A) documento.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("documento/inserir")]
		public CemQuintas.OR.Documento Inserir(CemQuintas.OR.Documento documento)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().DocumentoBO().InserirAlterar(u, documento, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="documento">O(A) documento.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("documento/alterar")]
		public CemQuintas.OR.Documento Alterar(CemQuintas.OR.Documento documento)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().DocumentoBO().InserirAlterar(u, documento, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="documento">O(A) documento.</param>
		[HttpDelete]
		[Route("documento/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Documento documento = BOAccess.getBOFactory().DocumentoBO().SelecionarPorId(id);
			BOAccess.getBOFactory().DocumentoBO().Excluir(u, documento);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("documento/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Documento> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().DocumentoBO().Excluir(u, lst);
		}
	}
}
