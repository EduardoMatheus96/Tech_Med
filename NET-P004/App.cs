namespace AvaliacaoGrupo.dotnetP004;
public class App
{
    List<Paciente> pacientes = new List<Paciente>();
    List<Medico> medicos = new List<Medico>();
    List<Exame> exames = new List<Exame>();
    List<Atendimento> atendimentos = new List<Atendimento>();
    public void MenuPrincipal()
    {
        while (true)
        {
            Console.WriteLine($"\n===== Menu Tech_Med =====\n");

            Console.WriteLine("1. Cadastrar Médico");
            Console.WriteLine("2. Cadastrar Paciente");
            Console.WriteLine("3. Cadastrar Exame");
            Console.WriteLine("4. Iniciar atendimento");
            Console.WriteLine("5. Encerrar atendimento");
            Console.WriteLine("6. Relatórios");
            Console.WriteLine("7. Sair\n");

            Console.Write("Escolha uma opção: ");
            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AdicionarMedico();
                    break;
                case "2":
                    AdicionarPaciente();
                    break;
                case "3":
                    AdicionarExame();
                    break;
                case "4":
                    AdicionarAtendimento();
                    break;
                case "5":
                    encerrarAtendimento();
                    break;
                case "6":
                    MenuRelatorios();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private void AdicionarMedico()
    {
        try
        {
            Console.WriteLine($"\n===== Cadastrando um novo medico =====\n");

            Console.Write("Nome do médico: ");
            string? nome = Console.ReadLine() ?? throw new ArgumentNullException(nameof(nome));

            Console.Write("Data de nascimento: ");
            string? dataDeNascimento = Console.ReadLine();
            if (DateTime.TryParseExact(dataDeNascimento, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                Console.Write("CPF: ");
                string? cpf = Console.ReadLine() ?? throw new ArgumentNullException(nameof(cpf));

                Console.Write("CRM: ");
                string? crm = Console.ReadLine() ?? throw new ArgumentNullException(nameof(crm));

                Medico medico = new Medico(nome, date, cpf, crm);

                medicos.Add(medico);
                Console.WriteLine($"Médico {medico.Nome} adicionado com sucesso!");

            }
            else
            {
                Console.WriteLine("Por favor, insira uma data válida.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private void AdicionarPaciente()
    {
        List<string> sintomas = new List<string>();
        try
        {
            Console.WriteLine($"\n===== Cadastrando um novo paciente =====\n");
            Console.Write("Nome do paciente: ");
            string? nome = Console.ReadLine() ?? throw new ArgumentNullException(nameof(nome));

            Console.Write("Data de nascimento: ");
            string? dataDeNascimento = Console.ReadLine();
            if (DateTime.TryParseExact(dataDeNascimento, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                Console.Write("CPF: ");
                string? cpf = Console.ReadLine() ?? throw new ArgumentNullException(nameof(cpf));

                Console.Write("Sexo: ");
                string? sexo = Console.ReadLine() ?? throw new ArgumentNullException(nameof(sexo));

                string? sintoma;

                do
                {
                    Console.Write("Digite um sintoma: ");
                    sintoma = Console.ReadLine() ?? throw new ArgumentNullException(nameof(sintoma));

                    sintomas.Add(sintoma);
                } while (!sintoma!.Equals("n") && !sintoma.Equals("nao"));

                Paciente paciente = new Paciente(nome, date, cpf, sexo, sintomas);

                pacientes.Add(paciente);
                Console.WriteLine($"Paciente {paciente.Nome} adicionado com sucesso!");

            }
            else
            {
                Console.WriteLine("Por favor, insira uma data válida.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private void AdicionarExame()
    {
        try
        {
            Console.WriteLine($"\n===== Cadastrando um novo exame =====\n");
            Console.Write("Título do exame: ");
            string? titulo = Console.ReadLine() ?? throw new ArgumentNullException(nameof(titulo));

            Console.Write("Preço do exame: ");
            if (float.TryParse(Console.ReadLine(), out float valor))
            {
                Console.Write("Descrição do exame: ");
                string? descricao = Console.ReadLine() ?? throw new ArgumentNullException(nameof(descricao));

                Console.Write("Local do exame: ");
                string? local = Console.ReadLine() ?? throw new ArgumentNullException(nameof(local));

                Exame exame = new Exame(titulo, valor, descricao, local);

                exames.Add(exame);
                Console.WriteLine($"Exame {exame.Titulo} adicionado com sucesso!");

            }
            else
            {
                Console.WriteLine("Por favor, insira um número decimal válido.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida!");
        }
    }
    private void AdicionarAtendimento()
    {
        if (medicos.Count == 0 || pacientes.Count == 0 || exames.Count == 0)
        {
            if (medicos.Count == 0 && pacientes.Count == 0 && exames.Count == 0)
            {
                Console.WriteLine("É necessário ter pelo menos um médico, um paciente e um exame");
            }
            else if (medicos.Count == 0 && pacientes.Count == 0)
            {
                Console.WriteLine("É necessário ter pelo menos um médico e um paciente");
            }
            else if (medicos.Count == 0 && exames.Count == 0)
            {
                Console.WriteLine("É necessário ter pelo menos um médico e um exame");
            }
            else if (pacientes.Count == 0 && exames.Count == 0)
            {
                Console.WriteLine("É necessário ter pelo menos um paciente e um exame");
            }
            else if (medicos.Count == 0)
            {
                Console.WriteLine("É necessário ter pelo menos um médico");
            }
            else if (pacientes.Count == 0)
            {
                Console.WriteLine("É necessário ter pelo menos um paciente");
            }
            else if (exames.Count == 0)
            {
                Console.WriteLine("É necessário ter pelo menos um exame");
            }
        }
        else
        {
            try
            {
                Console.WriteLine($"\n===== Cadastrando um novo atendimento =====\n");
                Medico medico;
                Paciente paciente;
                List<(Exame, string)> examesResultado = new List<(Exame, string)>();
                Atendimento atendimento = new Atendimento();

                Console.Write("Insira a suspeita inicial: ");
                string? suspeita = Console.ReadLine() ?? throw new ArgumentNullException(nameof(suspeita));

                Console.Write("Valor do atendimento: ");
                if (float.TryParse(Console.ReadLine(), out float valor))
                {
                    atendimento.Valor = valor;

                    for (int i = 0; i < medicos.Count; i++)
                    {
                        Console.WriteLine($"{i}. {medicos[i].Nome}");
                    }

                    Console.Write("Escolha o médico: ");
                    if (int.TryParse(Console.ReadLine(), out int opcaoMedico))
                    {
                        if (opcaoMedico <= medicos.Count)
                        {
                            medico = medicos[opcaoMedico];
                            atendimento.MedicoResponsavel = medico;
                        }
                        else
                        {
                            Console.WriteLine($"Médico não existe na lista");
                        }
                    }

                    for (int i = 0; i < pacientes.Count; i++)
                    {
                        Console.WriteLine($"\n{i}. {pacientes[i].Nome}");
                    }

                    Console.Write("Escolha o paciente: ");
                    if (int.TryParse(Console.ReadLine(), out int opcaoPaciente))
                    {
                        if (opcaoPaciente <= pacientes.Count)
                        {
                            paciente = pacientes[opcaoPaciente];
                            atendimento.Paciente = paciente;
                        }
                        else
                        {
                            Console.WriteLine($"Paciente não existe na lista");
                        }
                    }

                    while (true)
                    {
                        for (int i = 0; i < exames.Count; i++)
                        {
                            Console.WriteLine($"\n{i}. {exames[i].Titulo}");
                        }

                        Console.Write("Escolha o exame: ");
                        if (int.TryParse(Console.ReadLine(), out int opcaoExame))
                        {
                            if (opcaoExame <= exames.Count)
                            {
                                Console.Write($"Qual o resultado do exame:");
                                string? resultado = Console.ReadLine();
                                examesResultado.Add((exames[opcaoExame], resultado ?? ""));
                                Console.Write("Adicionar mais exames?: (s) ou (n):");

                                string? parar = Console.ReadLine();
                                if (parar!.Equals("n") || parar.Equals("nao") || parar.Equals("N"))
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Exame não existe na lista");
                                break;
                            }
                        }
                    }
                    Console.Write("----Exames e resultados----\n\n");
                    foreach (var exame in examesResultado)
                    {
                        Console.Write($" Exame - {exame.Item1.Titulo} - resultado -> {exame.Item2}\n");
                    }

                }
                else
                {
                    Console.WriteLine("Por favor, insira um número decimal válido.");
                }

                atendimento.Exames = examesResultado;
                atendimento.iniciarAtendimento(suspeita);
                atendimentos.Add(atendimento);
                Console.WriteLine($"Atendimento iniciado com sucesso!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida!");
            }
        }
    }

    private void encerrarAtendimento()
    {
        Console.WriteLine($"\n===== Encerrando um atendimento =====\n");
        for (int i = 0; i < atendimentos.Count; i++)
        {
            Console.WriteLine($"\n{i}. {atendimentos[i].Inicio} - {atendimentos[i].Paciente.Nome} - {atendimentos[i].MedicoResponsavel.Nome} - {atendimentos[i].SuspeitaInicial} ");
            foreach (var exame in atendimentos[i].Exames)
            {
                Console.WriteLine($" Exame: {exame.Item1.Titulo} - Resultado: {exame.Item2}");
            }
        }

        Console.Write("Escolha o atendimento: ");
        if (int.TryParse(Console.ReadLine(), out int opcaoAtendimento))
        {
            if (opcaoAtendimento <= atendimentos.Count)
            {
                Console.Write("Insira diagnóstico: ");
                string? diagnostico = Console.ReadLine() ?? throw new ArgumentNullException(nameof(diagnostico));
                atendimentos[opcaoAtendimento].finalizarAtendimento(diagnostico);
                Console.WriteLine($"Atendimento finalizado com sucesso!");

            }
            else
            {
                Console.WriteLine($"Atendimento não existe na lista");
            }
        }
    }

    private void MenuRelatorios()
    {
        while (true)
        {
            Console.WriteLine("\n===== Menu de  relatórios =====\n");
            Console.WriteLine("1. Médicos com idade entre dois valores");
            Console.WriteLine("2. Pacientes com idade entre dois valores");
            Console.WriteLine("3. Pacientes do sexo informado pelo usuário.");
            Console.WriteLine("4. Pacientes em ordem alfabética");
            Console.WriteLine("5. Pacientes cujos sintomas contenha texto informado pelo usuário");
            Console.WriteLine("6. Médicos e Pacientes aniversariantes do mês informado");
            Console.WriteLine("7. Atendimentos em aberto (sem finalizar) em ordem decrescente pela data de início");
            Console.WriteLine("8. Médicos em ordem decrescente da quantidade de atendimentos concluídos");
            Console.WriteLine("9. Atendimentos cuja suspeita ou diagnóstico final contenham determinada palavra");
            Console.WriteLine("10. Os 10 exames mais utilizados nos atendimentos");
            Console.WriteLine("11. Voltar para o menu principal");

            Console.Write("Escolha uma opção: ");
            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    leIdadeMedico();
                    break;
                case "2":
                    leIdadePaciente();
                    break;
                case "3":
                    leGeneroPaciente();
                    break;
                case "4":
                    Relatorio.MostrarPacientesEmOrdemAlfabetica(pacientes);
                    break;
                case "5":
                    leSintomasPaciente();
                    break;
                case "6":
                    leMesAniversariante();
                    break;
                case "7":
                    Relatorio.ordenarDecresAtendimentoSemFinalizar(atendimentos);
                    break;
                case "8":
                    Relatorio.OrdenarMedicosDecresAtendimentoConcluido(atendimentos, medicos);
                    break;
                case "9":
                    lePalavraAtendimento();
                    break;
                case "10":
                    Relatorio.ExamesMaisUtilizados(atendimentos);
                    break;
                case "11":
                    MenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private void leIdadeMedico()
    {
        Console.Write("Insira a primeira idade: ");
        if (int.TryParse(Console.ReadLine(), out int idade1))
        {
            Console.Write("Insira a segunda idade: ");
            if (int.TryParse(Console.ReadLine(), out int idade2))
            {
                if (idade1 < idade2)
                {
                    Relatorio.mostrarMedicosPorIdade(medicos, idade1, idade2);
                }
                else
                {
                    Console.WriteLine("A primeira idade deve ser menor que a segunda.");
                }
            }
            else
            {
                Console.WriteLine("Por favor, insira um número inteiro válido.");
            }

        }
        else
        {
            Console.WriteLine("Por favor, insira um número inteiro válido.");
        }

    }

    private void leIdadePaciente()
    {
        Console.Write("Insira a primeira idade: ");
        if (int.TryParse(Console.ReadLine(), out int idade1))
        {
            Console.Write("Insira a segunda idade: ");
            if (int.TryParse(Console.ReadLine(), out int idade2))
            {
                if (idade1 < idade2)
                {
                    Relatorio.MostrarPacientesPorIdade(pacientes, idade1, idade2);
                }
                else
                {
                    Console.WriteLine("A primeira idade deve ser menor que a segunda.");
                }
            }
            else
            {
                Console.WriteLine("Por favor, insira um número inteiro válido.");
            }

        }
        else
        {
            Console.WriteLine("Por favor, insira um número inteiro válido.");
        }

    }

    private void leGeneroPaciente()
    {
        Console.Write("Insira o gênero dos pacientes: ");
        string? genero = Console.ReadLine() ?? throw new ArgumentNullException(nameof(genero));

        Relatorio.MostrarPacientesPorGenero(pacientes, genero);
    }
    private void leSintomasPaciente()
    {
        Console.Write("Insira o sintoma dos pacientes: ");
        string? sintoma = Console.ReadLine() ?? throw new ArgumentNullException(nameof(sintoma));

        Relatorio.MostrarPacientesPorSintoma(pacientes, sintoma);
    }

    private void leMesAniversariante()
    {
        Console.Write("Insira o número do mês dos aniversariantes: ");
        if (int.TryParse(Console.ReadLine(), out int mes))
        {
            Relatorio.MostrarAniversariantesDoMes(medicos, pacientes, mes);
        }
        else
        {
            Console.WriteLine("Por favor, insira um número inteiro válido.");
        }
    }

    private void lePalavraAtendimento()
    {
        Console.Write("Insira uma palavra que possa conter em uma suspeita ou em um diagnóstico dos atendimentos: ");
        string? palavra = Console.ReadLine() ?? throw new ArgumentNullException(nameof(palavra));

        Relatorio.relatorioAtendimentoComPalavra(atendimentos, palavra);
    }
}