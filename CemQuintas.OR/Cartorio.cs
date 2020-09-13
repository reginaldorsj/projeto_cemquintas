using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Cartorio
	{
		

		
		#region Private Members		

		private long? _id_cartorio; 
		private string _nome; 
		private string _distrito; 
		private TipoLogradouro _id_tipo_logradouro; 
		private string _logradouro; 
		private string _numero; 
		private string _bairro; 
		private string _cep; 
		private Cidade _id_cidade; 		
		#endregion

		
		
		#region Constructor

		public Cartorio()
		{
			_id_cartorio = null; 
			_nome = null;
			_distrito = null;
			_id_tipo_logradouro = null; 
			_logradouro = null;
			_numero = null;
			_bairro = null;
			_cep = null;
			_id_cidade = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdCartorio
		{
			get
			{ 
				return _id_cartorio;
			}
			set
			{
				_id_cartorio = value;
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
			
		public virtual string Distrito
		{
			get
			{ 
				return _distrito;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Distrito'");
				
				if(  value.Length > 35)
					throw new ExceptionRS("Valor ultrapassa limite em 'Distrito'");					

				_distrito = value;
			}
		}
			
		public virtual TipoLogradouro IdTipoLogradouro
		{
			get
			{ 
				return _id_tipo_logradouro;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'IdTipoLogradouro'");

				_id_tipo_logradouro = value;
			}

		}
			
		public virtual string Logradouro
		{
			get
			{ 
				return _logradouro;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Logradouro'");
				
				if(  value.Length > 75)
					throw new ExceptionRS("Valor ultrapassa limite em 'Logradouro'");					

				_logradouro = value;
			}
		}
			
		public virtual string Numero
		{
			get
			{ 
				return _numero;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Numero'");
				
				if(  value.Length > 15)
					throw new ExceptionRS("Valor ultrapassa limite em 'Numero'");					

				_numero = value;
			}
		}
			
		public virtual string Bairro
		{
			get
			{ 
				return _bairro;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Bairro'");
				
				if(  value.Length > 50)
					throw new ExceptionRS("Valor ultrapassa limite em 'Bairro'");					

				_bairro = value;
			}
		}
			
		public virtual string Cep
		{
			get
			{ 
				return _cep;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Cep'");
				
				if(  value.Length > 8)
					throw new ExceptionRS("Valor ultrapassa limite em 'Cep'");					

				_cep = value;
			}
		}
			
		public virtual Cidade IdCidade
		{
			get
			{ 
				return _id_cidade;
			}
			set
			{
				_id_cidade = value;
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
			Cartorio castObj = (Cartorio)obj; 
			return ( castObj != null ) &&
				( this._id_cartorio == castObj.IdCartorio );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_cartorio.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
