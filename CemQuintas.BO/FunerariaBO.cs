
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
    /// Regras de negócio para gerenciamento da classe <see cref='FunerariaBO'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    public class FunerariaBO : MarshalByRefObject, CemQuintas.BO.IFunerariaBO
    {
        protected ILogOperacaoBO logBO;
        /// <summary>
        /// Define o objeto de controle de usuario.
        /// </summary>
        protected IUsuarioBO usuarioBO;
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected IFunerariaDAO funerariaDAO;

        /// <summary>
        /// Inicializa uma instância da classe <see cref="FunerariaBO"/>.
        /// </summary>
        public FunerariaBO(IUsuarioBO usuarioBO, ILogOperacaoBO logBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
            funerariaDAO = daoAccess.FunerariaDAO();
            this.usuarioBO = usuarioBO;
            this.logBO = logBO;
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="FunerariaBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~FunerariaBO()
        {
            Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            funerariaDAO.Dispose();
            usuarioBO.Dispose();
            logBO.Dispose();
        }
        /// <summary>
        /// Transforma um lista em um DataTable.
        /// </summary>
        /// <param name="lst">A lista.</param>
        /// <returns>O DataTable.</returns>
        public DataTable ToDataTable(IList<CemQuintas.OR.Funeraria> lst)
        {
            return funerariaDAO.ToDataTable(lst);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
        /// <param name="value">O valor procurado na propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Funeraria SelecionarPor(string propertyName, object value)
        {
            return funerariaDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
        /// <param name="value1">O valor procurado na primeira propriedade.</param>
        /// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
        /// <param name="value2">TO valor procurado na segunda propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Funeraria SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
        {
            return funerariaDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
        /// <param name="value">O array de valores procurados nas propriedades.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Funeraria SelecionarPor(string[] propertyName, object[] value)
        {
            return funerariaDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Funeraria SelecionarPorId(object id)
        {
            return funerariaDAO.SelecionarPor("IdFuneraria", Convert.ChangeType(id, typeof(long)));
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        public IList<CemQuintas.OR.Funeraria> Listar(string propertyOrder)
        {
            return funerariaDAO.Listar(propertyOrder);
        }
        /// <summary>
        /// Insere ou altera um objeto no banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="funeraria">O(A) funeraria.</param>
        /// <param name="op">A operação.</param>
        /// <returns>O objeto após a persistência.</returns>
        public CemQuintas.OR.Funeraria InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Funeraria funeraria, Regisoft.Operacao op)
        {
            if (!usuarioBO.EhDigitador(u))
                throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

            funeraria.Nome = stringf.UmEspacoEntre(funeraria.Nome).Trim().ToUpper();
            funerariaDAO.ValidaNotNull(funeraria);
            Funeraria _ix_funeraria = funerariaDAO.SelecionarPor(new string[] { "Nome" }, new object[] { funeraria.Nome });
            if ((op == Operacao.Incluir && _ix_funeraria != null) || (op == Operacao.Alterar && _ix_funeraria != null && _ix_funeraria.IdFuneraria != funeraria.IdFuneraria))
                throw new ExceptionRS("Já existe funerária com este nome.");

            funerariaDAO.BeginTransaction();
            try
            {
                if (op == Regisoft.Operacao.Alterar)
                    funeraria = funerariaDAO.CopiarParaPersistente(funeraria.IdFuneraria.Value, funeraria);
                funeraria = funerariaDAO.InserirAlterar(funeraria, op);
                if (op == Regisoft.Operacao.Incluir)
                    logBO.LancarInclusao(funeraria, u);
                else
                    logBO.LancarAlteracao(funeraria, u);

                funerariaDAO.CommitTransaction();
            }
            catch
            {
                funerariaDAO.RollbackTransaction();
                throw;
            }
            return funeraria;
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="funeraria">O(A) funeraria.</param>
        public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Funeraria funeraria)
        {
            if (!usuarioBO.EhDigitador(u))
                throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

            funerariaDAO.BeginTransaction();
            try
            {
                funerariaDAO.Excluir(funeraria);
                logBO.LancarInclusao(funeraria, u);
                funerariaDAO.CommitTransaction();
            }
            catch
            {
                funerariaDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Registro em uso.");
            }
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="lst">A lista.</param>
        public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Funeraria> lst)
        {
            funerariaDAO.BeginTransaction();
            try
            {
                foreach (CemQuintas.OR.Funeraria funeraria in lst)
                {
                    funerariaDAO.Excluir(funeraria);
                }
                funerariaDAO.CommitTransaction();
            }
            catch
            {
                funerariaDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
            }
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="dado"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        public IList<Funeraria> ListarPor(string dado)
        {
            return funerariaDAO.ListarPor(dado);
        }
    }
}
