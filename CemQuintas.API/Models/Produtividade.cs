using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemQuintas.API.Models
{
    [Serializable]
    public class Produtividade
    {
        private string _login;
        private int _quantidade;

        public string Login { get => _login; set => _login = value; }
        public int Quantidade { get => _quantidade; set => _quantidade = value; }
    }
}