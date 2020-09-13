
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
    /// Regras de negócio para gerenciamento da classe <see cref='SepultamentoBO'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    public class SepultamentoBO : MarshalByRefObject, CemQuintas.BO.ISepultamentoBO
    {
        protected ITestemunhaBO testemunhaBO;
        protected IResponsavelBO responsavelBO;
        protected ICidadaoBO cidadaoBO;
        protected ILogOperacaoBO logBO;
        /// <summary>
        /// Define o objeto de controle de usuario.
        /// </summary>
        protected IUsuarioBO usuarioBO;
        /// <summary>
        /// Define o objeto de acesso a dados.
        /// </summary>
        protected ISepultamentoDAO sepultamentoDAO;

        /// <summary>
        /// Inicializa uma instância da classe <see cref="SepultamentoBO"/>.
        /// </summary>
        public SepultamentoBO(IUsuarioBO usuarioBO, ITestemunhaBO testemunhaBO, ICidadaoBO cidadaoBO, ILogOperacaoBO logBO, IResponsavelBO responsavelBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
            sepultamentoDAO = daoAccess.SepultamentoDAO();
            this.usuarioBO = usuarioBO;
            this.cidadaoBO = cidadaoBO;
            this.logBO = logBO;
            this.responsavelBO = responsavelBO;
            this.testemunhaBO = testemunhaBO;
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="SepultamentoBO"/> is reclaimed by garbage collection.
        /// </summary>
        ~SepultamentoBO()
        {
            Dispose();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            sepultamentoDAO.Dispose();
            usuarioBO.Dispose();
            cidadaoBO.Dispose();
            logBO.Dispose();
            responsavelBO.Dispose();
            testemunhaBO.Dispose();
        }
        public IList ListarPorNumeroIml(string numeroIml, int page)
        {
            return sepultamentoDAO.ListarPorNumeroIml(numeroIml, page);
        }
        public IList ListarPorNome(string nome, int page)
        {
            ToolsBO.NecessarioInformar("Nome", nome);
            if (nome.Length < 5)
                throw new ExceptionRS("O nome precisa ter mais de 5 letras.");
            nome = stringf.PreparaBuscaMetaphoneBR(nome);
            return sepultamentoDAO.ListarPorNome(nome, page);
        }

        public IList<Sepultamento> Listar(DateTime dtInicial, DateTime dtFinal)
        {
            if (dtInicial > dtFinal)
                throw new ExceptionRS("Período inválido.");
            if (dtInicial.AddDays(31) < dtFinal)
                throw new ExceptionRS("O período não pode ser superior a 30 dias.");
            return sepultamentoDAO.Listar(dtInicial, dtFinal);

        }
        public IList<Sepultamento> Listar(int ano, int numeroControleInicial, int numeroControleFinal)
        {
            if (numeroControleInicial > numeroControleFinal)
                throw new ExceptionRS("Número de controle inicial não pode ser maior que o número final");
            if (numeroControleFinal - numeroControleInicial > 10001)
                throw new ExceptionRS("Apenas um intervalo de 500 números pode ser solicitado.");
            return sepultamentoDAO.Listar(ano, numeroControleInicial, numeroControleFinal);
        }
        public IList ListarProdutividade(DateTime dtInicial, DateTime dtFinal)
        {
            if (dtInicial > dtFinal)
                throw new ExceptionRS("Período inválido.");
            if (dtInicial.AddDays(31) < dtFinal)
                throw new ExceptionRS("O período não pode ser superior a 30 dias.");
            return sepultamentoDAO.ListarProdutividade(dtInicial, dtFinal);
        }
        public IList<Sepultamento> ListarProdutividade(string login, DateTime dtInicial, DateTime dtFinal)
        {
            if (dtInicial > dtFinal)
                throw new ExceptionRS("Período inválido.");
            if (dtInicial.AddDays(31) < dtFinal)
                throw new ExceptionRS("O período não pode ser superior a 30 dias.");
            return sepultamentoDAO.ListarProdutividade(login, dtInicial, dtFinal);
        }

        public IList<Sepultamento> ListarTermosDataLimite(DateTime dtInicial, DateTime dtFinal)
        {
            if (dtInicial > dtFinal)
                throw new ExceptionRS("Período informado incorretamente.");
            if (dtInicial.AddDays(31) < dtFinal)
                throw new ExceptionRS("O período não pode ser superior a 30 dias.");
            return sepultamentoDAO.ListarTermosDataLimite(dtInicial, dtFinal);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="cidadao">O(A) cidadao.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Sepultamento> ListarPorCidadao(Cidadao cidadao)
        {
            return sepultamentoDAO.ListarPorCidadao(cidadao);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="cartorio">O(A) cartorio.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Sepultamento> ListarPorCartorio(Cartorio cartorio)
        {
            return sepultamentoDAO.ListarPorCartorio(cartorio);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="quadro">O(A) quadro.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Sepultamento> ListarPorQuadro(Quadro quadro)
        {
            return sepultamentoDAO.ListarPorQuadro(quadro);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="quadra">O(A) quadra.</param>
        /// <returns>A lista.</returns>
        public IList<CemQuintas.OR.Sepultamento> ListarPorQuadra(Quadra quadra)
        {
            return sepultamentoDAO.ListarPorQuadra(quadra);
        }
        /// <summary>
        /// Transforma um lista em um DataTable.
        /// </summary>
        /// <param name="lst">A lista.</param>
        /// <returns>O DataTable.</returns>
        public DataTable ToDataTable(IList<CemQuintas.OR.Sepultamento> lst)
        {
            return sepultamentoDAO.ToDataTable(lst);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
        /// <param name="value">O valor procurado na propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Sepultamento SelecionarPor(string propertyName, object value)
        {
            return sepultamentoDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
        /// <param name="value1">O valor procurado na primeira propriedade.</param>
        /// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
        /// <param name="value2">TO valor procurado na segunda propriedade.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Sepultamento SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
        {
            return sepultamentoDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
        /// <param name="value">O array de valores procurados nas propriedades.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Sepultamento SelecionarPor(string[] propertyName, object[] value)
        {
            return sepultamentoDAO.SelecionarPor(propertyName, value);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        public CemQuintas.OR.Sepultamento SelecionarPorId(object id)
        {
            return sepultamentoDAO.SelecionarPor("IdSepultamento", Convert.ChangeType(id, typeof(long)));
        }
        /// <summary>
        /// Insere ou altera um objeto no banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="sepultamento">O(A) sepultamento.</param>
        /// <param name="op">A operação.</param>
        /// <returns>O objeto após a persistência.</returns>
        public CemQuintas.OR.Sepultamento InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Sepultamento sepultamento, Regisoft.Operacao op)
        {
            if (!usuarioBO.EhDigitador(u))
                throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

            ToolsBO.NecessarioInformar<Cidadao>("Cidadão", sepultamento.IdCidadao);
            if (sepultamento.Ano <= 0)
                throw new ExceptionRS("Necessário informar ano.");
            if (sepultamento.CovaCarneira != string.Empty)
                ToolsBO.In("Cova/Carneria", sepultamento.CovaCarneira, new string[] { "1", "2" });
            if (sepultamento.DataHoraSepultamento.HasValue && sepultamento.DataHoraSepultamento.Value.Year != sepultamento.Ano)
                throw new ExceptionRS("Data do sepultamento está incompatível com o ano de controle.");
            if (sepultamento.DataHoraSepultamento.HasValue && sepultamento.DataHoraSepultamento > DateTime.Now)
                throw new ExceptionRS("A data/hora do sepultamento não pode ser superior à data/hora de hoje");
            if (sepultamento.DataHoraFalecimento.HasValue && sepultamento.DataHoraFalecimento > DateTime.Now)
                throw new ExceptionRS("A data/hora do falecimento não pode ser superior à data/hora de hoje");
            if (sepultamento.DataGuia.HasValue && sepultamento.DataGuia > DateTime.Now)
                throw new ExceptionRS("A data/hora da guia não pode ser superior à data/hora de hoje");
            if (sepultamento.DataTermo.HasValue && sepultamento.DataTermo > DateTime.Now)
                throw new ExceptionRS("A data/hora do termo não pode ser superior à data/hora de hoje");


            Sepultamento s = new Sepultamento();
            s.Ano = sepultamento.Ano;
            s.NumeroControle = sepultamento.NumeroControle;
            IList<Sepultamento> lstS = sepultamentoDAO.Listar(s, null, false, null, null);
            if (s.NumeroControle != 0)
            {
                if ((op == Regisoft.Operacao.Incluir && lstS.Count != 0) || (op == Regisoft.Operacao.Alterar && lstS.Count != 0 && lstS[0].IdSepultamento != sepultamento.IdSepultamento))
                    throw new ExceptionRS("Nº de controle/ano já está em uso.");
            }

            if (op == Regisoft.Operacao.Incluir)
            {
                sepultamento.LoginInclusao = u.Login;
                sepultamento.DataHoraInclusao = DateTime.Now;
            }
            else
            {
                sepultamento.LoginUltimaAlteracao = u.Login;
                sepultamento.DataHoraUltimaAlteracao = DateTime.Now;
            }


            sepultamentoDAO.ValidaNotNull(sepultamento);
            sepultamentoDAO.BeginTransaction();
            try
            {
                if (sepultamento.IdCidadao.IdCidadao == null)
                    sepultamento.IdCidadao = cidadaoBO.InserirAlterar(u, sepultamento.IdCidadao, Regisoft.Operacao.Incluir);
                else
                    sepultamento.IdCidadao = cidadaoBO.InserirAlterar(u, sepultamento.IdCidadao, Regisoft.Operacao.Alterar);

                if (sepultamento.IdResponsavel1 != null)
                {
                    if (sepultamento.IdResponsavel1.IdResponsavel != null)
                        sepultamento.IdResponsavel1 = responsavelBO.InserirAlterar(u, sepultamento.IdResponsavel1, Operacao.Incluir);
                    else
                        sepultamento.IdResponsavel1 = responsavelBO.InserirAlterar(u, sepultamento.IdResponsavel1, Operacao.Incluir);
                }
                if (sepultamento.IdResponsavel2 != null)
                {
                    if (sepultamento.IdResponsavel2.IdResponsavel != null)
                        sepultamento.IdResponsavel2 = responsavelBO.InserirAlterar(u, sepultamento.IdResponsavel2, Operacao.Incluir);
                    else
                        sepultamento.IdResponsavel2 = responsavelBO.InserirAlterar(u, sepultamento.IdResponsavel2, Operacao.Incluir);
                }

                if (sepultamento.IdTestemunha1 != null)
                {
                    if (sepultamento.IdTestemunha1.IdTestemunha != null)
                        sepultamento.IdTestemunha1 = testemunhaBO.InserirAlterar(u, sepultamento.IdTestemunha1, Operacao.Incluir);
                    else
                        sepultamento.IdTestemunha1 = testemunhaBO.InserirAlterar(u, sepultamento.IdTestemunha1, Operacao.Incluir);
                }
                if (sepultamento.IdTestemunha2 != null)
                {
                    if (sepultamento.IdTestemunha2.IdTestemunha != null)
                        sepultamento.IdTestemunha2 = testemunhaBO.InserirAlterar(u, sepultamento.IdTestemunha2, Operacao.Incluir);
                    else
                        sepultamento.IdTestemunha2 = testemunhaBO.InserirAlterar(u, sepultamento.IdTestemunha2, Operacao.Incluir);
                }

                if (op == Regisoft.Operacao.Alterar)
                    sepultamento = sepultamentoDAO.CopiarParaPersistente(sepultamento.IdSepultamento.Value, sepultamento);
                sepultamento = sepultamentoDAO.InserirAlterar(sepultamento, op);
                if (op == Regisoft.Operacao.Incluir)
                    logBO.LancarInclusao(sepultamento, u);
                else
                    logBO.LancarAlteracao(sepultamento, u);

                sepultamentoDAO.CommitTransaction();
            }
            catch
            {
                sepultamentoDAO.RollbackTransaction();
                throw;
            }
            return sepultamento;
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="sepultamento">O(A) sepultamento.</param>
        public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Sepultamento sepultamento)
        {
            sepultamentoDAO.BeginTransaction();
            try
            {
                if (sepultamento.IdResponsavel1 != null)
                    responsavelBO.Excluir(u, sepultamento.IdResponsavel1);
                if (sepultamento.IdResponsavel2 != null)
                    responsavelBO.Excluir(u, sepultamento.IdResponsavel2);

                if (sepultamento.IdTestemunha1 != null)
                    testemunhaBO.Excluir(u, sepultamento.IdTestemunha1);
                if (sepultamento.IdTestemunha2 != null)
                    testemunhaBO.Excluir(u, sepultamento.IdTestemunha2);

                sepultamentoDAO.Excluir(sepultamento);
                logBO.LancarExclusao(sepultamento, u);

                cidadaoBO.Excluir(u, sepultamento.IdCidadao);

                sepultamentoDAO.CommitTransaction();
            }
            catch
            {
                sepultamentoDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Registro em uso.");
            }
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="lst">A lista.</param>
        public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Sepultamento> lst)
        {
            sepultamentoDAO.BeginTransaction();
            try
            {
                foreach (CemQuintas.OR.Sepultamento sepultamento in lst)
                {
                    sepultamentoDAO.Excluir(sepultamento);
                }
                sepultamentoDAO.CommitTransaction();
            }
            catch
            {
                sepultamentoDAO.RollbackTransaction();
                throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
            }
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="dado"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        public IList<Sepultamento> ListarPor(string dado)
        {
            return sepultamentoDAO.ListarPor(dado);
        }
    }
}
