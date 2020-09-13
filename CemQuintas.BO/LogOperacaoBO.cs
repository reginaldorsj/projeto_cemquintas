
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
	/// Regras de negócio para gerenciamento da classe <see cref='LogOperacaoBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class LogOperacaoBO : MarshalByRefObject, CemQuintas.BO.ILogOperacaoBO
	{
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected ILogOperacaoDAO logoperacaoDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="LogOperacaoBO"/>.
		/// </summary>
		public LogOperacaoBO()
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			logoperacaoDAO = daoAccess.LogOperacaoDAO();
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="LogOperacaoBO"/> is reclaimed by garbage collection.
		/// </summary>
		~LogOperacaoBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			logoperacaoDAO.Dispose();
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CemQuintas.OR.LogOperacao> lst)
		{
			return logoperacaoDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.LogOperacao SelecionarPor(string propertyName, object value)
		{
			return logoperacaoDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.LogOperacao SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return logoperacaoDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.LogOperacao SelecionarPor(string[] propertyName, object[] value)
		{
			return logoperacaoDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.LogOperacao SelecionarPorId(object id)
		{
			return logoperacaoDAO.SelecionarPor("IdLogOperacao",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CemQuintas.OR.LogOperacao> Listar(string propertyOrder)
		{
			return logoperacaoDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="logoperacao">O(A) logoperacao.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CemQuintas.OR.LogOperacao InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.LogOperacao logoperacao, Regisoft.Operacao op)
		{
			logoperacaoDAO.ValidaNotNull(logoperacao);
			logoperacaoDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					logoperacao = logoperacaoDAO.CopiarParaPersistente(logoperacao.IdLogOperacao.Value,logoperacao);
				logoperacao = logoperacaoDAO.InserirAlterar(logoperacao,op);
				logoperacaoDAO.CommitTransaction();				
			}			
			catch
			{
				logoperacaoDAO.RollbackTransaction();
				throw;
			}				
			return logoperacao;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="logoperacao">O(A) logoperacao.</param>
		public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.LogOperacao logoperacao)
		{
			logoperacaoDAO.BeginTransaction();
			try 
			{
				logoperacaoDAO.Excluir(logoperacao);
				logoperacaoDAO.CommitTransaction();				
			}			
			catch
			{
				logoperacaoDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.LogOperacao> lst)
		{
			logoperacaoDAO.BeginTransaction();
			try 
			{
				foreach (CemQuintas.OR.LogOperacao logoperacao in lst)
				{
					logoperacaoDAO.Excluir(logoperacao);
				}
				logoperacaoDAO.CommitTransaction();				
			}			
			catch
			{
				logoperacaoDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<LogOperacao> ListarPor(string dado)
		{
			return logoperacaoDAO.ListarPor(dado);
		}
		private void Lancar(object obj, Usuario u, string operacao, string ip)
		{
			ToolsBO.In("Operação", operacao, new string[] { "I", "A", "E", "L" });

			LogOperacao l = new LogOperacao();
			l.Dados = stringf.ToBytes(Serializador.Serializar(obj));
			l.DataHora = DateTime.Now;
			l.Ip = ip;
			l.Nome = u.Nome;
			l.Login = u.Login;
			l.Operacao = operacao;

			InserirAlterar(null, l, Operacao.Incluir);
		}
		public void LancarInclusao(object obj, Usuario u)
		{
			Lancar(obj, u, "I", null);
		}
		public void LancarAlteracao(object obj, Usuario u)
		{
			Lancar(obj, u, "A", null);
		}
		public void LancarExclusao(object obj, Usuario u)
		{
			Lancar(obj, u, "E", null);
		}
		public void LancarLogin(object obj, Usuario u, string ip)
		{
			Lancar(obj, u, "L", ip);
		}

	}
}
