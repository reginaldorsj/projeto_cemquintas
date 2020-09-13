using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Cidade
	{
		

		
		#region Private Members		

		private long? _id_cidade; 
		private Uf _id_uf; 
		private string _descricao; 
		private string _cep; 		
		#endregion

		
		
		#region Constructor

		public Cidade()
		{
			_id_cidade = null; 
			_id_uf = null; 
			_descricao = null;
			_cep = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdCidade
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
			




		public virtual Uf IdUf
		{
			get
			{ 
				return _id_uf;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'IdUf'");

				_id_uf = value;
			}

		}
			
		public virtual string Descricao
		{
			get
			{ 
				return _descricao;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Descricao'");
				
				if(  value.Length > 72)
					throw new ExceptionRS("Valor ultrapassa limite em 'Descricao'");					

				_descricao = value;
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
				if(  value != null &&  value.Length > 8)
					throw new ExceptionRS("Valor ultrapassa limite em 'Cep'");					

				_cep = value;
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
			Cidade castObj = (Cidade)obj; 
			return ( castObj != null ) &&
				( this._id_cidade == castObj.IdCidade );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_cidade.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
