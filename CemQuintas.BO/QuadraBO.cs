
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
	/// Regras de negócio para gerenciamento da classe <see cref='QuadraBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class QuadraBO : MarshalByRefObject, CemQuintas.BO.IQuadraBO
	{
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected IQuadraDAO quadraDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="QuadraBO"/>.
		/// </summary>
		public QuadraBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			quadraDAO = daoAccess.QuadraDAO();
			this.usuarioBO = usuarioBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="QuadraBO"/> is reclaimed by garbage collection.
		/// </summary>
		~QuadraBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			quadraDAO.Dispose();
			usuarioBO.Dispose();
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CemQuintas.OR.Quadra> lst)
		{
			return quadraDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Quadra SelecionarPor(string propertyName, object value)
		{
			return quadraDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Quadra SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return quadraDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Quadra SelecionarPor(string[] propertyName, object[] value)
		{
			return quadraDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Quadra SelecionarPorId(object id)
		{
			return quadraDAO.SelecionarPor("IdQuadra",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CemQuintas.OR.Quadra> Listar(string propertyOrder)
		{
			return quadraDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="quadra">O(A) quadra.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CemQuintas.OR.Quadra InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Quadra quadra, Regisoft.Operacao op)
		{
			if (!usuarioBO.EhDigitador(u))
				throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

			quadra.Descricao = quadra.Descricao.ToUpper();
			quadraDAO.ValidaNotNull(quadra);

			Quadra q_tmp = quadraDAO.SelecionarPor("Descricao", quadra.Descricao);
			if ((op == Operacao.Incluir && q_tmp != null) || (op == Operacao.Alterar && q_tmp != null && q_tmp.IdQuadra != quadra.IdQuadra))
				throw new ExceptionRS("Já existe quadra com esta descrição.");

			quadraDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					quadra = quadraDAO.CopiarParaPersistente(quadra.IdQuadra.Value,quadra);
				quadra = quadraDAO.InserirAlterar(quadra,op);
				quadraDAO.CommitTransaction();				
			}			
			catch
			{
				quadraDAO.RollbackTransaction();
				throw;
			}				
			return quadra;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="quadra">O(A) quadra.</param>
		public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Quadra quadra)
		{
			if (!usuarioBO.EhDigitador(u))
				throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

			quadraDAO.BeginTransaction();
			try 
			{
				quadraDAO.Excluir(quadra);
				quadraDAO.CommitTransaction();				
			}			
			catch
			{
				quadraDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Quadra> lst)
		{
			if (!usuarioBO.EhDigitador(u))
				throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

			quadraDAO.BeginTransaction();
			try 
			{
				foreach (CemQuintas.OR.Quadra quadra in lst)
				{
					quadraDAO.Excluir(quadra);
				}
				quadraDAO.CommitTransaction();				
			}			
			catch
			{
				quadraDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Quadra> ListarPor(string dado)
		{
			return quadraDAO.ListarPor(dado);
		}
	}
}
