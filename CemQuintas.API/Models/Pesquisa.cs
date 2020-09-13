using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemQuintas.API.Models
{
    [Serializable]
    public class Pesquisa
    {
        private long _id_sepultamento;
        private string _nome;
        private string _numero_controle;
        private int _ano;
        private string _cidade;
        private string _uf;
        private string _causa_obito;

        public long IdSepultamento { get => _id_sepultamento; set => _id_sepultamento = value; }
        public string NumeroControle { get => _numero_controle; set => _numero_controle = value; }
        public int Ano { get => _ano; set => _ano = value; }
        public string Cidade { get => _cidade; set => _cidade = value; }
        public string Uf { get => _uf; set => _uf = value; }
        public string CausaObito { get => _causa_obito; set => _causa_obito = value; }
        public string Nome { get => _nome; set => _nome = value; }
    }
}