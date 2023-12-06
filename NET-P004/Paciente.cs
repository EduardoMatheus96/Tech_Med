namespace AvaliacaoGrupo.dotnetP004
{
    public class Paciente : Pessoa
    {
        string sexo;
        List<string> sintomas;

        PlanoDeSaude planoDeSaude;

        public List<IPagamento> pagamentos = new List<IPagamento>();

        public string Sexo
        {
            get { return sexo; }
            set
            {
                if (!value.ToLower().Equals("masculino") && !value.ToLower().Equals("feminino"))
                {
                    throw new ArgumentException("Insira um sexo valido !!!");
                }
                else
                {
                    sexo = value.ToLower();
                }
            }
        }

        public dynamic Sintomas
        {
            get { return sintomas; }
            set { this.sintomas = value; }
        }

        public PlanoDeSaude PlanoDeSaude
        {
            get { return planoDeSaude; }
            set { this.planoDeSaude = value; }
        }

        public List<IPagamento> Pagamentos
        {
            get { return pagamentos; }
            set
            {
                foreach (IPagamento pagamento in value)
                {
                    this.pagamentos.Add(pagamento);
                }
            }
        }

        public Paciente(string _nome, DateTime _dataDeNascimento, string _cpf, string _sexo, List<string> _sintomas) : base(_nome, _dataDeNascimento, _cpf)
        {
            sexo = _sexo;
            sintomas = _sintomas;
        }

        public Paciente(string _nome, DateTime _dataDeNascimento, string _cpf, string _sexo, List<string> _sintomas, PlanoDeSaude _plano, IPagamento _pagamento) : base(_nome, _dataDeNascimento, _cpf)
        {
            sexo = _sexo;
            sintomas = _sintomas;
            planoDeSaude = _plano;
            pagamentos.Add(_pagamento);
        }
    }
}
