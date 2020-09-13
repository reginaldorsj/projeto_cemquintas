using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Funeraria
	{
		

		
		#region Private Members		

		private long? _id_funeraria; 
		private string _nome; 		
		#endregion

		
		
		#region Constructor

		public Funeraria()
		{
			_id_funeraria = null; 
			_nome = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdFuneraria
		{
			get
			{ 
				return _id_funeraria;
			}
			set
			{
				_id_funeraria = value;
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
				
				if(  value.Length > 60)
					throw new ExceptionRS("Valor ultrapassa limite em 'Nome'");					

				_nome = value;
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
			Funeraria castObj = (Funeraria)obj; 
			return ( castObj != null ) &&
				( this._id_funeraria == castObj.IdFuneraria );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_funeraria.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
