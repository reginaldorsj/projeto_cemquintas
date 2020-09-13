using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Sexo
	{
		

		
		#region Private Members		

		private long? _id_sexo; 
		private string _descricao; 		
		#endregion

		
		
		#region Constructor

		public Sexo()
		{
			_id_sexo = null; 
			_descricao = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdSexo
		{
			get
			{ 
				return _id_sexo;
			}
			set
			{
				_id_sexo = value;
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
			Sexo castObj = (Sexo)obj; 
			return ( castObj != null ) &&
				( this._id_sexo == castObj.IdSexo );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_sexo.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
