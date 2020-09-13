using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class TipoLogradouro
	{
		

		
		#region Private Members		

		private long? _id_tipo_logradouro; 
		private string _descricao; 		
		#endregion

		
		
		#region Constructor

		public TipoLogradouro()
		{
			_id_tipo_logradouro = null; 
			_descricao = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdTipoLogradouro
		{
			get
			{ 
				return _id_tipo_logradouro;
			}
			set
			{
				_id_tipo_logradouro = value;
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
				
				if(  value.Length > 20)
					throw new ExceptionRS("Valor ultrapassa limite em 'Descricao'");					

				_descricao = value;
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
			TipoLogradouro castObj = (TipoLogradouro)obj; 
			return ( castObj != null ) &&
				( this._id_tipo_logradouro == castObj.IdTipoLogradouro );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_tipo_logradouro.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
