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
	/// Controller da classe <see cref='RacaController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class RacaController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("raca/selecionarporid/{id}")]
		public CemQuintas.OR.Raca SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().RacaBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("raca/listar")]
		public IList<CemQuintas.OR.Raca> Listar()
		{
			return BOAccess.getBOFactory().RacaBO().Listar("Descricao");
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="raca">O(A) raca.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("raca/inserir")]
		public CemQuintas.OR.Raca Inserir(CemQuintas.OR.Raca raca)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().RacaBO().InserirAlterar(u, raca, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="raca">O(A) raca.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("raca/alterar")]
		public CemQuintas.OR.Raca Alterar(CemQuintas.OR.Raca raca)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().RacaBO().InserirAlterar(u, raca, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="raca">O(A) raca.</param>
		[HttpDelete]
		[Route("raca/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Raca raca = BOAccess.getBOFactory().RacaBO().SelecionarPorId(id);
			BOAccess.getBOFactory().RacaBO().Excluir(u, raca);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("raca/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Raca> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().RacaBO().Excluir(u, lst);
		}
	}
}
