using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_P004
{
    public class Medico : Pessoa
    {
        private static HashSet<string> crmsUnicos = new HashSet<string>();

        public string Crm { get; set; }

        public Doctor(string _nome, DateTime _dataDeNascimento, string _cpf, string _crm) : base(_nome, _dataDeNascimento, _cpf)
        {
            if (crmsUnicos.Add(_crm))
            {
                Crm = _crm;
            }
            else
            {
                throw new ArgumentException("CRM deve ser único.");
            }
        }
    }
}