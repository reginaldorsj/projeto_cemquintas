using System;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Owin.Security.OAuth;
using CemQuintas.OR;

namespace CemQuintas.API
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        #region[GrantResourceOwnerCredentials]
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var userName = context.UserName;
                var password = context.Password;
                CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorLoginSenha(userName, password, context.Request.RemoteIpAddress);
                if (u == null)
                {
                    context.SetError("invalid_grant", "Dados inválidos. Tente outra vez.");
                }
                else if (u.Login != "sa" && u.DataSenha.AddDays(60) < DateTime.Now)
                {
                    context.SetError("invalid_grant", "Senha expirada. Altere a senha.");
                }
                else
                {
                    var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Sid, Convert.ToString(u.IdUsuario.Value)),
                            new Claim(ClaimTypes.Name, u.Login),
                            new Claim(ClaimTypes.NameIdentifier, Convert.ToString(u.IdUsuario.Value))
                        };
                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims,
                                Startup.OAuthOptions.AuthenticationType);

                    var properties = CreateProperties(u.Login, u.IdPerfil.Descricao);
                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                    context.Validated(ticket);
                }
            });
        }
        #endregion

        #region[ValidateClientAuthentication]
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }
        #endregion

        #region[TokenEndpoint]
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        #endregion

        #region[CreateProperties]
        public static AuthenticationProperties CreateProperties(string userName, string perfil)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
                {
                    { "userName", userName },
                    { "perfil", perfil}
                };
            return new AuthenticationProperties(data);
        }
        #endregion


    }
}
