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
    /// Controller da classe <see cref='CidadeController'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    [Authorize]
    public class CidadeController : ApiController
    {
        /// <summary>
        /// Selecionar objeto.
        /// </summary>
        /// <param name="sigla">O(A) sigla.</param>
        /// <param name="nomeCidade">O(A) nome da cidade.</param>
        /// <returns>A lista.</returns>
        [HttpGet]
        [Route("cidade/Selecionar/{sigla}/{nomeCidade}")]
        public CemQuintas.OR.Cidade SelecionarPor(string sigla, string nomeCidade)
        {
            Uf uf = BOAccess.getBOFactory().UfBO().SelecionarPor("Sigla", sigla);
            return BOAccess.getBOFactory().CidadeBO().SelecionarPorNome(uf, nomeCidade);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="sigla">O(A) sigla.</param>
        /// <param name="nomeCidade">O(A) nome da cidade.</param>
        /// <returns>A lista.</returns>
        [HttpGet]
        [Route("cidade/listar/{sigla}/{nomeCidade}")]
        public IList<CemQuintas.OR.Cidade> ListarPor(string sigla, string nomeCidade)
        {
            Uf uf = BOAccess.getBOFactory().UfBO().SelecionarPor("Sigla", sigla);
            return BOAccess.getBOFactory().CidadeBO().ListarPorNome(uf, nomeCidade);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        [HttpGet]
        [Route("cidade/selecionarporid/{id}")]
        public CemQuintas.OR.Cidade SelecionarPorId(long id)
        {
            return BOAccess.getBOFactory().CidadeBO().SelecionarPorId(id);
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        [HttpGet]
        [Route("cidade/listar/{propertyOrder}")]
        public IList<CemQuintas.OR.Cidade> Listar(string propertyOrder)
        {
            return BOAccess.getBOFactory().CidadeBO().Listar(propertyOrder);
        }
        /// <summary>
        /// Inserir um objeto no banco de dados.
        /// </summary>
        /// <param name="cidade">O(A) cidade.</param>
        /// <returns>O objeto após a persistência.</returns>
        [HttpPost]
        [Route("cidade/inserir")]
        public CemQuintas.OR.Cidade Inserir(CemQuintas.OR.Cidade cidade)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            return BOAccess.getBOFactory().CidadeBO().InserirAlterar(u, cidade, Regisoft.Operacao.Incluir);
        }
        /// <summary>
        /// Altera um objeto no banco de dados.
        /// </summary>
        /// <param name="cidade">O(A) cidade.</param>
        /// <returns>O objeto após a persistência.</returns>
        [HttpPut]
        [Route("cidade/alterar")]
        public CemQuintas.OR.Cidade Alterar(CemQuintas.OR.Cidade cidade)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            return BOAccess.getBOFactory().CidadeBO().InserirAlterar(u, cidade, Regisoft.Operacao.Alterar);
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="cidade">O(A) cidade.</param>
        [HttpDelete]
        [Route("cidade/excluir/{id}")]
        public void Excluir(long id)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            CemQuintas.OR.Cidade cidade = BOAccess.getBOFactory().CidadeBO().SelecionarPorId(id);
            BOAccess.getBOFactory().CidadeBO().Excluir(u, cidade);
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="lst">A lista.</param>
        [HttpDelete]
        [Route("cidade/excluirlista")]
        public void Excluir(IList<CemQuintas.OR.Cidade> lst)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            BOAccess.getBOFactory().CidadeBO().Excluir(u, lst);
        }
    }
}
