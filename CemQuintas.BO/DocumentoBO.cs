
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
	/// Regras de negócio para gerenciamento da classe <see cref='DocumentoBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class DocumentoBO : MarshalByRefObject, CemQuintas.BO.IDocumentoBO
	{
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected IDocumentoDAO documentoDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="DocumentoBO"/>.
		/// </summary>
		public DocumentoBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			documentoDAO = daoAccess.DocumentoDAO();
			this.usuarioBO = usuarioBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="DocumentoBO"/> is reclaimed by garbage collection.
		/// </summary>
		~DocumentoBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			documentoDAO.Dispose();
			usuarioBO.Dispose();
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CemQuintas.OR.Documento> lst)
		{
			return documentoDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Documento SelecionarPor(string propertyName, object value)
		{
			return documentoDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Documento SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return documentoDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Documento SelecionarPor(string[] propertyName, object[] value)
		{
			return documentoDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Documento SelecionarPorId(object id)
		{
			return documentoDAO.SelecionarPor("IdDocumento",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CemQuintas.OR.Documento> Listar(string propertyOrder)
		{
			return documentoDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="documento">O(A) documento.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CemQuintas.OR.Documento InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Documento documento, Regisoft.Operacao op)
		{
			documentoDAO.ValidaNotNull(documento);
			documentoDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					documento = documentoDAO.CopiarParaPersistente(documento.IdDocumento.Value,documento);
				documento = documentoDAO.InserirAlterar(documento,op);
				documentoDAO.CommitTransaction();				
			}			
			catch
			{
				documentoDAO.RollbackTransaction();
				throw;
			}				
			return documento;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="documento">O(A) documento.</param>
		public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Documento documento)
		{
			documentoDAO.BeginTransaction();
			try 
			{
				documentoDAO.Excluir(documento);
				documentoDAO.CommitTransaction();				
			}			
			catch
			{
				documentoDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Documento> lst)
		{
			documentoDAO.BeginTransaction();
			try 
			{
				foreach (CemQuintas.OR.Documento documento in lst)
				{
					documentoDAO.Excluir(documento);
				}
				documentoDAO.CommitTransaction();				
			}			
			catch
			{
				documentoDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Documento> ListarPor(string dado)
		{
			return documentoDAO.ListarPor(dado);
		}
	}
}
