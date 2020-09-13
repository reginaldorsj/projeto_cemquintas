
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
	/// Regras de negócio para gerenciamento da classe <see cref='RacaBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class RacaBO : MarshalByRefObject, CemQuintas.BO.IRacaBO
	{
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected IRacaDAO racaDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="RacaBO"/>.
		/// </summary>
		public RacaBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			racaDAO = daoAccess.RacaDAO();
			this.usuarioBO = usuarioBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="RacaBO"/> is reclaimed by garbage collection.
		/// </summary>
		~RacaBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			racaDAO.Dispose();
			usuarioBO.Dispose();
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CemQuintas.OR.Raca> lst)
		{
			return racaDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Raca SelecionarPor(string propertyName, object value)
		{
			return racaDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Raca SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return racaDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Raca SelecionarPor(string[] propertyName, object[] value)
		{
			return racaDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Raca SelecionarPorId(object id)
		{
			return racaDAO.SelecionarPor("IdRaca",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CemQuintas.OR.Raca> Listar(string propertyOrder)
		{
			return racaDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="raca">O(A) raca.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CemQuintas.OR.Raca InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Raca raca, Regisoft.Operacao op)
		{
			racaDAO.ValidaNotNull(raca);
			racaDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					raca = racaDAO.CopiarParaPersistente(raca.IdRaca.Value,raca);
				raca = racaDAO.InserirAlterar(raca,op);
				racaDAO.CommitTransaction();				
			}			
			catch
			{
				racaDAO.RollbackTransaction();
				throw;
			}				
			return raca;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="raca">O(A) raca.</param>
		public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Raca raca)
		{
			racaDAO.BeginTransaction();
			try 
			{
				racaDAO.Excluir(raca);
				racaDAO.CommitTransaction();				
			}			
			catch
			{
				racaDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Raca> lst)
		{
			racaDAO.BeginTransaction();
			try 
			{
				foreach (CemQuintas.OR.Raca raca in lst)
				{
					racaDAO.Excluir(raca);
				}
				racaDAO.CommitTransaction();				
			}			
			catch
			{
				racaDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Raca> ListarPor(string dado)
		{
			return racaDAO.ListarPor(dado);
		}
	}
}
