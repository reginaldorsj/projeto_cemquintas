using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class LogOperacao
	{
		

		
		#region Private Members		

		private long? _id_log_operacao; 
		private DateTime _data_hora; 
		private string _ip; 
		private string _operacao; 
		private string _nome; 
		private string _login; 
		private byte[] _dados; 		
		#endregion

		
		
		#region Constructor

		public LogOperacao()
		{
			_id_log_operacao = null; 
			_data_hora = Convert.ToDateTime("1/1/1800");
			_ip = null;
			_operacao = null;
			_nome = null;
			_login = null;
			_dados =  null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdLogOperacao
		{
			get
			{ 
				return _id_log_operacao;
			}
			set
			{
				_id_log_operacao = value;
			}

		}
			
		public virtual DateTime DataHora
		{
			get
			{ 
				return _data_hora;
			}
			set
			{
				_data_hora = value;
			}

		}
			
		public virtual string Ip
		{
			get
			{ 
				return _ip;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ExceptionRS("Valor ultrapassa limite em 'Ip'");					

				_ip = value;
			}
		}
			
		public virtual string Operacao
		{
			get
			{ 
				return _operacao;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Operacao'");
				
				if(  value.Length > 1)
					throw new ExceptionRS("Valor ultrapassa limite em 'Operacao'");					

				_operacao = value;
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
			
		public virtual byte[] Dados
		{
			get
			{ 
				return _dados;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'Dados'");

				_dados = value;
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
			LogOperacao castObj = (LogOperacao)obj; 
			return ( castObj != null ) &&
				( this._id_log_operacao == castObj.IdLogOperacao );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_log_operacao.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
