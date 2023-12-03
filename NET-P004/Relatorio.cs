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
        if (medicos.Any())
        {
            var reporte1 = medicos.Where(medico => medico.Idade >= idadeMinima && medico.Idade <= idadeMaxima);
            if (reporte1.Any())
            {
                Console.WriteLine($"Relatório 1: Médicos com idade entre {idadeMinima} e {idadeMaxima} anos");

                foreach (var medico in reporte1)
                {
                    Console.WriteLine($"Nome do médico: {medico.Nome} - Idade: {medico.Idade} - CPF: {medico.Cpf} - CRM: {medico.Crm}");
                    // Console.WriteLine($"\n");
                }
            }
            else
            {
                throw new Exception($"Nenhum medico entre as idades {idadeMinima} e {idadeMaxima}!");
            }
        }
        else
        {
            throw new Exception("Nenhum medico encontrado!");
        }
    }

    public void MostrarPacientesPorIdade(int idadeMinima, int idadeMaxima)
    {
        if (pacientes.Any())
        {
            var reporte2 = pacientes.Where(paciente => paciente.Idade >= idadeMinima && paciente.Idade <= idadeMaxima);
            if (reporte2.Any())
            {
                Console.WriteLine($"\nRelatório 2: Pacientes com idade entre {idadeMinima} e {idadeMaxima} anos");

                foreach (var paciente in reporte2)
                {
                    Console.WriteLine($"Nome do paciente: {paciente.Nome} - Idade: {paciente.Idade} - CPF: {paciente.Cpf}");
                    Console.WriteLine($"Sintomas:\n{string.Join(", ", paciente.Sintomas)}");
                    // Console.WriteLine($"\n");
                }
            }
            else
            {
                throw new Exception($"Nenhum paciente entre as idades {idadeMinima} e {idadeMaxima}!");
            }
        }
        else
        {
            throw new Exception("Nenhum paciente encontrado!");
        }
    }

    public void MostrarPacientesPorGenero(string sexoAlvo)
    {
        if (pacientes.Any())
        {
            var pacientesFiltrados = pacientes.Where(paciente =>
                paciente.Sexo.Equals(sexoAlvo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (pacientesFiltrados.Any())
            {
                Console.WriteLine($"\nRelatório 3: Pacientes do sexo {sexoAlvo}:");
                foreach (var paciente in pacientesFiltrados)
                {
                    Console.WriteLine($"Nome: {paciente.Nome}, Idade: {paciente.Idade} anos, CPF: {paciente.Cpf}, Gênero: {paciente.Sexo}");
                }
            }else{
                throw new Exception($"Nenhum paciente do gênero {sexoAlvo} encontrado!");
            }
        }
        else
        {
            throw new Exception("Nenhum paciente encontrado!");
        }
    }

    public void MostrarPacientesEmOrdemAlfabetica()
    {

        var pacientesOrdenados = pacientes.OrderBy(paciente => paciente.Nome).ToList();
        
        Console.WriteLine("\nRelatório 4: Pacientes em ordem alfabética:");
        foreach (var paciente in pacientesOrdenados)
        {
            Console.WriteLine($"Nome: {paciente.Nome}, Idade: {paciente.Idade} anos, CPF: {paciente.Cpf}, Gênero: {paciente.Sexo}");
        }
    }

    public void MostrarPacientesPorSintoma(string textoSintoma)
    {
        // Filtra os pacientes cujos sintomas contêm o texto informado
        var pacientesFiltrados = pacientes
            .Where(paciente => ContemSintoma(paciente.Sintomas, textoSintoma))
            .ToList();

        // Exibe os pacientes filtrados
        Console.WriteLine($"\nRelatório 5: Pacientes com sintomas contendo '{textoSintoma}':");
        foreach (var paciente in pacientesFiltrados)
        {
            Console.WriteLine($"Nome: {paciente.Nome}, Idade: {paciente.Idade} anos, CPF: {paciente.Cpf}, Gênero: {paciente.Sexo}, Sintomas: {string.Join(", ", paciente.Sintomas)}");
        }
    }

    // Tratar o dado dynamic
    private bool ContemSintoma(dynamic sintomas, string textoSintoma)
    {
        // Convertemos para uma lista de strings (assumindo que seja uma lista de strings)
        var listaSintomas = ((IEnumerable<object>)sintomas).Cast<string>().ToList();

        // Verificamos se a lista de sintomas contém o texto informado
        return listaSintomas.Any(sintoma => sintoma.Contains(textoSintoma, StringComparison.OrdinalIgnoreCase));
    }

    public void MostrarAniversariantesDoMes(int mesAlvo)
    {
        var reporte6 = pacientes.Where(paciente => paciente.dataDeNascimento.Month == mesAlvo);
        var reporte7 = medicos.Where(medico => medico.dataDeNascimento.Month == mesAlvo);

        Console.WriteLine($"\nRelatório 6: Pacientes e médico que fazem aniversário em junho");

        foreach (var paciente in reporte6)
        {
            Console.WriteLine($"Nome do paciente: {paciente.Nome} - Idade: {paciente.Idade} - CPF: {paciente.Cpf}");
        }

        foreach (var medico in reporte7)
        {
            Console.WriteLine($"Nome do médico: {medico.Nome} - Idade: {medico.Idade} - CPF: {medico.Cpf} - CRM: {medico.Crm}");
        }

    }
}