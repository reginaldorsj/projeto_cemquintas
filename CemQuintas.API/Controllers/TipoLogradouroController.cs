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
	/// Controller da classe <see cref='TipoLogradouroController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class TipoLogradouroController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("tipologradouro/selecionarporid/{id}")]
		public CemQuintas.OR.TipoLogradouro SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().TipoLogradouroBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("tipologradouro/listar")]
		public IList<CemQuintas.OR.TipoLogradouro> Listar()
		{
			return BOAccess.getBOFactory().TipoLogradouroBO().Listar("Descricao");
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="tipologradouro">O(A) tipologradouro.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("tipologradouro/inserir")]
		public CemQuintas.OR.TipoLogradouro Inserir(CemQuintas.OR.TipoLogradouro tipologradouro)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().TipoLogradouroBO().InserirAlterar(u, tipologradouro, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="tipologradouro">O(A) tipologradouro.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("tipologradouro/alterar")]
		public CemQuintas.OR.TipoLogradouro Alterar(CemQuintas.OR.TipoLogradouro tipologradouro)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().TipoLogradouroBO().InserirAlterar(u, tipologradouro, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="tipologradouro">O(A) tipologradouro.</param>
		[HttpDelete]
		[Route("tipologradouro/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.TipoLogradouro tipologradouro = BOAccess.getBOFactory().TipoLogradouroBO().SelecionarPorId(id);
			BOAccess.getBOFactory().TipoLogradouroBO().Excluir(u, tipologradouro);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("tipologradouro/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.TipoLogradouro> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().TipoLogradouroBO().Excluir(u, lst);
		}
	}
}
