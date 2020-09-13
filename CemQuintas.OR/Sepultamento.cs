using System;
using Regisoft;
using System.Collections.Generic ;

namespace CemQuintas.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Sepultamento
	{
		

		
		#region Private Members		

		private long? _id_sepultamento; 
		private int _numero_controle; 
		private int _ano; 
		private Cidadao _id_cidadao; 
		private Documento _id_documento; 
		private Responsavel _id_responsavel1; 
		private Responsavel _id_responsavel2; 
		private Testemunha _id_testemunha1; 
		private Testemunha _id_testemunha2; 
		private DateTime? _data_termo; 
		private DateTime? _data_limite; 
		private string _documento_obito; 
		private DateTime? _data_documento_obito; 
		private Funeraria _id_funeraria; 
		private Cartorio _id_cartorio; 
		private string _livro; 
		private string _folhas; 
		private string _termo; 
		private string _outras_informacoes; 
		private DateTime? _data_guia; 
		private DateTime? _data_hora_falecimento; 
		private string _causa_obito; 
		private string _crm; 
		private string _nome_medico; 
		private string _lugar_obito; 
		private string _cova_carneira; 
		private Quadro _id_quadro; 
		private string _cova; 
		private Quadra _id_quadra; 
		private string _carneira; 
		private DateTime? _data_hora_sepultamento; 
		private string _numero_iml; 
		private DateTime? _data_exumacao; 
		private string _local_exumacao; 
		private string _login_inclusao; 
		private DateTime? _data_hora_inclusao; 
		private string _login_ultima_alteracao; 
		private DateTime? _data_hora_ultima_alteracao; 		
		#endregion

		
		
		#region Constructor

		public Sepultamento()
		{
			_id_sepultamento = null; 
			_numero_controle = 0;
			_ano = 0;
			_id_cidadao = null; 
			_id_documento = null; 
			_id_responsavel1 = null; 
			_id_responsavel2 = null; 
			_id_testemunha1 = null; 
			_id_testemunha2 = null; 
			_data_termo = null; 
			_data_limite = null; 
			_documento_obito = null;
			_data_documento_obito = null; 
			_id_funeraria = null;
			_id_cartorio = null; 
			_livro = null;
			_folhas = null;
			_termo = null;
			_outras_informacoes = null;
			_data_guia = null; 
			_data_hora_falecimento = null; 
			_causa_obito = null;
			_crm = null;
			_nome_medico = null;
			_lugar_obito = null;
			_cova_carneira = null;
			_id_quadro = null; 
			_cova = null;
			_id_quadra = null; 
			_carneira = null;
			_data_hora_sepultamento = null; 
			_numero_iml = null;
			_data_exumacao = null; 
			_local_exumacao = null;
			_login_inclusao = null;
			_data_hora_inclusao = null; 
			_login_ultima_alteracao = null;
			_data_hora_ultima_alteracao = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdSepultamento
		{
			get
			{ 
				return _id_sepultamento;
			}
			set
			{
				_id_sepultamento = value;
			}

		}
			

		public virtual int NumeroControle
		{
			get
			{ 
				return _numero_controle;
			}
			set
			{
				_numero_controle = value;
			}

		}
			
		public virtual int Ano
		{
			get
			{ 
				return _ano;
			}
			set
			{
				_ano = value;
			}

		}
			
		public virtual Cidadao IdCidadao
		{
			get
			{ 
				return _id_cidadao;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'IdCidadao'");

				_id_cidadao = value;
			}

		}
			
		public virtual Documento IdDocumento
		{
			get
			{ 
				return _id_documento;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'IdDocumento'");

				_id_documento = value;
			}

		}
			
		public virtual Responsavel IdResponsavel1
		{
			get
			{ 
				return _id_responsavel1;
			}
			set
			{
				_id_responsavel1 = value;
			}

		}
			
		public virtual Responsavel IdResponsavel2
		{
			get
			{ 
				return _id_responsavel2;
			}
			set
			{
				_id_responsavel2 = value;
			}

		}
			
		public virtual Testemunha IdTestemunha1
		{
			get
			{ 
				return _id_testemunha1;
			}
			set
			{
				_id_testemunha1 = value;
			}

		}
			
		public virtual Testemunha IdTestemunha2
		{
			get
			{ 
				return _id_testemunha2;
			}
			set
			{
				_id_testemunha2 = value;
			}

		}
			
		public virtual DateTime? DataTermo
		{
			get
			{ 
				return _data_termo;
			}
			set
			{
				_data_termo = value;
			}

		}
			
		public virtual DateTime? DataLimite
		{
			get
			{ 
				return _data_limite;
			}
			set
			{
				_data_limite = value;
			}

		}
			
		public virtual string DocumentoObito
		{
			get
			{ 
				return _documento_obito;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ExceptionRS("Valor ultrapassa limite em 'DocumentoObito'");					

				_documento_obito = value;
			}
		}
			
		public virtual DateTime? DataDocumentoObito
		{
			get
			{ 
				return _data_documento_obito;
			}
			set
			{
				_data_documento_obito = value;
			}

		}
			
		public virtual Funeraria IdFuneraria
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
			
		public virtual Cartorio IdCartorio
		{
			get
			{ 
				return _id_cartorio;
			}
			set
			{
				_id_cartorio = value;
			}

		}
			
		public virtual string Livro
		{
			get
			{ 
				return _livro;
			}

			set	
			{	
				if(  value != null &&  value.Length > 50)
					throw new ExceptionRS("Valor ultrapassa limite em 'Livro'");					

				_livro = value;
			}
		}
			
		public virtual string Folhas
		{
			get
			{ 
				return _folhas;
			}

			set	
			{	
				if(  value != null &&  value.Length > 6)
					throw new ExceptionRS("Valor ultrapassa limite em 'Folhas'");					

				_folhas = value;
			}
		}
			
		public virtual string Termo
		{
			get
			{ 
				return _termo;
			}

			set	
			{	
				if(  value != null &&  value.Length > 10)
					throw new ExceptionRS("Valor ultrapassa limite em 'Termo'");					

				_termo = value;
			}
		}
			
		public virtual string OutrasInformacoes
		{
			get
			{ 
				return _outras_informacoes;
			}

			set	
			{	
				if(  value != null &&  value.Length > 120)
					throw new ExceptionRS("Valor ultrapassa limite em 'OutrasInformacoes'");					

				_outras_informacoes = value;
			}
		}
			
		public virtual DateTime? DataGuia
		{
			get
			{ 
				return _data_guia;
			}
			set
			{
				_data_guia = value;
			}

		}
			
		public virtual DateTime? DataHoraFalecimento
		{
			get
			{ 
				return _data_hora_falecimento;
			}
			set
			{
				_data_hora_falecimento = value;
			}

		}
			
		public virtual string CausaObito
		{
			get
			{ 
				return _causa_obito;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'CausaObito'");					

				_causa_obito = value;
			}
		}
			
		public virtual string Crm
		{
			get
			{ 
				return _crm;
			}

			set	
			{	
				if(  value != null &&  value.Length > 8)
					throw new ExceptionRS("Valor ultrapassa limite em 'Crm'");					

				_crm = value;
			}
		}
			
		public virtual string NomeMedico
		{
			get
			{ 
				return _nome_medico;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'NomeMedico'");					

				_nome_medico = value;
			}
		}
			
		public virtual string LugarObito
		{
			get
			{ 
				return _lugar_obito;
			}

			set	
			{	
				if(  value != null &&  value.Length > 60)
					throw new ExceptionRS("Valor ultrapassa limite em 'LugarObito'");					

				_lugar_obito = value;
			}
		}
			
		public virtual string CovaCarneira
		{
			get
			{ 
				return _cova_carneira;
			}

			set	
			{	
				if(  value != null &&  value.Length > 1)
					throw new ExceptionRS("Valor ultrapassa limite em 'CovaCarneira'");					

				_cova_carneira = value;
			}
		}
			
		public virtual Quadro IdQuadro
		{
			get
			{ 
				return _id_quadro;
			}
			set
			{
				_id_quadro = value;
			}

		}
			
		public virtual string Cova
		{
			get
			{ 
				return _cova;
			}

			set	
			{	
				if(  value != null &&  value.Length > 15)
					throw new ExceptionRS("Valor ultrapassa limite em 'Cova'");					

				_cova = value;
			}
		}
			
		public virtual Quadra IdQuadra
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
			
		public virtual string Carneira
		{
			get
			{ 
				return _carneira;
			}

			set	
			{	
				if(  value != null &&  value.Length > 15)
					throw new ExceptionRS("Valor ultrapassa limite em 'Carneira'");					

				_carneira = value;
			}
		}
			
		public virtual DateTime? DataHoraSepultamento
		{
			get
			{ 
				return _data_hora_sepultamento;
			}
			set
			{
				_data_hora_sepultamento = value;
			}

		}
			
		public virtual string NumeroIml
		{
			get
			{ 
				return _numero_iml;
			}

			set	
			{	
				if(  value != null &&  value.Length > 10)
					throw new ExceptionRS("Valor ultrapassa limite em 'NumeroIml'");					

				_numero_iml = value;
			}
		}
			
		public virtual DateTime? DataExumacao
		{
			get
			{ 
				return _data_exumacao;
			}
			set
			{
				_data_exumacao = value;
			}

		}
			
		public virtual string LocalExumacao
		{
			get
			{ 
				return _local_exumacao;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'LocalExumacao'");					

				_local_exumacao = value;
			}
		}
			
		public virtual string LoginInclusao
		{
			get
			{ 
				return _login_inclusao;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ExceptionRS("Valor ultrapassa limite em 'LoginInclusao'");					

				_login_inclusao = value;
			}
		}
			
		public virtual DateTime? DataHoraInclusao
		{
			get
			{ 
				return _data_hora_inclusao;
			}
			set
			{
				_data_hora_inclusao = value;
			}

		}
			
		public virtual string LoginUltimaAlteracao
		{
			get
			{ 
				return _login_ultima_alteracao;
			}

			set	
			{	
				if(  value != null &&  value.Length > 20)
					throw new ExceptionRS("Valor ultrapassa limite em 'LoginUltimaAlteracao'");					

				_login_ultima_alteracao = value;
			}
		}
			
		public virtual DateTime? DataHoraUltimaAlteracao
		{
			get
			{ 
				return _data_hora_ultima_alteracao;
			}
			set
			{
				_data_hora_ultima_alteracao = value;
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
			Sepultamento castObj = (Sepultamento)obj; 
			return ( castObj != null ) &&
				( this._id_sepultamento == castObj.IdSepultamento );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_sepultamento.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
