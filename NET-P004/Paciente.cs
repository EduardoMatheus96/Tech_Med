namespace AvaliacaoGrupo.dotnetP004
{
    public class Paciente : Pessoa
    {
        string sexo;
        List<string> sintomas;

        PlanoDeSaude planoDeSaude;

        List<Pagamento> pagamentos = new List<Pagamento>;

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

        public List<Pagamento> Pagamentos
        {
            get { return pagamentos; }
            set
            {
                foreach (Pagamento pagamento in value)
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

        public Paciente(string _nome, DateTime _dataDeNascimento, string _cpf, string _sexo, List<string> _sintomas, PlanoDeSaude _plano, List<Pagamento> _pagamentos) : base(_nome, _dataDeNascimento, _cpf)
        {
            sexo = _sexo;
            sintomas = _sintomas;
            planoDeSaude = _plano;
            pagamentos = _pagamentos;
        }
    }
}
