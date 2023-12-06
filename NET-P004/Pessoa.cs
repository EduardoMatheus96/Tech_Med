namespace AvaliacaoGrupo.dotnetP004
{
    public class Pessoa
    {
        private static HashSet<string> cpfsUnicos = new HashSet<string>();
        public string Nome { get; set; }
        public DateTime dataDeNascimento { get; set; }
        public string Cpf { get; set; }
        public Pessoa(string _nome, DateTime _dataDeNascimento, string _cpf)
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
                throw new ArgumentException($"CPF de {_nome} já consta cadastrado como outra pessoa !!!!");
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