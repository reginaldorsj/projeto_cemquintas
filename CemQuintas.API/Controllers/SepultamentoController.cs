using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using CemQuintas.API.Models;
using CemQuintas.OR;
using System.Collections;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Net.Http.Headers;
using System.Web;
using Regisoft;

namespace CemQuintas.API
{
    /// <summary>
    /// Controller da classe <see cref='SepultamentoController'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    [Authorize]
    public class SepultamentoController : ApiController
    {
        [HttpGet]
        [Route("sepultamento/pesquisarpornome/{nome}/{page}")]
        public IList<Pesquisa> ListarPorNome(string nome, int page)
        {
            IList lst = BOAccess.getBOFactory().SepultamentoBO().ListarPorNome(nome, page);
            return getListPesquisa(lst);
        }

        [HttpGet]
        [Route("sepultamento/produtividade/{dataInicial}/{dataFinal}")]
        public IList<Produtividade> ListarProdutividade(DateTime dataInicial, DateTime dataFinal)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            if (!BOAccess.getBOFactory().UsuarioBO().EhDigitador(u))
            {
                var message = "Acesso negado para operadores!";
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message));
            }

            IList lst = BOAccess.getBOFactory().SepultamentoBO().ListarProdutividade(dataInicial, dataFinal);
            List<Produtividade> ret = new List<Produtividade>();
            int total = 0;
            foreach (System.Array a in lst)
            {
                if (!BOAccess.getBOFactory().UsuarioBO().EhAdministrador(u) && u.Login != a.GetValue(0).ToString())
                    continue;

                Produtividade p = new Produtividade()
                {
                    Login = a.GetValue(0).ToString(),
                    Quantidade = Convert.ToInt32(a.GetValue(1))
                };
                ret.Add(p);
                total += p.Quantidade;
            }

            Produtividade pTotal = new Produtividade()
            {
                Login = null,
                Quantidade = total
            };
            ret.Add(pTotal);

            return ret;
        }

        [HttpGet]
        [Route("sepultamento/termosdatalimite/{dataInicial}/{dataFinal}")]
        public IList<Sepultamento> ListarTermosDataLimite(DateTime dataInicial, DateTime dataFinal)
        {
            return BOAccess.getBOFactory().SepultamentoBO().ListarTermosDataLimite(dataInicial, dataFinal);
        }
        [HttpGet]
        [Route("sepultamento/totais")]
        public IList<TotalAnual> GetTotais()
        {
            IList<TotalAnual> lst = new MapaSepultamentos().GetTotais();
            if (lst == null || lst.Count==0)
            {
                var message = "Nenhuma informação encontrada.";
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
            return lst;
        }

        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="cidadao">O(A) cidadao.</param>
        /// <returns>A lista.</returns>
        [HttpPost]
        [Route("sepultamento/listarporcidadao")]
        public IList<CemQuintas.OR.Sepultamento> ListarPorCidadao(Cidadao cidadao)
        {
            return BOAccess.getBOFactory().SepultamentoBO().ListarPorCidadao(cidadao);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="cartorio">O(A) cartorio.</param>
        /// <returns>A lista.</returns>
        [HttpPost]
        [Route("sepultamento/listarporcartorio")]
        public IList<CemQuintas.OR.Sepultamento> ListarPorCartorio(Cartorio cartorio)
        {
            return BOAccess.getBOFactory().SepultamentoBO().ListarPorCartorio(cartorio);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="quadro">O(A) quadro.</param>
        /// <returns>A lista.</returns>
        [HttpPost]
        [Route("sepultamento/listarporquadro")]
        public IList<CemQuintas.OR.Sepultamento> ListarPorQuadro(Quadro quadro)
        {
            return BOAccess.getBOFactory().SepultamentoBO().ListarPorQuadro(quadro);
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="quadra">O(A) quadra.</param>
        /// <returns>A lista.</returns>
        [HttpPost]
        [Route("sepultamento/listarporquadra")]
        public IList<CemQuintas.OR.Sepultamento> ListarPorQuadra(Quadra quadra)
        {
            return BOAccess.getBOFactory().SepultamentoBO().ListarPorQuadra(quadra);
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        [HttpGet]
        [Route("sepultamento/selecionarporid/{id}")]
        public CemQuintas.OR.Sepultamento SelecionarPorId(long id)
        {
            return BOAccess.getBOFactory().SepultamentoBO().SelecionarPorId(id);
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        [HttpGet]
        [Route("sepultamento/pesquisarpornumeroiml/{numeroIML}/{page}")]
        public IList<Pesquisa> ListarporNumeroIml(string numeroIml, int page)
        {
            IList lst = BOAccess.getBOFactory().SepultamentoBO().ListarPorNumeroIml(numeroIml, page);
            return getListPesquisa(lst);
        }
        /// <summary>
        /// Inserir um objeto no banco de dados.
        /// </summary>
        /// <param name="sepultamento">O(A) sepultamento.</param>
        /// <returns>O objeto após a persistência.</returns>
        [HttpPost]
        [Route("sepultamento/inserir")]
        public CemQuintas.OR.Sepultamento Inserir(CemQuintas.OR.Sepultamento sepultamento)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            return BOAccess.getBOFactory().SepultamentoBO().InserirAlterar(u, sepultamento, Regisoft.Operacao.Incluir);
        }
        /// <summary>
        /// Altera um objeto no banco de dados.
        /// </summary>
        /// <param name="sepultamento">O(A) sepultamento.</param>
        /// <returns>O objeto após a persistência.</returns>
        [HttpPut]
        [Route("sepultamento/alterar")]
        public CemQuintas.OR.Sepultamento Alterar(CemQuintas.OR.Sepultamento sepultamento)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            return BOAccess.getBOFactory().SepultamentoBO().InserirAlterar(u, sepultamento, Regisoft.Operacao.Alterar);
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="sepultamento">O(A) sepultamento.</param>
        [HttpDelete]
        [Route("sepultamento/excluir/{id}")]
        public void Excluir(long id)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            CemQuintas.OR.Sepultamento sepultamento = BOAccess.getBOFactory().SepultamentoBO().SelecionarPorId(id);
            BOAccess.getBOFactory().SepultamentoBO().Excluir(u, sepultamento);
        }
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="lst">A lista.</param>
        [HttpDelete]
        [Route("sepultamento/excluirlista")]
        public void Excluir(IList<CemQuintas.OR.Sepultamento> lst)
        {
            CemQuintas.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
            BOAccess.getBOFactory().SepultamentoBO().Excluir(u, lst);
        }
        [HttpGet]
        [Route("sepultamento/produtividade/{login}/{dataInicio}/{dataFim}")]
        public HttpResponseMessage ListagemProdutividade(string login, DateTime dataInicio, DateTime dataFim)
        {
            IList<CemQuintas.OR.Sepultamento> lst = BOAccess.getBOFactory().SepultamentoBO().ListarProdutividade(login, dataInicio, dataFim);

            string arq_frf = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath) + "\\Emissoes\\EmissaoProdutividade.rdlc";
            DataTable dt = new DataSet1().dtListagem.Clone();
            foreach (CemQuintas.OR.Sepultamento s in lst)
            {
                DataRow dr = dt.NewRow();
                string nome = s.IdCidadao.Nome + (s.NumeroIml != null ? " - Nº IML: " + s.NumeroIml : string.Empty);
                dr.ItemArray = new object[] { string.Format("{0}/{1}", s.NumeroControle, s.Ano.ToString().Substring(2, 2)), nome, s.DataHoraSepultamento, s.DataGuia != null ? s.DataGuia.Value.ToShortDateString() : string.Empty, s.DataTermo != null ? s.DataTermo.Value.ToShortDateString() : string.Empty };
                dt.Rows.Add(dr);
            }
            IList<ReportParameter> lstParam = new List<ReportParameter>();
            lstParam.Add(new ReportParameter("digitador", "(login: " + login + ")"));
            byte[] bytes = Regisoft.ReportViewerExport.ExportarBytesPDF(arq_frf, "DataSet1_dtListagem", dt, lstParam);
            return getHttpResponseMessage(bytes, "pdf");
        }
        [HttpGet]
        [Route("sepultamento/listagem/{dataInicio}/{dataFim}")]
        public HttpResponseMessage Listagem(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                IList<CemQuintas.OR.Sepultamento> lst = BOAccess.getBOFactory().SepultamentoBO().Listar(dataInicio, dataFim);
                return getListagem(lst);
            }
            catch (ExceptionRS E)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, E.Message));
            }
        }
        [HttpGet]
        [Route("sepultamento/listagem/{ano}/{inicio}/{fim}")]
        public HttpResponseMessage Listagem(int ano, int inicio, int fim)
        {
            IList<CemQuintas.OR.Sepultamento> lst = BOAccess.getBOFactory().SepultamentoBO().Listar(ano, inicio, fim);
            return getListagem(lst);
        }
        [HttpGet]
        [Route("sepultamento/exportacao/{dataInicio}/{dataFim}")]
        public HttpResponseMessage Exportacao(DateTime dataInicio, DateTime dataFim)
        {
            IList<CemQuintas.OR.Sepultamento> lst = BOAccess.getBOFactory().SepultamentoBO().Listar(dataInicio, dataFim);

            string arq_frf = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath) + "\\Emissoes\\EmissaoExportacaoSepultamento.rdlc";
            DataTable dt = new DataSet1().Tables["dtExportacao"].Clone();
            foreach (CemQuintas.OR.Sepultamento s in lst)
            {
                DataRow dr = dt.NewRow();
                string nome = s.IdCidadao.Nome + (s.NumeroIml != null ? " - Nº IML: " + s.NumeroIml : string.Empty);
                dr.ItemArray = new object[] { string.Format("{0}/{1}", s.NumeroControle, s.Ano.ToString().Substring(2, 2)),
                    nome,
                    s.DataHoraSepultamento,
                    (s.IdCidadao.IdCidadeNaturalidade!=null?s.IdCidadao.IdCidadeNaturalidade.Descricao+"/":string.Empty)+(s.IdCidadao.IdCidadeNaturalidade!=null?s.IdCidadao.IdCidadeNaturalidade.IdUf.Sigla:string.Empty),
                    (s.IdCidadao.Idade!=null?s.IdCidadao.Idade.Value.ToString()+" ":string.Empty)+(s.IdCidadao.Idade!=null?s.IdCidadao.ComplementoIdade:string.Empty),
                    s.IdCidadao.NomeMae,
                    s.IdCidadao.NomePai};
                dt.Rows.Add(dr);
            }
            byte[] bytes = Regisoft.ReportViewerExport.ExportarBytesEXCEL(arq_frf, "DataSet1_dtExportacao", dt, null);
            return getHttpResponseMessage(bytes, "xls");
        }
        private HttpResponseMessage getListagem(IList<Sepultamento> lst)
        {
            string arq_frf = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath) + "\\Emissoes\\EmissaoListagemSepultamento.rdlc";
            DataTable dt = new DataSet1().Tables["dtListagem"].Clone();
            foreach (CemQuintas.OR.Sepultamento s in lst)
            {
                DataRow dr = dt.NewRow();
                string nome = s.IdCidadao.Nome + (s.NumeroIml != null ? " - Nº IML: " + s.NumeroIml : string.Empty);
                string quadro_quadra = String.Empty;
                string cova_carneira = String.Empty;
                if (s.CovaCarneira == "1")
                {
                    quadro_quadra = s.IdQuadro != null ? s.IdQuadro.Descricao : string.Empty;
                    cova_carneira = s.Cova;
                }
                else
                {
                    quadro_quadra = s.IdQuadra != null ? s.IdQuadra.Descricao : string.Empty;
                    cova_carneira = s.Carneira;
                }

                dr.ItemArray = new object[] { string.Format("{0}/{1}", s.NumeroControle, s.Ano.ToString().Substring(2, 2)), nome, s.DataHoraSepultamento, quadro_quadra, cova_carneira };
                dt.Rows.Add(dr);
            }
            byte[] bytes = Regisoft.ReportViewerExport.ExportarBytesPDF(arq_frf, "DataSet1_dtListagem", dt, null);
            return getHttpResponseMessage(bytes, "pdf");
        }

        private HttpResponseMessage getHttpResponseMessage(byte[] bytes, string extensao)
        {
            string docFile = "document." + extensao;
            //Create HTTP Response.  
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            //Set the Response Content.  
            response.Content = new ByteArrayContent(bytes);
            //Set the Response Content Length.  
            response.Content.Headers.ContentLength = bytes.LongLength;
            //Set the Content Disposition Header Value and FileName.  
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = docFile;
            //Set the File Content Type.  
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(docFile));
            return response;
        }

        private IList<Pesquisa> getListPesquisa(IList lst)
        {
            List<Pesquisa> lstPesquisa = new List<Pesquisa>();
            foreach (System.Array a in lst)
            {
                Pesquisa p = new Pesquisa()
                {
                    IdSepultamento = Convert.ToInt64(a.GetValue(0)),
                    NumeroControle = a.GetValue(1).ToString(),
                    Ano = Convert.ToInt32(a.GetValue(2)),
                    Cidade = a.GetValue(3) != null ? a.GetValue(3).ToString() : null,
                    Uf = a.GetValue(4) != null ? a.GetValue(4).ToString() : null,
                    CausaObito = a.GetValue(5) != null ? a.GetValue(5).ToString() : null,
                    Nome = a.GetValue(6).ToString()
                };
                lstPesquisa.Add(p);
            }
            return lstPesquisa;

        }
    }
}
