
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
    /// Regras de negócio para gerenciamento da classe <see cref='TestemunhaBO'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    public class TestemunhaBO : MarshalByRefObject, CemQuintas.BO.ITestemunhaBO
    {
        protected ILogOperacaoBO logBO;
        /// <summary>
        /// Define o objeto de controle de usuario.
        /// </summary>
        protected IUsuarioBO usuarioBO;
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected ITestemunhaDAO testemunhaDAO;

        /// <summary>
        /// Inicializa uma instância da classe <see cref="TestemunhaBO"/>.
        /// </summary>
        public TestemunhaBO(IUsuarioBO usuarioBO, ILogOperacaoBO logBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
            testemunhaDAO = daoAccess.TestemunhaDAO();
            this.usuarioBO = usuarioBO;
            this.logBO = logBO;
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="TestemunhaBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~TestemunhaBO()
        {
            Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            testemunhaDAO.Dispose();
            usuarioBO.Dispose();
            logBO.Dispose();
        }
        /// <summary>
        /// Transforma um lista em um DataTable.
        /// </summary>
        /// <param name="lst">A lista.</param>
        /// <returns>O DataTable.</returns>
        public DataTable ToDataTable(IList<CemQuintas.OR.Testemunha> lst)
        {
            return testemunhaDAO.ToDataTable(lst);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
        /// <param name="value">O valor procurado na propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Testemunha SelecionarPor(string propertyName, object value)
        {
            return testemunhaDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
        /// <param name="value1">O valor procurado na primeira propriedade.</param>
        /// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
        /// <param name="value2">TO valor procurado na segunda propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Testemunha SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
        {
            return testemunhaDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
        /// <param name="value">O array de valores procurados nas propriedades.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Testemunha SelecionarPor(string[] propertyName, object[] value)
        {
            return testemunhaDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Testemunha SelecionarPorId(object id)
        {
            return testemunhaDAO.SelecionarPor("IdTestemunha", Convert.ChangeType(id, typeof(long)));
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        public IList<CemQuintas.OR.Testemunha> Listar(string propertyOrder)
        {
            return testemunhaDAO.Listar(propertyOrder);
        }
        /// <summary>
        /// Insere ou altera um objeto no banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="testemunha">O(A) testemunha.</param>
        /// <param name="op">A operação.</param>
        /// <returns>O objeto após a persistência.</returns>
        public CemQuintas.OR.Testemunha InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Testemunha testemunha, Regisoft.Operacao op)
        {
            testemunha.Nome = stringf.SemAcentos(stringf.SoLetras(stringf.UmEspacoEntre(testemunha.Nome))).ToUpper().Trim();
            if (stringf.IfEmptyThenNull(testemunha.Nome) == null)
            {
                if (testemunha.IdTestemunha.HasValue)
                {
                    testemunhaDAO.Excluir(testemunha);
                    logBO.LancarExclusao(testemunha, u);
                }
                return null;
            }

            testemunhaDAO.ValidaNotNull(testemunha);
            testemunhaDAO.BeginTransaction();
            try
            {
                if (op == Regisoft.Operacao.Alterar)
                    testemunha = testemunhaDAO.CopiarParaPersistente(testemunha.IdTestemunha.Value, testemunha);
                testemunha = testemunhaDAO.InserirAlterar(testemunha, op);
                if (op == Operacao.Incluir)
                    logBO.LancarInclusao(testemunha, u);
                else
                    logBO.LancarAlteracao(testemunha, u);
                testemunhaDAO.CommitTransaction();
            }
            catch
            {
                testemunhaDAO.RollbackTransaction();
                throw;
            }
            return testemunha;
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="testemunha">O(A) testemunha.</param>
        public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Testemunha testemunha)
        {
            testemunhaDAO.BeginTransaction();
            try
            {
                testemunhaDAO.Excluir(testemunha);
                logBO.LancarExclusao(testemunha, u);
                testemunhaDAO.CommitTransaction();
            }
            catch
            {
                testemunhaDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Registro em uso.");
            }
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="lst">A lista.</param>
        public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Testemunha> lst)
        {
            testemunhaDAO.BeginTransaction();
            try
            {
                foreach (CemQuintas.OR.Testemunha testemunha in lst)
                {
                    testemunhaDAO.Excluir(testemunha);
                }
                testemunhaDAO.CommitTransaction();
            }
            catch
            {
                testemunhaDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
            }
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="dado"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        public IList<Testemunha> ListarPor(string dado)
        {
            return testemunhaDAO.ListarPor(dado);
        }
    }
}
