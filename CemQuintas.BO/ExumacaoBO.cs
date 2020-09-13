
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
	/// Regras de negócio para gerenciamento da classe <see cref='ExumacaoBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class ExumacaoBO : MarshalByRefObject, CemQuintas.BO.IExumacaoBO
	{
		protected ILogOperacaoBO logBO;
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected IExumacaoDAO exumacaoDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="ExumacaoBO"/>.
		/// </summary>
		public ExumacaoBO(IUsuarioBO usuarioBO, ILogOperacaoBO logBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			exumacaoDAO = daoAccess.ExumacaoDAO();
			this.usuarioBO = usuarioBO;
			this.logBO = logBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="ExumacaoBO"/> is reclaimed by garbage collection.
		/// </summary>
		~ExumacaoBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			exumacaoDAO.Dispose();
			usuarioBO.Dispose();
			logBO.Dispose();
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sepultamento">O(A) sepultamento.</param>
		/// <returns>A lista.</returns>
		public IList<CemQuintas.OR.Exumacao> ListarPorSepultamento(Sepultamento sepultamento)
		{
			return exumacaoDAO.ListarPorSepultamento(sepultamento);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		public IList<CemQuintas.OR.Exumacao> ListarPorUf(Uf uf)
		{
			return exumacaoDAO.ListarPorUf(uf);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		public IList<CemQuintas.OR.Exumacao> ListarPorCidade(Cidade cidade)
		{
			return exumacaoDAO.ListarPorCidade(cidade);
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CemQuintas.OR.Exumacao> lst)
		{
			return exumacaoDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Exumacao SelecionarPor(string propertyName, object value)
		{
			return exumacaoDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Exumacao SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return exumacaoDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Exumacao SelecionarPor(string[] propertyName, object[] value)
		{
			return exumacaoDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Exumacao SelecionarPorId(object id)
		{
			return exumacaoDAO.SelecionarPor("IdExumacao",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CemQuintas.OR.Exumacao> Listar(string propertyOrder)
		{
			return exumacaoDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="exumacao">O(A) exumacao.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CemQuintas.OR.Exumacao InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Exumacao exumacao, Regisoft.Operacao op)
		{
			if (!usuarioBO.EhDigitador(u))
				throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

			if (op == Operacao.Incluir)
				exumacao.DataDigitacao = DateTime.Now;
            else
            {
				Exumacao e_tmp = exumacaoDAO.SelecionarPorId(exumacao.IdExumacao.Value);
				exumacao.DataDigitacao = e_tmp.DataDigitacao;
            }

			exumacaoDAO.ValidaNotNull(exumacao);
			exumacaoDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					exumacao = exumacaoDAO.CopiarParaPersistente(exumacao.IdExumacao.Value,exumacao);
				exumacao = exumacaoDAO.InserirAlterar(exumacao,op);

				if (op == Regisoft.Operacao.Incluir)
					logBO.LancarInclusao(exumacao, u);
				else
					logBO.LancarAlteracao(exumacao, u);

				exumacaoDAO.CommitTransaction();				
			}			
			catch
			{
				exumacaoDAO.RollbackTransaction();
				throw;
			}				
			return exumacao;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="exumacao">O(A) exumacao.</param>
		public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Exumacao exumacao)
		{
			if (!usuarioBO.EhDigitador(u))
				throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

			exumacaoDAO.BeginTransaction();
			try 
			{
				exumacaoDAO.Excluir(exumacao);
				logBO.LancarExclusao(exumacao, u);

				exumacaoDAO.CommitTransaction();				
			}			
			catch
			{
				exumacaoDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Exumacao> lst)
		{
			exumacaoDAO.BeginTransaction();
			try 
			{
				foreach (CemQuintas.OR.Exumacao exumacao in lst)
				{
					exumacaoDAO.Excluir(exumacao);
				}
				exumacaoDAO.CommitTransaction();				
			}			
			catch
			{
				exumacaoDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Exumacao> ListarPor(string dado)
		{
			return exumacaoDAO.ListarPor(dado);
		}
	}
}
