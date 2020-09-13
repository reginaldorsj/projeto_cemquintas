
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Regisoft;
using CemQuintas.OR;
using CemQuintas.DAO;
using System.Runtime.Remoting.Channels;

namespace CemQuintas.BO
{
    /// <summary>
    /// Regras de negócio para gerenciamento da classe <see cref='ResponsavelBO'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    public class ResponsavelBO : MarshalByRefObject, CemQuintas.BO.IResponsavelBO
    {
        protected ILogOperacaoBO logBO;
        /// <summary>
        /// Define o objeto de controle de usuario.
        /// </summary>
        protected IUsuarioBO usuarioBO;
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected IResponsavelDAO responsavelDAO;

        /// <summary>
        /// Inicializa uma instância da classe <see cref="ResponsavelBO"/>.
        /// </summary>
        public ResponsavelBO(IUsuarioBO usuarioBO, ILogOperacaoBO logBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
            responsavelDAO = daoAccess.ResponsavelDAO();
            this.usuarioBO = usuarioBO;
            this.logBO = logBO;
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="ResponsavelBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~ResponsavelBO()
        {
            Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            responsavelDAO.Dispose();
            usuarioBO.Dispose();
            logBO.Dispose();
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="uf">O(A) uf.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Responsavel> ListarPorUf(Uf uf)
        {
            return responsavelDAO.ListarPorUf(uf);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="cidade">O(A) cidade.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Responsavel> ListarPorCidade(Cidade cidade)
        {
            return responsavelDAO.ListarPorCidade(cidade);
        }
        /// <summary>
        /// Transforma um lista em um DataTable.
        /// </summary>
        /// <param name="lst">A lista.</param>
        /// <returns>O DataTable.</returns>
        public DataTable ToDataTable(IList<CemQuintas.OR.Responsavel> lst)
        {
            return responsavelDAO.ToDataTable(lst);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
        /// <param name="value">O valor procurado na propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Responsavel SelecionarPor(string propertyName, object value)
        {
            return responsavelDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
        /// <param name="value1">O valor procurado na primeira propriedade.</param>
        /// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
        /// <param name="value2">TO valor procurado na segunda propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Responsavel SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
        {
            return responsavelDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
        /// <param name="value">O array de valores procurados nas propriedades.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Responsavel SelecionarPor(string[] propertyName, object[] value)
        {
            return responsavelDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Responsavel SelecionarPorId(object id)
        {
            return responsavelDAO.SelecionarPor("IdResponsavel", Convert.ChangeType(id, typeof(long)));
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        public IList<CemQuintas.OR.Responsavel> Listar(string propertyOrder)
        {
            return responsavelDAO.Listar(propertyOrder);
        }
        /// <summary>
        /// Insere ou altera um objeto no banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="responsavel">O(A) responsavel.</param>
        /// <param name="op">A operação.</param>
        /// <returns>O objeto após a persistência.</returns>
        public CemQuintas.OR.Responsavel InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Responsavel responsavel, Regisoft.Operacao op)
        {
            responsavel.Nome = stringf.SemAcentos(stringf.SoLetras(stringf.UmEspacoEntre(responsavel.Nome))).ToUpper().Trim();
            if (stringf.IfEmptyThenNull(responsavel.Nome) == null) 
            {
                if (responsavel.IdResponsavel.HasValue)
                {
                    responsavelDAO.Excluir(responsavel);
                    logBO.LancarExclusao(responsavel, u);
                }

                return null;
            }

            if (responsavel.Mae != null)
                responsavel.Mae = stringf.SemAcentos(stringf.SoLetras(stringf.UmEspacoEntre(responsavel.Mae))).ToUpper().Trim();
            responsavel.Mae = stringf.IfEmptyThenNull(responsavel.Mae);

            if (responsavel.Mae != null && responsavel.Mae.Length < 5)
                throw new ExceptionRS("Informe o nome completo da mãe do responsável.");

            if (responsavel.Pai != null)
                responsavel.Pai = stringf.SemAcentos(stringf.SoLetras(stringf.UmEspacoEntre(responsavel.Pai))).ToUpper().Trim();
            responsavel.Pai = stringf.IfEmptyThenNull(responsavel.Pai);

            if (responsavel.Pai != null && responsavel.Pai.Length < 5)
                throw new ExceptionRS("Informe o nome completo do pai do responsável.");

            if (responsavel.Endereco != null)
                responsavel.Endereco = stringf.SemAcentos(stringf.UmEspacoEntre(responsavel.Endereco)).Trim().ToUpper();
            responsavel.Endereco = stringf.IfEmptyThenNull(responsavel.Endereco);

            responsavelDAO.ValidaNotNull(responsavel);
            responsavelDAO.BeginTransaction();
            try
            {
                if (op == Regisoft.Operacao.Alterar)
                    responsavel = responsavelDAO.CopiarParaPersistente(responsavel.IdResponsavel.Value, responsavel);
                responsavel = responsavelDAO.InserirAlterar(responsavel, op);
                if (op == Operacao.Incluir)
                    logBO.LancarInclusao(responsavel, u);
                else
                    logBO.LancarAlteracao(responsavel, u);

                responsavelDAO.CommitTransaction();
            }
            catch
            {
                responsavelDAO.RollbackTransaction();
                throw;
            }
            return responsavel;
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="responsavel">O(A) responsavel.</param>
        public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Responsavel responsavel)
        {
            responsavelDAO.BeginTransaction();
            try
            {
                responsavelDAO.Excluir(responsavel);
                logBO.LancarExclusao(responsavel, u);
                responsavelDAO.CommitTransaction();
            }
            catch
            {
                responsavelDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Registro em uso.");
            }
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="lst">A lista.</param>
        public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Responsavel> lst)
        {
            responsavelDAO.BeginTransaction();
            try
            {
                foreach (CemQuintas.OR.Responsavel responsavel in lst)
                {
                    responsavelDAO.Excluir(responsavel);
                }
                responsavelDAO.CommitTransaction();
            }
            catch
            {
                responsavelDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
            }
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="dado"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        public IList<Responsavel> ListarPor(string dado)
        {
            return responsavelDAO.ListarPor(dado);
        }
    }
}
