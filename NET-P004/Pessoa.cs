using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_P004
{
    public class Pessoa
    {
        private static HashSet<string> cpfsUnicos = new HashSet<string>();
        public string Nome { get; set; }
        public DateTime dataDeNascimento { get; set; }
        public string Cpf { get; set; }
        public Person(string _nome, DateTime _dataDeNascimento, string _cpf)
        {
            Nome = _nome;
            dataDeNascimento = _dataDeNascimento;

            if (cpfsUnicos.Add(_cpf))
            {                       
                if (ValidateCpf(_cpf))
                {
                    Cpf = _cpf;
                }
                else
                {
                    throw new ArgumentException("O CPF deve conter exatamente 11 dígitos numéricos.");

                }
            }
            else
            {
                throw new ArgumentException("CPF deve ser único.");
            }
        }
        public int Idade => calculaIdade(dataDeNascimento);

        public static int calculaIdade(DateTime dataDeNascimento)
        {
            int idade = DateTime.Now.Year - dataDeNascimento.Year;
            if (DateTime.Now.DayOfYear < dataDeNascimento.DayOfYear)
                idade--;
            return idade;
        }

        private bool ValidateCpf(string cpf)
        {
            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}