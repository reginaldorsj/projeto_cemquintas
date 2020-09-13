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
    /// Controller da classe <see cref='UsuarioController'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    [Authorize]
    public class UsuarioController : ApiController
    {
        
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        [HttpGet]
        [Route("usuario/selecionarporid/{id}")]
        public CemQuintas.OR.Usuario SelecionarPorId(long id)
        {
            return BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(id);
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        [HttpGet]
        [Route("usuario/listar")]
        public IList<CemQuintas.OR.Usuario> Listar()
        {
            return BOAccess.getBOFactory().UsuarioBO().Listar("Nome");
        }
        /// <summary>
        /// Inserir um objeto no banco de dados.
        /// </summary>
        /// <param name="usuario">O(A) usuario.</param>
        /// <returns>O objeto após a persistência.</returns>
        [HttpPost]
        [Route("usuario/inserir")]
        public CemQuintas.OR.Usuario Inserir(CemQuintas.OR.Usuario usuario)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            return BOAccess.getBOFactory().UsuarioBO().InserirAlterar(u, usuario, Regisoft.Operacao.Incluir);
        }
        /// <summary>
        /// Altera um objeto no banco de dados.
        /// </summary>
        /// <param name="usuario">O(A) usuario.</param>
        /// <returns>O objeto após a persistência.</returns>
        [HttpPut]
        [Route("usuario/alterar")]
        public CemQuintas.OR.Usuario Alterar(CemQuintas.OR.Usuario usuario)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            return BOAccess.getBOFactory().UsuarioBO().InserirAlterar(u, usuario, Regisoft.Operacao.Alterar);
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="usuario">O(A) usuario.</param>
        [HttpDelete]
        [Route("usuario/excluir/{id}")]
        public void Excluir(long id)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            CemQuintas.OR.Usuario usuario = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(id);
            BOAccess.getBOFactory().UsuarioBO().Excluir(u, usuario);
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="lst">A lista.</param>
        [HttpDelete]
        [Route("usuario/excluirlista")]
        public void Excluir(IList<CemQuintas.OR.Usuario> lst)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            BOAccess.getBOFactory().UsuarioBO().Excluir(u, lst);
        }
    }
}
