using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CemQuintas.OR;

namespace CemQuintas.API.Controllers
{
    public class AlterarSenhaController : ApiController
    {
        [HttpPut]
        [Route("alterarsenha/{login}/{senha}/{novaSenha}")]
        public Usuario AlterarSenha(string login, string senha, string novaSenha)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPor("Login", login);
            if (u == null || u.Senha != senha)
            {
                var message = "Login/Senha não confere.";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
            return BOAccess.getBOFactory().UsuarioBO().AlterarSenha(u, novaSenha);
        }
    }
}
