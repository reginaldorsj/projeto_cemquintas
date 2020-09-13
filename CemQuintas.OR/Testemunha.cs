using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Testemunha
	{
		

		
		#region Private Members		

		private long? _id_testemunha; 
		private string _nome; 
		private string _rg; 
		private string _telefone; 		
		#endregion

		
		
		#region Constructor

		public Testemunha()
		{
			_id_testemunha = null; 
			_nome = null;
			_rg = null;
			_telefone = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdTestemunha
		{
			get
			{ 
				return _id_testemunha;
			}
			set
			{
				_id_testemunha = value;
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
			
		public virtual string Rg
		{
			get
			{ 
				return _rg;
			}

			set	
			{	
				if(  value != null &&  value.Length > 15)
					throw new ExceptionRS("Valor ultrapassa limite em 'Rg'");					

				_rg = value;
			}
		}
			
		public virtual string Telefone
		{
			get
			{ 
				return _telefone;
			}

			set	
			{	
				if(  value != null &&  value.Length > 25)
					throw new ExceptionRS("Valor ultrapassa limite em 'Telefone'");					

				_telefone = value;
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
			Testemunha castObj = (Testemunha)obj; 
			return ( castObj != null ) &&
				( this._id_testemunha == castObj.IdTestemunha );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_testemunha.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
