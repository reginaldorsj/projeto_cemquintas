
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
	/// Regras de negócio para gerenciamento da classe <see cref='TipoLogradouroBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class TipoLogradouroBO : MarshalByRefObject, CemQuintas.BO.ITipoLogradouroBO
	{
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected ITipoLogradouroDAO tipologradouroDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="TipoLogradouroBO"/>.
		/// </summary>
		public TipoLogradouroBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			tipologradouroDAO = daoAccess.TipoLogradouroDAO();
			this.usuarioBO = usuarioBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="TipoLogradouroBO"/> is reclaimed by garbage collection.
		/// </summary>
		~TipoLogradouroBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			tipologradouroDAO.Dispose();
			usuarioBO.Dispose();
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CemQuintas.OR.TipoLogradouro> lst)
		{
			return tipologradouroDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.TipoLogradouro SelecionarPor(string propertyName, object value)
		{
			return tipologradouroDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.TipoLogradouro SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return tipologradouroDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.TipoLogradouro SelecionarPor(string[] propertyName, object[] value)
		{
			return tipologradouroDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.TipoLogradouro SelecionarPorId(object id)
		{
			return tipologradouroDAO.SelecionarPor("IdTipoLogradouro",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CemQuintas.OR.TipoLogradouro> Listar(string propertyOrder)
		{
			return tipologradouroDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="tipologradouro">O(A) tipologradouro.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CemQuintas.OR.TipoLogradouro InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.TipoLogradouro tipologradouro, Regisoft.Operacao op)
		{
			tipologradouroDAO.ValidaNotNull(tipologradouro);
			tipologradouroDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					tipologradouro = tipologradouroDAO.CopiarParaPersistente(tipologradouro.IdTipoLogradouro.Value,tipologradouro);
				tipologradouro = tipologradouroDAO.InserirAlterar(tipologradouro,op);
				tipologradouroDAO.CommitTransaction();				
			}			
			catch
			{
				tipologradouroDAO.RollbackTransaction();
				throw;
			}				
			return tipologradouro;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="tipologradouro">O(A) tipologradouro.</param>
		public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.TipoLogradouro tipologradouro)
		{
			tipologradouroDAO.BeginTransaction();
			try 
			{
				tipologradouroDAO.Excluir(tipologradouro);
				tipologradouroDAO.CommitTransaction();				
			}			
			catch
			{
				tipologradouroDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.TipoLogradouro> lst)
		{
			tipologradouroDAO.BeginTransaction();
			try 
			{
				foreach (CemQuintas.OR.TipoLogradouro tipologradouro in lst)
				{
					tipologradouroDAO.Excluir(tipologradouro);
				}
				tipologradouroDAO.CommitTransaction();				
			}			
			catch
			{
				tipologradouroDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<TipoLogradouro> ListarPor(string dado)
		{
			return tipologradouroDAO.ListarPor(dado);
		}
	}
}
