using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Usuario
	{
		

		
		#region Private Members		

		private long? _id_usuario; 
		private string _nome; 
		private string _login; 
		private string _senha; 
		private Perfil _id_perfil; 
		private DateTime? _data_ultimo_acesso; 
		private DateTime _data_senha; 		
		#endregion

		
		
		#region Constructor

		public Usuario()
		{
			_id_usuario = null; 
			_nome = null;
			_login = null;
			_senha = null;
			_id_perfil = null; 
			_data_ultimo_acesso = null; 
			_data_senha = Convert.ToDateTime("1/1/1800");
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdUsuario
		{
			get
			{ 
				return _id_usuario;
			}
			set
			{
				_id_usuario = value;
			}

		}
			
		public virtual string Nome
		{
			get
			{ 
				return _nome;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Nome'");
				
				if(  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'Nome'");					

				_nome = value;
			}
		}
			
		public virtual string Login
		{
			get
			{ 
				return _login;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Login'");
				
				if(  value.Length > 20)
					throw new ExceptionRS("Valor ultrapassa limite em 'Login'");					

				_login = value;
			}
		}
			
		public virtual string Senha
		{
			get
			{ 
				return _senha;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Senha'");
				
				if(  value.Length > 20)
					throw new ExceptionRS("Valor ultrapassa limite em 'Senha'");					

				_senha = value;
			}
		}
			
		public virtual Perfil IdPerfil
		{
			get
			{ 
				return _id_perfil;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'IdPerfil'");

				_id_perfil = value;
			}

		}
			
		public virtual DateTime? DataUltimoAcesso
		{
			get
			{ 
				return _data_ultimo_acesso;
			}
			set
			{
				_data_ultimo_acesso = value;
			}

		}
			
		public virtual DateTime DataSenha
		{
			get
			{ 
				return _data_senha;
			}
			set
			{
				_data_senha = value;
			}

		}
			
		#endregion 
		
		
		#region Public Functions

		#endregion

		
		
		#region Equals And HashCode Overrides
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			Usuario castObj = (Usuario)obj; 
			return ( castObj != null ) &&
				( this._id_usuario == castObj.IdUsuario );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_usuario.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
