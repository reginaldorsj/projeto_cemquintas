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
	/// Controller da classe <see cref='ExumacaoController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class ExumacaoController : ApiController
	{
		[HttpGet]
		[Route("exumacao/selecionarporsepultamento/{idSepultamento}")]
		public CemQuintas.OR.Exumacao SelecionarPorSepultamento(long idSepultamento)
		{
			Sepultamento s = BOAccess.getBOFactory().SepultamentoBO().SelecionarPorId(idSepultamento);
			if (s == null)
				return null;

			return BOAccess.getBOFactory().ExumacaoBO().SelecionarPor("IdSepultamento", s);
		}

		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sepultamento">O(A) sepultamento.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("exumacao/listarporsepultamento")]
		public IList<CemQuintas.OR.Exumacao> ListarPorSepultamento(Sepultamento sepultamento)
		{
			return BOAccess.getBOFactory().ExumacaoBO().ListarPorSepultamento(sepultamento);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("exumacao/listarporuf")]
		public IList<CemQuintas.OR.Exumacao> ListarPorUf(Uf uf)
		{
			return BOAccess.getBOFactory().ExumacaoBO().ListarPorUf(uf);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("exumacao/listarporcidade")]
		public IList<CemQuintas.OR.Exumacao> ListarPorCidade(Cidade cidade)
		{
			return BOAccess.getBOFactory().ExumacaoBO().ListarPorCidade(cidade);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("exumacao/selecionarporid/{id}")]
		public CemQuintas.OR.Exumacao SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().ExumacaoBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("exumacao/listar/{propertyOrder}")]
		public IList<CemQuintas.OR.Exumacao> Listar(string propertyOrder)
		{
			return BOAccess.getBOFactory().ExumacaoBO().Listar(propertyOrder);
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="exumacao">O(A) exumacao.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("exumacao/inserir")]
		public CemQuintas.OR.Exumacao Inserir(CemQuintas.OR.Exumacao exumacao)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().ExumacaoBO().InserirAlterar(u, exumacao, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="exumacao">O(A) exumacao.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("exumacao/alterar")]
		public CemQuintas.OR.Exumacao Alterar(CemQuintas.OR.Exumacao exumacao)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().ExumacaoBO().InserirAlterar(u, exumacao, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="exumacao">O(A) exumacao.</param>
		[HttpDelete]
		[Route("exumacao/excluir/{id}")]
		public void Excluir(long id)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CemQuintas.OR.Exumacao exumacao = BOAccess.getBOFactory().ExumacaoBO().SelecionarPorId(id);
			BOAccess.getBOFactory().ExumacaoBO().Excluir(u, exumacao);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("exumacao/excluirlista")]
		public void Excluir(IList<CemQuintas.OR.Exumacao> lst)
		{
			CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().ExumacaoBO().Excluir(u, lst);
		}
	}
}
