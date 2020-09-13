using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Exumacao
	{
		

		
		#region Private Members		

		private long? _id_exumacao; 
		private Sepultamento _id_sepultamento; 
		private DateTime? _data; 
		private string _funcionario; 
		private string _livro_geral_numero; 
		private string _livro_geral_folhas; 
		private string _nome_requerente; 
		private string _nacionalidade; 
		private string _naturalidade; 
		private string _profissao; 
		private string _rg; 
		private Uf _id_uf_rg; 
		private DateTime? _data_expedicao_rg; 
		private string _logradouro; 
		private string _numero; 
		private string _apartamento; 
		private string _bairro; 
		private Cidade _id_cidade; 
		private string _telefone; 
		private string _grau_parentesco; 
		private string _responsavel_abertura; 
		private string _cemiterio_destino; 
		private DateTime _data_digitacao; 		
		#endregion

		
		
		#region Constructor

		public Exumacao()
		{
			_id_exumacao = null; 
			_id_sepultamento = null; 
			_data = null; 
			_funcionario = null;
			_livro_geral_numero = null;
			_livro_geral_folhas = null;
			_nome_requerente = null;
			_nacionalidade = null;
			_naturalidade = null;
			_profissao = null;
			_rg = null;
			_id_uf_rg = null; 
			_data_expedicao_rg = null; 
			_logradouro = null;
			_numero = null;
			_apartamento = null;
			_bairro = null;
			_id_cidade = null; 
			_telefone = null;
			_grau_parentesco = null;
			_responsavel_abertura = null;
			_cemiterio_destino = null;
			_data_digitacao = Convert.ToDateTime("1/1/1800");
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdExumacao
		{
			get
			{ 
				return _id_exumacao;
			}
			set
			{
				_id_exumacao = value;
			}

		}
			
		public virtual Sepultamento IdSepultamento
		{
			get
			{ 
				return _id_sepultamento;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'IdSepultamento'");

				_id_sepultamento = value;
			}

		}
			
		public virtual DateTime? Data
		{
			get
			{ 
				return _data;
			}
			set
			{
				_data = value;
			}

		}
			
		public virtual string Funcionario
		{
			get
			{ 
				return _funcionario;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'Funcionario'");					

				_funcionario = value;
			}
		}
			
		public virtual string LivroGeralNumero
		{
			get
			{ 
				return _livro_geral_numero;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ExceptionRS("Valor ultrapassa limite em 'LivroGeralNumero'");					

				_livro_geral_numero = value;
			}
		}
			
		public virtual string LivroGeralFolhas
		{
			get
			{ 
				return _livro_geral_folhas;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ExceptionRS("Valor ultrapassa limite em 'LivroGeralFolhas'");					

				_livro_geral_folhas = value;
			}
		}
			
		public virtual string NomeRequerente
		{
			get
			{ 
				return _nome_requerente;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'NomeRequerente'");					

				_nome_requerente = value;
			}
		}
			
		public virtual string Nacionalidade
		{
			get
			{ 
				return _nacionalidade;
			}

			set	
			{	
				if(  value != null &&  value.Length > 80)
					throw new ExceptionRS("Valor ultrapassa limite em 'Nacionalidade'");					

				_nacionalidade = value;
			}
		}
			
		public virtual string Naturalidade
		{
			get
			{ 
				return _naturalidade;
			}

			set	
			{	
				if(  value != null &&  value.Length > 80)
					throw new ExceptionRS("Valor ultrapassa limite em 'Naturalidade'");					

				_naturalidade = value;
			}
		}
			
		public virtual string Profissao
		{
			get
			{ 
				return _profissao;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'Profissao'");					

				_profissao = value;
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
			
		public virtual DateTime? DataExpedicaoRg
		{
			get
			{ 
				return _data_expedicao_rg;
			}
			set
			{
				_data_expedicao_rg = value;
			}

		}
			
		public virtual string Logradouro
		{
			get
			{ 
				return _logradouro;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'Logradouro'");					

				_logradouro = value;
			}
		}
			
		public virtual string Numero
		{
			get
			{ 
				return _numero;
			}

			set	
			{	
				if(  value != null &&  value.Length > 10)
					throw new ExceptionRS("Valor ultrapassa limite em 'Numero'");					

				_numero = value;
			}
		}
			
		public virtual string Apartamento
		{
			get
			{ 
				return _apartamento;
			}

			set	
			{	
				if(  value != null &&  value.Length > 6)
					throw new ExceptionRS("Valor ultrapassa limite em 'Apartamento'");					

				_apartamento = value;
			}
		}
			
		public virtual string Bairro
		{
			get
			{ 
				return _bairro;
			}

			set	
			{	
				if(  value != null &&  value.Length > 80)
					throw new ExceptionRS("Valor ultrapassa limite em 'Bairro'");					

				_bairro = value;
			}
		}
			
		public virtual Cidade IdCidade
		{
			get
			{ 
				return _id_cidade;
			}
			set
			{
				_id_cidade = value;
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
				if(  value != null &&  value.Length > 16)
					throw new ExceptionRS("Valor ultrapassa limite em 'Telefone'");					

				_telefone = value;
			}
		}
			
		public virtual string GrauParentesco
		{
			get
			{ 
				return _grau_parentesco;
			}

			set	
			{	
				if(  value != null &&  value.Length > 15)
					throw new ExceptionRS("Valor ultrapassa limite em 'GrauParentesco'");					

				_grau_parentesco = value;
			}
		}
			
		public virtual string ResponsavelAbertura
		{
			get
			{ 
				return _responsavel_abertura;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'ResponsavelAbertura'");					

				_responsavel_abertura = value;
			}
		}
			
		public virtual string CemiterioDestino
		{
			get
			{ 
				return _cemiterio_destino;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'CemiterioDestino'");					

				_cemiterio_destino = value;
			}
		}
			
		public virtual DateTime DataDigitacao
		{
			get
			{ 
				return _data_digitacao;
			}
			set
			{
				_data_digitacao = value;
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
			Exumacao castObj = (Exumacao)obj; 
			return ( castObj != null ) &&
				( this._id_exumacao == castObj.IdExumacao );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_exumacao.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
