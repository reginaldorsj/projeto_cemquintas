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
	/// Controller da classe <see cref='ResponsavelController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class ResponsavelController : ApiController
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("responsavel/listarporuf")]
		public IList<CemQuintas.OR.Responsavel> ListarPorUf(Uf uf)
		{
			return BOAccess.getBOFactory().ResponsavelBO().ListarPorUf(uf);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("responsavel/listarporcidade")]
		public IList<CemQuintas.OR.Responsavel> ListarPorCidade(Cidade cidade)
		{
			return BOAccess.getBOFactory().ResponsavelBO().ListarPorCidade(cidade);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("responsavel/selecionarporid/{id}")]
		public CemQuintas.OR.Responsavel SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().ResponsavelBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("responsavel/listar/{propertyOrder}")]
		public IList<CemQuintas.OR.Responsavel> Listar(string propertyOrder)
		{
			return BOAccess.getBOFactory().ResponsavelBO().Listar(propertyOrder);
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="responsavel">O(A) responsavel.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("responsavel/inserir")]
		public CemQuintas.OR.Responsavel Inserir(CemQuintas.OR.Responsavel responsavel)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().ResponsavelBO().InserirAlterar(u, responsavel, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="responsavel">O(A) responsavel.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("responsavel/alterar")]
		public CemQuintas.OR.Responsavel Alterar(CemQuintas.OR.Responsavel responsavel)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().ResponsavelBO().InserirAlterar(u, responsavel, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="responsavel">O(A) responsavel.</param>
		[HttpDelete]
		[Route("responsavel/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Responsavel responsavel = BOAccess.getBOFactory().ResponsavelBO().SelecionarPorId(id);
			BOAccess.getBOFactory().ResponsavelBO().Excluir(u, responsavel);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("responsavel/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Responsavel> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().ResponsavelBO().Excluir(u, lst);
		}
	}
}
