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
	/// Controller da classe <see cref='CidadaoController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class CidadaoController : ApiController
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sexo">O(A) sexo.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("cidadao/listarporsexo")]
		public IList<CemQuintas.OR.Cidadao> ListarPorSexo(Sexo sexo)
		{
			return BOAccess.getBOFactory().CidadaoBO().ListarPorSexo(sexo);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="raca">O(A) raca.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("cidadao/listarporraca")]
		public IList<CemQuintas.OR.Cidadao> ListarPorRaca(Raca raca)
		{
			return BOAccess.getBOFactory().CidadaoBO().ListarPorRaca(raca);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("cidadao/listarporcidade")]
		public IList<CemQuintas.OR.Cidadao> ListarPorCidade(Cidade cidade)
		{
			return BOAccess.getBOFactory().CidadaoBO().ListarPorCidade(cidade);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("cidadao/listarporuf")]
		public IList<CemQuintas.OR.Cidadao> ListarPorUf(Uf uf)
		{
			return BOAccess.getBOFactory().CidadaoBO().ListarPorUf(uf);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("cidadao/selecionarporid/{id}")]
		public CemQuintas.OR.Cidadao SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().CidadaoBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("cidadao/listar/{propertyOrder}")]
		public IList<CemQuintas.OR.Cidadao> Listar(string propertyOrder)
		{
			return BOAccess.getBOFactory().CidadaoBO().Listar(propertyOrder);
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="cidadao">O(A) cidadao.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("cidadao/inserir")]
		public CemQuintas.OR.Cidadao Inserir(CemQuintas.OR.Cidadao cidadao)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().CidadaoBO().InserirAlterar(u, cidadao, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="cidadao">O(A) cidadao.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("cidadao/alterar")]
		public CemQuintas.OR.Cidadao Alterar(CemQuintas.OR.Cidadao cidadao)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().CidadaoBO().InserirAlterar(u, cidadao, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="cidadao">O(A) cidadao.</param>
		[HttpDelete]
		[Route("cidadao/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Cidadao cidadao = BOAccess.getBOFactory().CidadaoBO().SelecionarPorId(id);
			BOAccess.getBOFactory().CidadaoBO().Excluir(u, cidadao);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("cidadao/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Cidadao> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().CidadaoBO().Excluir(u, lst);
		}
	}
}
