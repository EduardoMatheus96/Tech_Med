    public class Relatorio
    {
        List<Paciente> pacientes;
        List<Medico> medicos;

        public Relatorio(List<Paciente> pacientes, List<Medico> medicos)
        {
            this.pacientes = pacientes;
            this.medicos = medicos;
        }

        

        public void mostrarMedicosPorIdade(int idadeMinima, int idadeMaxima)
        {
            var reporte1 = medicos.Where(medico => medico.Idade >= idadeMinima && medico.Idade <= idadeMaxima);
            Console.WriteLine($"Relatório 1: Médicos com idade entre {idadeMinima} e {idadeMaxima} anos");

            foreach (var medico in reporte1)
            {
                Console.WriteLine($"Nome do médico: {medico.Nome} - Idade: {medico.Idade} - CPF: {medico.Cpf} - CRM: {medico.Crm}");
                Console.WriteLine($"\n");
            }
        }

        
    }