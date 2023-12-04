namespace AvaliacaoGrupo.dotnetP004
{
    public class Paciente : Pessoa
    {
        string sexo;
        List<string> sintomas;

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

        public Paciente(string _nome, DateTime _dataDeNascimento, string _cpf, string _sexo, List<string> _sintomas) : base(_nome, _dataDeNascimento, _cpf)
        {
            sexo = _sexo;
            sintomas = _sintomas;

        }
        // public void adicionarPaciente(Paciente paciente, List<Paciente> pacientes){
        //     if (pacientes.Any(p => p.Cpf == paciente.Cpf))
        //     {
        //         throw new ArgumentException("Paciente invalido, CRM ou CPF Ja presente na lista de pacientes !!!");
        //     }
        //     else pacientes.Add(paciente);
        // }
    }
}
