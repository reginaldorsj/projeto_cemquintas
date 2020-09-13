using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Raca
	{
		

		
		#region Private Members		

		private long? _id_raca; 
		private string _descricao; 		
		#endregion

		
		
		#region Constructor

		public Raca()
		{
			_id_raca = null; 
			_descricao = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdRaca
		{
			get
			{ 
				return _id_raca;
			}
			set
			{
				_id_raca = value;
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
				if(  value != null &&  value.Length > 50)
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
			Raca castObj = (Raca)obj; 
			return ( castObj != null ) &&
				( this._id_raca == castObj.IdRaca );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_raca.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
