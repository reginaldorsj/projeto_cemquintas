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
	/// Controller da classe <see cref='QuadroController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class QuadroController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("quadro/selecionarporid/{id}")]
		public CemQuintas.OR.Quadro SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().QuadroBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("quadro/listar")]
		public IList<CemQuintas.OR.Quadro> Listar()
		{
			return BOAccess.getBOFactory().QuadroBO().Listar("Descricao");
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="quadro">O(A) quadro.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("quadro/inserir")]
		public CemQuintas.OR.Quadro Inserir(CemQuintas.OR.Quadro quadro)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().QuadroBO().InserirAlterar(u, quadro, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="quadro">O(A) quadro.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("quadro/alterar")]
		public CemQuintas.OR.Quadro Alterar(CemQuintas.OR.Quadro quadro)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().QuadroBO().InserirAlterar(u, quadro, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="quadro">O(A) quadro.</param>
		[HttpDelete]
		[Route("quadro/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Quadro quadro = BOAccess.getBOFactory().QuadroBO().SelecionarPorId(id);
			BOAccess.getBOFactory().QuadroBO().Excluir(u, quadro);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("quadro/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Quadro> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().QuadroBO().Excluir(u, lst);
		}
	}
}
