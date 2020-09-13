using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemQuintas.API.Models
{
    [Serializable]
    public class TotalAnual
    {
        private int _ano;
        private int _jan;
        private int _fev;
        private int _mar;
        private int _abr;
        private int _mai;
        private int _jun;
        private int _jul;
        private int _ago;
        private int _set;
        private int _out;
        private int _nov;
        private int _dez;
        private int _total;

        public int Ano { set => _ano = value; get => _ano; }
        public int Jan { set => _jan = value; get => _jan; }
        public int Fev { set => _fev = value; get => _fev; }
        public int Mar { set => _mar = value; get => _mar; }
        public int Abr { set => _abr = value; get => _abr; }
        public int Mai { set => _mai = value; get => _mai; }
        public int Jun { set => _jun = value; get => _jun; }
        public int Jul { set => _jul = value; get => _jul; }
        public int Ago { set => _ago = value; get => _ago; }
        public int Set { set => _set = value; get => _set; }
        public int Out { set => _out = value; get => _out; }
        public int Nov { set => _nov = value; get => _nov; }
        public int Dez { set => _dez = value; get => _dez; }
        public int Total { set => _total = value; get => _total; }
    }
}