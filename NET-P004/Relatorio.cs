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
        try
        {
            if (medicos.Any())
            {
                var reporte1 = medicos.Where(medico => medico.Idade >= idadeMinima && medico.Idade <= idadeMaxima);
                if (reporte1.Any())
                {
                    Console.WriteLine($"\n=== Médicos com idade entre {idadeMinima} e {idadeMaxima} anos: ===\n");

                    foreach (var medico in reporte1)
                    {
                        Console.WriteLine($"Nome do médico: {medico.Nome} - Idade: {medico.Idade} - CPF: {medico.Cpf} - CRM: {medico.Crm}");
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void MostrarPacientesPorIdade(int idadeMinima, int idadeMaxima)
    {
        try
        {

            if (pacientes.Any())
            {
                var reporte2 = pacientes.Where(paciente => paciente.Idade >= idadeMinima && paciente.Idade <= idadeMaxima);
                if (reporte2.Any())
                {
                    Console.WriteLine($"\n=== Pacientes com idade entre {idadeMinima} e {idadeMaxima} anos: ===\n");

                    foreach (var paciente in reporte2)
                    {
                        Console.WriteLine($"Nome do paciente: {paciente.Nome} - Idade: {paciente.Idade} - CPF: {paciente.Cpf}");
                        Console.WriteLine($"Sintomas:\n{string.Join(", ", paciente.Sintomas)}");
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void MostrarPacientesPorGenero(string sexoAlvo)
    {
        try
        {

            if (pacientes.Any())
            {
                var pacientesFiltrados = pacientes.Where(paciente =>
                    paciente.Sexo.Equals(sexoAlvo, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (pacientesFiltrados.Any())
                {
                    Console.WriteLine($"\n=== Pacientes do sexo {sexoAlvo}: ===\n");
                    foreach (var paciente in pacientesFiltrados)
                    {
                        Console.WriteLine($"Nome: {paciente.Nome}, Idade: {paciente.Idade} anos, CPF: {paciente.Cpf}, Sexo: {paciente.Sexo}");
                    }
                }
                else
                {
                    throw new Exception($"Nenhum paciente do sexo {sexoAlvo} encontrado!");
                }
            }
            else
            {
                throw new Exception("Nenhum paciente encontrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void MostrarPacientesEmOrdemAlfabetica()
    {
        try
        {

            if (pacientes.Any())
            {
                var pacientesOrdenados = pacientes.OrderBy(paciente => paciente.Nome).ToList();

                Console.WriteLine("\n=== Pacientes em ordem alfabética: ===\n");
                foreach (var paciente in pacientesOrdenados)
                {
                    Console.WriteLine($"Nome: {paciente.Nome}, Idade: {paciente.Idade} anos, CPF: {paciente.Cpf}, Gênero: {paciente.Sexo}");
                }
            }
            else
            {
                throw new Exception("Nenhum paciente encontrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void MostrarPacientesPorSintoma(string textoSintoma)
    {
        try
        {

            if (pacientes.Any())
            {
                var pacientesFiltrados = pacientes
                    .Where(paciente => ContemSintoma(paciente.Sintomas, textoSintoma))
                    .ToList();
                if (pacientesFiltrados.Any())
                {
                    Console.WriteLine($"\n=== Pacientes com sintomas contendo '{textoSintoma}': ===\n");
                    foreach (var paciente in pacientesFiltrados)
                    {
                        Console.WriteLine($"Nome: {paciente.Nome}, Idade: {paciente.Idade} anos, CPF: {paciente.Cpf}, Gênero: {paciente.Sexo}, Sintomas: {string.Join(", ", paciente.Sintomas)}");
                    }
                }
                else
                {
                    throw new Exception($"Nenhum paciente com sintomas '{textoSintoma}' encontrado!");
                }
            }
            else
            {
                throw new Exception("Nenhum paciente encontrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private bool ContemSintoma(dynamic sintomas, string textoSintoma)
    {
        var listaSintomas = ((IEnumerable<object>)sintomas).Cast<string>().ToList();

        return listaSintomas.Any(sintoma => sintoma.Contains(textoSintoma, StringComparison.OrdinalIgnoreCase));
    }

    public void MostrarAniversariantesDoMes(int mesAlvo)
    {
        try
        {

            if (pacientes.Any())
            {
                var reporte6 = pacientes.Where(paciente => paciente.dataDeNascimento.Month == mesAlvo);
                if (reporte6.Any())
                {
                    Console.WriteLine($"\n=== Pacientes que fazem aniversário em {mesAlvo} ===\n");

                    foreach (var paciente in reporte6)
                    {
                        Console.WriteLine($"Nome do paciente: {paciente.Nome} - Idade: {paciente.Idade} - CPF: {paciente.Cpf}");
                    }
                }
                else
                {
                    throw new Exception($"Nenhum paciente faz aniversário em {mesAlvo}!");
                }
            }
            else
            {
                throw new Exception("Nenhum paciente encontrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {

            if (medicos.Any())
            {
                var reporte7 = medicos.Where(medico => medico.dataDeNascimento.Month == mesAlvo);
                if (reporte7.Any())
                {
                    Console.WriteLine($"\n=== Médicos que fazem aniversário em {mesAlvo} ===\n");
                    foreach (var medico in reporte7)
                    {
                        Console.WriteLine($"Nome do médico: {medico.Nome} - Idade: {medico.Idade} - CPF: {medico.Cpf} - CRM: {medico.Crm}");
                    }
                }
                else
                {
                    throw new Exception($"Nenhum medico faz aniversário em {mesAlvo}!");
                }
            }
            else
            {
                throw new Exception($"Nenhum medico encontrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void relatorioAtendimento(List<Atendimento> atendimentos, string palavra)
    {
        List<Atendimento> resultado = atendimentos.Where(a => a.SuspeitaInicial.Contains(palavra, StringComparison.OrdinalIgnoreCase) ||
                                             a.DiagnosticoFinal.Contains(palavra, StringComparison.OrdinalIgnoreCase))
                                .ToList();

        foreach (Atendimento atendimento in resultado)
        {
            Console.WriteLine($"Atendimento - inicio: {atendimento.Inicio} - fim: {atendimento.Fim} - suspeita: {atendimento.SuspeitaInicial} - diagnostico final: {atendimento.DiagnosticoFinal}");
        }
    }
}