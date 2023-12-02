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

    public void MostrarPacientesPorIdade(int idadeMinima, int idadeMaxima)
    {
        var reporte2 = pacientes.Where(paciente => paciente.Idade >= idadeMinima && paciente.Idade <= idadeMaxima);

        Console.WriteLine($"Relatório 2: Pacientes com idade entre {idadeMinima} e {idadeMaxima} anos");

        foreach (var paciente in reporte2)
        {
            Console.WriteLine($"Nome do paciente: {paciente.Nome} - Idade: {paciente.Idade} - CPF: {paciente.Cpf}");
            Console.WriteLine($"Sintomas:\n{string.Join(", ", paciente.Sintomas)}");
            Console.WriteLine($"\n");
        }



    }

}