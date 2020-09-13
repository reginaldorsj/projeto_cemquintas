
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
	/// Regras de negócio para gerenciamento da classe <see cref='PerfilBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class PerfilBO : MarshalByRefObject, CemQuintas.BO.IPerfilBO
	{
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected IPerfilDAO perfilDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="PerfilBO"/>.
		/// </summary>
		public PerfilBO(IUsuarioBO usuarioBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			perfilDAO = daoAccess.PerfilDAO();
			this.usuarioBO = usuarioBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="PerfilBO"/> is reclaimed by garbage collection.
		/// </summary>
		~PerfilBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			perfilDAO.Dispose();
			usuarioBO.Dispose();
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CemQuintas.OR.Perfil> lst)
		{
			return perfilDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Perfil SelecionarPor(string propertyName, object value)
		{
			return perfilDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Perfil SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return perfilDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Perfil SelecionarPor(string[] propertyName, object[] value)
		{
			return perfilDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Perfil SelecionarPorId(object id)
		{
			return perfilDAO.SelecionarPor("IdPerfil",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CemQuintas.OR.Perfil> Listar(string propertyOrder)
		{
			return perfilDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="perfil">O(A) perfil.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CemQuintas.OR.Perfil InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Perfil perfil, Regisoft.Operacao op)
		{
			perfilDAO.ValidaNotNull(perfil);
			Perfil _ix_perfil = perfilDAO.SelecionarPor(new string[]{ "Descricao" }, new object[]{ perfil.Descricao });
			 if ((op == Operacao.Incluir && _ix_perfil != null) ||(op == Operacao.Alterar && _ix_perfil != null && _ix_perfil.IdPerfil != perfil.IdPerfil))
				throw new ExceptionRS("Violação do índice: IX_PERFIL");

			perfilDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					perfil = perfilDAO.CopiarParaPersistente(perfil.IdPerfil.Value,perfil);
				perfil = perfilDAO.InserirAlterar(perfil,op);
				perfilDAO.CommitTransaction();				
			}			
			catch
			{
				perfilDAO.RollbackTransaction();
				throw;
			}				
			return perfil;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="perfil">O(A) perfil.</param>
		public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Perfil perfil)
		{
			perfilDAO.BeginTransaction();
			try 
			{
				perfilDAO.Excluir(perfil);
				perfilDAO.CommitTransaction();				
			}			
			catch
			{
				perfilDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Perfil> lst)
		{
			perfilDAO.BeginTransaction();
			try 
			{
				foreach (CemQuintas.OR.Perfil perfil in lst)
				{
					perfilDAO.Excluir(perfil);
				}
				perfilDAO.CommitTransaction();				
			}			
			catch
			{
				perfilDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Perfil> ListarPor(string dado)
		{
			return perfilDAO.ListarPor(dado);
		}
	}
}
