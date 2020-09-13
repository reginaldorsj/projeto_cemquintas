using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Uf
	{
		

		
		#region Private Members		

		private long? _id_uf; 
		private string _sigla; 
		private string _descricao; 		
		#endregion

		
		
		#region Constructor

		public Uf()
		{
			_id_uf = null; 
			_sigla = null;
			_descricao = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdUf
		{
			get
			{ 
				return _id_uf;
			}
			set
			{
				_id_uf = value;
			}

		}
			




		public virtual string Sigla
		{
			get
			{ 
				return _sigla;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Sigla'");
				
				if(  value.Length > 2)
					throw new ExceptionRS("Valor ultrapassa limite em 'Sigla'");					

				_sigla = value;
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
			Uf castObj = (Uf)obj; 
			return ( castObj != null ) &&
				( this._id_uf == castObj.IdUf );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_uf.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
