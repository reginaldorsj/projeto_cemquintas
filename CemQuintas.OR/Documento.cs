using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Documento
	{
		

		
		#region Private Members		

		private long? _id_documento; 
		private string _descricao; 		
		#endregion

		
		
		#region Constructor

		public Documento()
		{
			_id_documento = null; 
			_descricao = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdDocumento
		{
			get
			{ 
				return _id_documento;
			}
			set
			{
				_id_documento = value;
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
				
				if(  value.Length > 10)
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
			Documento castObj = (Documento)obj; 
			return ( castObj != null ) &&
				( this._id_documento == castObj.IdDocumento );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_documento.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
