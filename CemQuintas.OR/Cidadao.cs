using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Cidadao
	{
		

		
		#region Private Members		

		private long? _id_cidadao; 
		private string _nome; 
		private string _nome_idx; 
		private Sexo _id_sexo; 
		private Raca _id_raca; 
		private Cidade _id_cidade_naturalidade; 
		private int? _idade; 
		private string _complemento_idade; 
		private string _nome_mae; 
		private string _nome_pai; 
		private string _rg; 
		private DateTime? _data_rg; 
		private Uf _id_uf_rg; 
		private string _endereco; 
		private string _telefone; 
		private string _observacoes; 		
		#endregion

		
		
		#region Constructor

		public Cidadao()
		{
			_id_cidadao = null; 
			_nome = null;
			_nome_idx = null;
			_id_sexo = null; 
			_id_raca = null; 
			_id_cidade_naturalidade = null; 
			_idade = null; 
			_complemento_idade = null;
			_nome_mae = null;
			_nome_pai = null;
			_rg = null;
			_data_rg = null; 
			_id_uf_rg = null; 
			_endereco = null;
			_telefone = null;
			_observacoes = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdCidadao
		{
			get
			{ 
				return _id_cidadao;
			}
			set
			{
				_id_cidadao = value;
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
				
				if(  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'Nome'");					

				_nome = value;
			}
		}
			
		public virtual string NomeIdx
		{
			get
			{ 
				return _nome_idx;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'NomeIdx'");
				
				if(  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'NomeIdx'");					

				_nome_idx = value;
			}
		}
			
		public virtual Sexo IdSexo
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
			
		public virtual Raca IdRaca
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
			
		public virtual int? Idade
		{
			get
			{ 
				return _idade;
			}
			set
			{
				_idade = value;
			}

		}
			
		public virtual string ComplementoIdade
		{
			get
			{ 
				return _complemento_idade;
			}

			set	
			{	
				if(  value != null &&  value.Length > 9)
					throw new ExceptionRS("Valor ultrapassa limite em 'ComplementoIdade'");					

				_complemento_idade = value;
			}
		}
			
		public virtual string NomeMae
		{
			get
			{ 
				return _nome_mae;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'NomeMae'");					

				_nome_mae = value;
			}
		}
			
		public virtual string NomePai
		{
			get
			{ 
				return _nome_pai;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'NomePai'");					

				_nome_pai = value;
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
			
		public virtual Uf IdUfRg
		{
			get
			{ 
				return _id_uf_rg;
			}
			set
			{
				_id_uf_rg = value;
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
			
		public virtual string Telefone
		{
			get
			{ 
				return _telefone;
			}

			set	
			{	
				if(  value != null &&  value.Length > 15)
					throw new ExceptionRS("Valor ultrapassa limite em 'Telefone'");					

				_telefone = value;
			}
		}
			
		public virtual string Observacoes
		{
			get
			{ 
				return _observacoes;
			}

			set	
			{	
				if(  value != null &&  value.Length > 512)
					throw new ExceptionRS("Valor ultrapassa limite em 'Observacoes'");					

				_observacoes = value;
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
			Cidadao castObj = (Cidadao)obj; 
			return ( castObj != null ) &&
				( this._id_cidadao == castObj.IdCidadao );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_cidadao.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
