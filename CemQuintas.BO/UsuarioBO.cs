
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Regisoft;
using CemQuintas.OR;
using CemQuintas.DAO;

namespace CemQuintas.BO
{
    /// <summary>
    /// Regras de negócio para gerenciamento da classe <see cref='UsuarioBO'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    public class UsuarioBO : MarshalByRefObject, CemQuintas.BO.IUsuarioBO
    {
        protected ILogOperacaoBO logBO;
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected IUsuarioDAO usuarioDAO;

        /// <summary>
        /// Inicializa uma instância da classe <see cref="UsuarioBO"/>.
        /// </summary>
        public UsuarioBO(ILogOperacaoBO logBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
            usuarioDAO = daoAccess.UsuarioDAO();
            this.logBO = logBO;
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="UsuarioBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~UsuarioBO()
        {
            Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            usuarioDAO.Dispose();
            logBO.Dispose();
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="perfil">O(A) perfil.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Usuario> ListarPorPerfil(Perfil perfil)
        {
            return usuarioDAO.ListarPorPerfil(perfil);
        }
        /// <summary>
        /// Transforma um lista em um DataTable.
        /// </summary>
        /// <param name="lst">A lista.</param>
        /// <returns>O DataTable.</returns>
        public DataTable ToDataTable(IList<CemQuintas.OR.Usuario> lst)
        {
            return usuarioDAO.ToDataTable(lst);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
        /// <param name="value">O valor procurado na propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Usuario SelecionarPor(string propertyName, object value)
        {
            return usuarioDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
        /// <param name="value1">O valor procurado na primeira propriedade.</param>
        /// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
        /// <param name="value2">TO valor procurado na segunda propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Usuario SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
        {
            return usuarioDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
        /// <param name="value">O array de valores procurados nas propriedades.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Usuario SelecionarPor(string[] propertyName, object[] value)
        {
            return usuarioDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Usuario SelecionarPorId(object id)
        {
            return usuarioDAO.SelecionarPor("IdUsuario", Convert.ChangeType(id, typeof(long)));
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        public IList<CemQuintas.OR.Usuario> Listar(string propertyOrder)
        {
            return usuarioDAO.Listar(propertyOrder);
        }
        /// <summary>
        /// Insere ou altera um objeto no banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="usuario">O(A) usuario.</param>
        /// <param name="op">A operação.</param>
        /// <returns>O objeto após a persistência.</returns>
        public CemQuintas.OR.Usuario InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Usuario usuario, Regisoft.Operacao op)
        {
            if (!EhAdministrador(u))
                throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

            usuarioDAO.ValidaNotNull(usuario);
            usuario.Login = usuario.Login.ToLower();
            usuario.Nome = stringf.UmEspacoEntre(stringf.SemAcentos(usuario.Nome)).Trim().ToUpper();

            Usuario u_tmp = usuarioDAO.SelecionarPor("Login",usuario.Login);
            if ((op==Operacao.Incluir && u_tmp!=null) || (op==Operacao.Alterar && u_tmp!=null && u_tmp.IdUsuario.Value!=usuario.IdUsuario.Value))
                throw new ExceptionRS("Este login já existe. Tente outro.");

            if (usuario.Login == "sa")
                throw new ExceptionRS("O perfil deste usuário não pode ser modificado neste processo.");

            usuarioDAO.BeginTransaction();
            try
            {
                if (op == Operacao.Alterar && usuario.Senha!=u_tmp.Senha)
                    usuario.DataSenha = DateTime.Now;

                if (op == Operacao.Alterar)
                    usuario = usuarioDAO.CopiarParaPersistente(usuario.IdUsuario.Value, usuario);

                usuario = usuarioDAO.InserirAlterar(usuario, op);
                usuarioDAO.CommitTransaction();
            }
            catch
            {
                usuarioDAO.RollbackTransaction();
                throw;
            }
            return u;
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="usuario">O(A) usuario.</param>
        public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Usuario usuario)
        {
            if (!EhAdministrador(u))
                throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

            if (u.IdUsuario.Value == usuario.IdUsuario.Value)
                throw new ExceptionRS("Você não pode excluir sua própria conta de usuário. Solicite a outra pessoa que o faça.");

            usuarioDAO.BeginTransaction();
            try
            {
                usuarioDAO.Excluir(usuario);
                usuarioDAO.CommitTransaction();
            }
            catch
            {
                usuarioDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Registro em uso.");
            }
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="lst">A lista.</param>
        public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Usuario> lst)
        {
            usuarioDAO.BeginTransaction();
            try
            {
                foreach (CemQuintas.OR.Usuario usuario in lst)
                {
                    usuarioDAO.Excluir(usuario);
                }
                usuarioDAO.CommitTransaction();
            }
            catch
            {
                usuarioDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
            }
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="dado"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        public IList<Usuario> ListarPor(string nome)
        {
            return usuarioDAO.ListarPor(nome);
        }
        public bool EhAdministrador(Usuario u)
        {
            try
            {
                return u.IdPerfil.IdPerfil == 1;
            }
            catch
            {
                return false;
            }
        }
        public bool EhDigitador(Usuario u)
        {
            try
            {
                return u.IdPerfil.IdPerfil == 2 || u.IdPerfil.IdPerfil == 1;
            }
            catch
            {
                return false;
            }
        }
        public bool EhOperador(Usuario u)
        {
            try
            {
                return u.IdPerfil.IdPerfil == 3 || u.IdPerfil.IdPerfil == 2 || u.IdPerfil.IdPerfil == 1;
            }
            catch
            {
                return false;
            }
        }
        public Usuario SelecionarPorLoginSenha(string login, string senha, string ip)
        {
            if (login.Length > 20)
                login = login.Substring(0, 20);
            if (senha.Length > 20)
                senha = senha.Substring(0, 20);

            Usuario u = usuarioDAO.SelecionarPor("Login", login);
            if (u == null || u.Senha != senha)
                return null;

            usuarioDAO.BeginTransaction();
            try
            {
                u.DataUltimoAcesso = DateTime.Now;
                u = usuarioDAO.InserirAlterar(u, Operacao.Alterar);
                logBO.LancarLogin(u, u, ip);

                usuarioDAO.CommitTransaction();
            }
            catch
            {
                usuarioDAO.RollbackTransaction();
                throw;
            }
            return u;
        }
        public Usuario AlterarSenha(Usuario u, string novaSenha)
        {
            if (novaSenha == null || novaSenha == string.Empty || novaSenha.Length > 20)
                throw new ExceptionRS("Senha inválida.");

            if (u.Senha == novaSenha)
                throw new ExceptionRS("A nova senha não pode ser igual a anterior.");

            usuarioDAO.BeginTransaction();
            try
            {
                u.Senha = novaSenha;
                u.DataSenha = DateTime.Now;
                u = usuarioDAO.InserirAlterar(u, Operacao.Alterar);

                usuarioDAO.CommitTransaction();
            }
            catch
            {
                usuarioDAO.RollbackTransaction();
                throw;
            }
            return u;
        }
    }
}
