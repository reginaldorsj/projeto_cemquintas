using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

using CemQuintas.OR;
using Regisoft;

namespace CemQuintas.API
{
	/// <summary>
	/// Controller da classe <see cref='LogOperacaoController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class LogOperacaoController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("logoperacao/{id}")]
		public string VerDados(long id)
		{
			LogOperacao l = BOAccess.getBOFactory().LogOperacaoBO().SelecionarPorId(id);
			return stringf.ToString(l.Dados);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("logoperacao/selecionarporid/{id}")]
		public CemQuintas.OR.LogOperacao SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().LogOperacaoBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("logoperacao/listar/{propertyOrder}")]
		public IList<CemQuintas.OR.LogOperacao> Listar(string propertyOrder)
		{
			return BOAccess.getBOFactory().LogOperacaoBO().Listar(propertyOrder);
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="logoperacao">O(A) logoperacao.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("logoperacao/inserir")]
		public CemQuintas.OR.LogOperacao Inserir(CemQuintas.OR.LogOperacao logoperacao)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().LogOperacaoBO().InserirAlterar(u, logoperacao, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="logoperacao">O(A) logoperacao.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("logoperacao/alterar")]
		public CemQuintas.OR.LogOperacao Alterar(CemQuintas.OR.LogOperacao logoperacao)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().LogOperacaoBO().InserirAlterar(u, logoperacao, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="logoperacao">O(A) logoperacao.</param>
		[HttpDelete]
		[Route("logoperacao/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.LogOperacao logoperacao = BOAccess.getBOFactory().LogOperacaoBO().SelecionarPorId(id);
			BOAccess.getBOFactory().LogOperacaoBO().Excluir(u, logoperacao);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("logoperacao/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.LogOperacao> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().LogOperacaoBO().Excluir(u, lst);
		}
	}
}
