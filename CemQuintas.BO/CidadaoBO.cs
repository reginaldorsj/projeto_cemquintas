
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
    /// Regras de negócio para gerenciamento da classe <see cref='CidadaoBO'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    public class CidadaoBO : MarshalByRefObject, CemQuintas.BO.ICidadaoBO
    {
        /// <summary>
        /// Define o objeto de controle de usuario.
        /// </summary>
        protected IUsuarioBO usuarioBO;
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected ICidadaoDAO cidadaoDAO;

        /// <summary>
        /// Inicializa uma instância da classe <see cref="CidadaoBO"/>.
        /// </summary>
        public CidadaoBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
            cidadaoDAO = daoAccess.CidadaoDAO();
            this.usuarioBO = usuarioBO;
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="CidadaoBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~CidadaoBO()
        {
            Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            cidadaoDAO.Dispose();
            usuarioBO.Dispose();
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="sexo">O(A) sexo.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Cidadao> ListarPorSexo(Sexo sexo)
        {
            return cidadaoDAO.ListarPorSexo(sexo);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="raca">O(A) raca.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Cidadao> ListarPorRaca(Raca raca)
        {
            return cidadaoDAO.ListarPorRaca(raca);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="cidade">O(A) cidade.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Cidadao> ListarPorCidade(Cidade cidade)
        {
            return cidadaoDAO.ListarPorCidade(cidade);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="uf">O(A) uf.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Cidadao> ListarPorUf(Uf uf)
        {
            return cidadaoDAO.ListarPorUf(uf);
        }
        /// <summary>
        /// Transforma um lista em um DataTable.
        /// </summary>
        /// <param name="lst">A lista.</param>
        /// <returns>O DataTable.</returns>
        public DataTable ToDataTable(IList<CemQuintas.OR.Cidadao> lst)
        {
            return cidadaoDAO.ToDataTable(lst);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
        /// <param name="value">O valor procurado na propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Cidadao SelecionarPor(string propertyName, object value)
        {
            return cidadaoDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
        /// <param name="value1">O valor procurado na primeira propriedade.</param>
        /// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
        /// <param name="value2">TO valor procurado na segunda propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Cidadao SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
        {
            return cidadaoDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
        /// <param name="value">O array de valores procurados nas propriedades.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Cidadao SelecionarPor(string[] propertyName, object[] value)
        {
            return cidadaoDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Cidadao SelecionarPorId(object id)
        {
            return cidadaoDAO.SelecionarPor("IdCidadao", Convert.ChangeType(id, typeof(long)));
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        public IList<CemQuintas.OR.Cidadao> Listar(string propertyOrder)
        {
            return cidadaoDAO.Listar(propertyOrder);
        }
        /// <summary>
        /// Insere ou altera um objeto no banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="cidadao">O(A) cidadao.</param>
        /// <param name="op">A operação.</param>
        /// <returns>O objeto após a persistência.</returns>
        public CemQuintas.OR.Cidadao InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Cidadao cidadao, Regisoft.Operacao op)
        {
            if (stringf.IfEmptyThenNull(cidadao.Nome) == null || cidadao.Nome.Length < 5)
                throw new ExceptionRS("Necessário informar nome completo do cidadão");

            //MetaphoneBR, só letras, um espaço entre palavras, sem acentos, maiúsculas e sem espaços antes e depois.
            cidadao.Nome = stringf.SoLetras(stringf.UmEspacoEntre(cidadao.Nome)).ToUpper().Trim();
            cidadao.NomeIdx = stringf.MetaphoneBR(cidadao.Nome);

            if (cidadao.Nome != "IGNORADO")
            {
                ToolsBO.IsFalse(cidadao.Idade != 0 && cidadao.ComplementoIdade == string.Empty, "Necessário informar complemento da idade.");
                ToolsBO.NecessarioInformar<Raca>("Raça", cidadao.IdRaca);
                if (cidadao.ComplementoIdade != null)
                    ToolsBO.In("Complemento da idade", cidadao.ComplementoIdade, new string[] { "ano(s)", "mes(es)", "semana(s)", "dia(s)", "hora(s)" });
                ToolsBO.NecessarioInformar<Sexo>("Sexo", cidadao.IdSexo);

                if (cidadao.NomeMae != null)
                    cidadao.NomeMae = stringf.SemAcentos(stringf.SoLetras(stringf.UmEspacoEntre(cidadao.NomeMae))).ToUpper().Trim();
                cidadao.NomeMae = stringf.IfEmptyThenNull(cidadao.NomeMae);

                if (cidadao.NomePai != null)
                    cidadao.NomePai = stringf.SemAcentos(stringf.SoLetras(stringf.UmEspacoEntre(cidadao.NomePai))).ToUpper().Trim();
                cidadao.NomePai = stringf.IfEmptyThenNull(cidadao.NomePai);

                if (cidadao.NomeMae != null && cidadao.NomeMae.Length < 5)
                    throw new ExceptionRS("Informe o nome completo da mãe.");

                if (cidadao.NomePai != null && cidadao.NomePai.Length < 5)
                    throw new ExceptionRS("Informe o nome completo do pai.");

                if (cidadao.Endereco != null)
                    cidadao.Endereco = stringf.SemAcentos(stringf.UmEspacoEntre(cidadao.Endereco)).Trim().ToUpper();
                cidadao.Endereco = stringf.IfEmptyThenNull(cidadao.Endereco);

                if (cidadao.Observacoes != null)
                    cidadao.Observacoes = cidadao.Observacoes.ToUpper().Trim();

                cidadaoDAO.ValidaNotNull(cidadao);
            }
            cidadaoDAO.BeginTransaction();
            try
            {
                if (op == Regisoft.Operacao.Alterar)
                    cidadao = cidadaoDAO.CopiarParaPersistente(cidadao.IdCidadao.Value, cidadao);
                cidadao = cidadaoDAO.InserirAlterar(cidadao, op);
                cidadaoDAO.CommitTransaction();
            }
            catch
            {
                cidadaoDAO.RollbackTransaction();
                throw;
            }
            return cidadao;
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="cidadao">O(A) cidadao.</param>
        public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Cidadao cidadao)
        {
            cidadaoDAO.BeginTransaction();
            try
            {
                cidadaoDAO.Excluir(cidadao);
                cidadaoDAO.CommitTransaction();
            }
            catch
            {
                cidadaoDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Registro em uso.");
            }
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="lst">A lista.</param>
        public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Cidadao> lst)
        {
            cidadaoDAO.BeginTransaction();
            try
            {
                foreach (CemQuintas.OR.Cidadao cidadao in lst)
                {
                    cidadaoDAO.Excluir(cidadao);
                }
                cidadaoDAO.CommitTransaction();
            }
            catch
            {
                cidadaoDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
            }
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="dado"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        public IList<Cidadao> ListarPor(string nome)
        {
            if ((nome.IndexOf(" ") < 0) || (nome.Length < 6))
                throw new ExceptionRS("Informe o nome completo.");
            nome = stringf.MetaphoneBR(nome);

            return cidadaoDAO.ListarPor(nome);
        }
    }
}
