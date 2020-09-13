using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Responsavel
	{
		

		
		#region Private Members		

		private long? _id_responsavel; 
		private string _nome; 
		private string _telefone; 
		private string _pai; 
		private string _mae; 
		private string _endereco; 
		private Uf _id_uf; 
		private string _rg; 
		private DateTime? _data_rg; 
		private Cidade _id_cidade_naturalidade; 		
		#endregion

		
		
		#region Constructor

		public Responsavel()
		{
			_id_responsavel = null; 
			_nome = null;
			_telefone = null;
			_pai = null;
			_mae = null;
			_endereco = null;
			_id_uf = null; 
			_rg = null;
			_data_rg = null; 
			_id_cidade_naturalidade = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdResponsavel
		{
			get
			{ 
				return _id_responsavel;
			}
			set
			{
				_id_responsavel = value;
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
			
		public virtual string Pai
		{
			get
			{ 
				return _pai;
			}

			set	
			{	
				if(  value != null &&  value.Length > 60)
					throw new ExceptionRS("Valor ultrapassa limite em 'Pai'");					

				_pai = value;
			}
		}
			
		public virtual string Mae
		{
			get
			{ 
				return _mae;
			}

			set	
			{	
				if(  value != null &&  value.Length > 60)
					throw new ExceptionRS("Valor ultrapassa limite em 'Mae'");					

				_mae = value;
			}
		}
			
		public virtual string Endereco
		{
			get
			{ 
				return _endereco;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'Endereco'");					

				_endereco = value;
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
				_id_uf = value;
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
			
		public virtual DateTime? DataRg
		{
			get
			{ 
				return _data_rg;
			}
			set
			{
				_data_rg = value;
			}

		}
			
		public virtual Cidade IdCidadeNaturalidade
		{
			get
			{ 
				return _id_cidade_naturalidade;
			}
			set
			{
				_id_cidade_naturalidade = value;
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
			Responsavel castObj = (Responsavel)obj; 
			return ( castObj != null ) &&
				( this._id_responsavel == castObj.IdResponsavel );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_responsavel.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
