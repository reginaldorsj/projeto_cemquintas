
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
	/// Regras de negócio para gerenciamento da classe <see cref='QuadroBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class QuadroBO : MarshalByRefObject, CemQuintas.BO.IQuadroBO
	{
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected IQuadroDAO quadroDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="QuadroBO"/>.
		/// </summary>
		public QuadroBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			quadroDAO = daoAccess.QuadroDAO();
			this.usuarioBO = usuarioBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="QuadroBO"/> is reclaimed by garbage collection.
		/// </summary>
		~QuadroBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			quadroDAO.Dispose();
			usuarioBO.Dispose();
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CemQuintas.OR.Quadro> lst)
		{
			return quadroDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Quadro SelecionarPor(string propertyName, object value)
		{
			return quadroDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Quadro SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return quadroDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Quadro SelecionarPor(string[] propertyName, object[] value)
		{
			return quadroDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Quadro SelecionarPorId(object id)
		{
			return quadroDAO.SelecionarPor("IdQuadro",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CemQuintas.OR.Quadro> Listar(string propertyOrder)
		{
			return quadroDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="quadro">O(A) quadro.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CemQuintas.OR.Quadro InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Quadro quadro, Regisoft.Operacao op)
		{
			if (!usuarioBO.EhDigitador(u))
				throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

			quadro.Descricao = quadro.Descricao.ToUpper();
			quadroDAO.ValidaNotNull(quadro);

			Quadro q_tmp = quadroDAO.SelecionarPor("Descricao", quadro.Descricao);
			if ((op == Operacao.Incluir && q_tmp != null) || (op == Operacao.Alterar && q_tmp != null && q_tmp.IdQuadro != quadro.IdQuadro))
				throw new ExceptionRS("Já existe quadro com esta descrição.");

			quadroDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					quadro = quadroDAO.CopiarParaPersistente(quadro.IdQuadro.Value,quadro);
				quadro = quadroDAO.InserirAlterar(quadro,op);
				quadroDAO.CommitTransaction();				
			}			
			catch
			{
				quadroDAO.RollbackTransaction();
				throw;
			}				
			return quadro;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="quadro">O(A) quadro.</param>
		public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Quadro quadro)
		{
			if (!usuarioBO.EhDigitador(u))
				throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

			quadroDAO.BeginTransaction();
			try 
			{
				quadroDAO.Excluir(quadro);
				quadroDAO.CommitTransaction();				
			}			
			catch
			{
				quadroDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Quadro> lst)
		{
			if (!usuarioBO.EhDigitador(u))
				throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

			quadroDAO.BeginTransaction();
			try 
			{
				foreach (CemQuintas.OR.Quadro quadro in lst)
				{
					quadroDAO.Excluir(quadro);
				}
				quadroDAO.CommitTransaction();				
			}			
			catch
			{
				quadroDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Quadro> ListarPor(string dado)
		{
			return quadroDAO.ListarPor(dado);
		}
	}
}
