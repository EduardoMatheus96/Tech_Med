namespace AvaliacaoGrupo.dotnetP004
{
    public class Relatorio
    {
        public static void mostrarMedicosPorIdade(List<Medico> medicos, int idadeMinima, int idadeMaxima)
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

        public static void MostrarPacientesPorIdade(List<Paciente> pacientes, int idadeMinima, int idadeMaxima)
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

        public static void MostrarPacientesPorGenero(List<Paciente> pacientes, string sexoAlvo)
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

        public static void MostrarPacientesEmOrdemAlfabetica(List<Paciente> pacientes)
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

        public static void MostrarPacientesPorSintoma(List<Paciente> pacientes, string textoSintoma)
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

        private static bool ContemSintoma(dynamic sintomas, string textoSintoma)
        {
            var listaSintomas = ((IEnumerable<object>)sintomas).Cast<string>().ToList();

            return listaSintomas.Any(sintoma => sintoma.Contains(textoSintoma, StringComparison.OrdinalIgnoreCase));
        }

        public static void MostrarAniversariantesDoMes(List<Medico> medicos, List<Paciente> pacientes, int mesAlvo)
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

        public static void relatorioAtendimentoComPalavra(List<Atendimento> atendimentos, string palavra)
        {
            try
            {
                if (atendimentos.Any())
                {
                    List<Atendimento> resultado = atendimentos.Where(a => a.SuspeitaInicial.Contains(palavra, StringComparison.OrdinalIgnoreCase) ||
                                                         a.DiagnosticoFinal.Contains(palavra, StringComparison.OrdinalIgnoreCase))
                                            .ToList();
                    if (resultado.Any())
                    {
                        Console.WriteLine($"\n=== Atendimentos com sintomas ou diagnósticos contendo '{palavra}': ===\n");
                        foreach (Atendimento atendimento in resultado)
                        {
                            Console.WriteLine($"Atendimento - inicio: {atendimento.Inicio} - fim: {atendimento.Fim} - suspeita: {atendimento.SuspeitaInicial} - diagnostico final: {atendimento.DiagnosticoFinal}");
                        }
                    }
                    else
                    {
                        throw new Exception($"Nenhum atendimento com sintoma ou diagnóstico contendo a palavra '{palavra}' encontrado!");
                    }
                }
                else
                {
                    throw new Exception($"Nenhum atendimento encontrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ordenarDecresAtendimentoSemFinalizar(List<Atendimento> atendimentos)
        {
            try
            {
                if (atendimentos.Any())
                {

                    List<Atendimento> atendimentosSemFinalizar = atendimentos.Where(atendimento => atendimento.Fim != default(DateTime)).ToList();
                    if (atendimentosSemFinalizar.Count > 0)
                    {
                        Console.WriteLine($"\n=== Atendimentos sem finalizar em ordem decrescente: ===\n");
                        atendimentosSemFinalizar.Sort((a1, a2) => a2.Inicio.CompareTo(a1.Inicio));
                        foreach (Atendimento atendimento in atendimentosSemFinalizar)
                        {
                            Console.WriteLine($"Atendimento - inicio: {atendimento.Inicio} - suspeita: {atendimento.SuspeitaInicial}");
                        }
                    }
                    else
                    {
                        throw new Exception($"Nenhum atendimento sem finalizar encontrado!");
                    }
                }
                else
                {
                    throw new Exception($"Nenhum atendimento encontrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void OrdenarMedicosDecresAtendimentoConcluido(List<Atendimento> atendimentos, List<Medico> medicos)
        {
            try
            {
                if (atendimentos.Any())
                {
                    if (medicos.Any())
                    {
                        var medicosComMaisAtendimentos = atendimentos
                            .Where(atendimento => atendimento.Fim != DateTime.MinValue)
                            .GroupBy(atendimento => atendimento.MedicoResponsavel)
                            .OrderByDescending(group => group.Count())
                            .Select(group => new { Medico = group.Key, NumeroDeAtendimentos = group.Count() });

                        if (medicosComMaisAtendimentos.Any())
                        {
                            var medicosComAtendimentosConcluidos = medicosComMaisAtendimentos
                                .Join(
                                    medicos,
                                    mca => mca.Medico,
                                    medico => medico,
                                    (mca, medico) => new { Medico = medico, NumeroDeAtendimentos = mca.NumeroDeAtendimentos }
                                )
                                .ToList();

                            Console.WriteLine("\n=== Médicos em ordem decrescente da quantidade de atendimentos concluídos: ===\n");

                            foreach (var medicoComAtendimentos in medicosComAtendimentosConcluidos)
                            {
                                Console.WriteLine($"Nome do médico: {medicoComAtendimentos.Medico.Nome} - Atendimentos Concluídos: {medicoComAtendimentos.NumeroDeAtendimentos}");
                            }
                        }
                        else
                        {
                            throw new Exception($"Nenhum medico com atendimentos concluídos encontrado!");
                        }
                    }
                    else
                    {
                        throw new Exception($"Nenhum medico encontrado!");
                    }
                }
                else
                {
                    throw new Exception("Não existem atendimentos concluídos!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ExamesMaisUtilizados(List<Atendimento> atendimentos)
        {
            try
            {
                if (atendimentos.Any())
                {
                    var examesMaisUtilizados = atendimentos
                    .SelectMany(atendimento => atendimento.exames)
                    .GroupBy(tuple => tuple.Item1)
                    .OrderByDescending(group => group.Count())
                    .Take(10)
                    .Select(group => new { Exame = group.Key, Quantidade = group.Count() });
                    if (examesMaisUtilizados.Any())
                    {
                        foreach (var exame in examesMaisUtilizados)
                        {
                            Console.WriteLine($"Exame: {exame.Exame.titulo}, Quantidade: {exame.Quantidade}");
                        }
                    }
                    else
                    {
                        throw new Exception($"Nenhum exame encontrado!");
                    }
                }
                else
                {
                    throw new Exception($"Nenhum atendimento encontrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}