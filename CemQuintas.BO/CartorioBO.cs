
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
	/// Regras de negócio para gerenciamento da classe <see cref='CartorioBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class CartorioBO : MarshalByRefObject, CemQuintas.BO.ICartorioBO
	{
		protected ILogOperacaoBO logBO;
		/// <summary>
		/// Define o objeto de controle de usuario.
		/// </summary>
		protected IUsuarioBO usuarioBO;
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected ICartorioDAO cartorioDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="CartorioBO"/>.
		/// </summary>
		public CartorioBO(IUsuarioBO usuarioBO, ILogOperacaoBO logBO)
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			cartorioDAO = daoAccess.CartorioDAO();
			this.usuarioBO = usuarioBO;
			this.logBO = logBO;
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="CartorioBO"/> is reclaimed by garbage collection.
		/// </summary>
		~CartorioBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			cartorioDAO.Dispose();
			usuarioBO.Dispose();
			logBO.Dispose();
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="tipologradouro">O(A) tipologradouro.</param>
		/// <returns>A lista.</returns>
		public IList<CemQuintas.OR.Cartorio> ListarPorTipoLogradouro(TipoLogradouro tipologradouro)
		{
			return cartorioDAO.ListarPorTipoLogradouro(tipologradouro);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <returns>A lista.</returns>
		public IList<CemQuintas.OR.Cartorio> ListarPorCidade(Cidade cidade)
		{
			return cartorioDAO.ListarPorCidade(cidade);
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<CemQuintas.OR.Cartorio> lst)
		{
			return cartorioDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Cartorio SelecionarPor(string propertyName, object value)
		{
			return cartorioDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Cartorio SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return cartorioDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Cartorio SelecionarPor(string[] propertyName, object[] value)
		{
			return cartorioDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public CemQuintas.OR.Cartorio SelecionarPorId(object id)
		{
			return cartorioDAO.SelecionarPor("IdCartorio",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<CemQuintas.OR.Cartorio> Listar(string propertyOrder)
		{
			return cartorioDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="cartorio">O(A) cartorio.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public CemQuintas.OR.Cartorio InserirAlterar(CemQuintas.OR.Usuario u, CemQuintas.OR.Cartorio cartorio, Regisoft.Operacao op)
		{
			if (!usuarioBO.EhDigitador(u))
				throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

			cartorio.Nome = stringf.UmEspacoEntre(cartorio.Nome).Trim().ToUpper();
			cartorio.Distrito = stringf.UmEspacoEntre(cartorio.Distrito).Trim().ToUpper();
			cartorioDAO.ValidaNotNull(cartorio);

			if (cartorio.Cep.Length != 8 || !stringf.ValidaNumeros(cartorio.Cep))
				throw new ExceptionRS("CEP inválido.");

			if (cartorio.IdCidade == null)
				throw new ExceptionRS("Informe a cidade.");

			cartorioDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					cartorio = cartorioDAO.CopiarParaPersistente(cartorio.IdCartorio.Value,cartorio);
				cartorio = cartorioDAO.InserirAlterar(cartorio,op);

				if (op == Regisoft.Operacao.Incluir)
					logBO.LancarInclusao(cartorio, u);
				else
					logBO.LancarAlteracao(cartorio, u);

				cartorioDAO.CommitTransaction();				
			}			
			catch
			{
				cartorioDAO.RollbackTransaction();
				throw;
			}				
			return cartorio;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="cartorio">O(A) cartorio.</param>
		public void Excluir(CemQuintas.OR.Usuario u, CemQuintas.OR.Cartorio cartorio)
		{
			if (!usuarioBO.EhDigitador(u))
				throw new ExceptionRS("Voce não tem permissão para realizar esta operação.");

			cartorioDAO.BeginTransaction();
			try 
			{
				cartorioDAO.Excluir(cartorio);
				logBO.LancarExclusao(cartorio, u);

				cartorioDAO.CommitTransaction();				
			}			
			catch
			{
				cartorioDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		public void Excluir(CemQuintas.OR.Usuario u, IList<CemQuintas.OR.Cartorio> lst)
		{
			cartorioDAO.BeginTransaction();
			try 
			{
				foreach (CemQuintas.OR.Cartorio cartorio in lst)
				{
					cartorioDAO.Excluir(cartorio);
				}
				cartorioDAO.CommitTransaction();				
			}			
			catch
			{
				cartorioDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Cartorio> ListarPor(string dado)
		{
			return cartorioDAO.ListarPor(dado);
		}
	}
}
