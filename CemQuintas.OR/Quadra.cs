using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Quadra
	{
		

		
		#region Private Members		

		private long? _id_quadra; 
		private string _descricao; 		
		#endregion

		
		
		#region Constructor

		public Quadra()
		{
			_id_quadra = null; 
			_descricao = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdQuadra
		{
			get
			{ 
				return _id_quadra;
			}
			set
			{
				_id_quadra = value;
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
				
				if(  value.Length > 50)
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
			Quadra castObj = (Quadra)obj; 
			return ( castObj != null ) &&
				( this._id_quadra == castObj.IdQuadra );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_quadra.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
