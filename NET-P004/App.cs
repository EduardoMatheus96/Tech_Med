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
            Console.WriteLine("1. Cadastrar Médico");
            Console.WriteLine("2. Cadastrar Paciente");
            Console.WriteLine("3. Cadastrar Exame");
            Console.WriteLine("4. Cadastrar Atendimento");
            Console.WriteLine("5. Relatórios");
            Console.WriteLine("6. Sair\n");

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
                    MenuRelatorios();
                    break;
                case "6":
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

                string? option;

                do
                {
                    Console.Write("Digite um sintoma: ");
                    string? sintoma = Console.ReadLine() ?? throw new ArgumentNullException(nameof(sintoma));

                    sintomas.Add(sintoma);

                    option = Console.ReadLine();

                } while(option != "n" || option != "nao");

                Paciente paciente = new Paciente(nome, date, cpf, sexo, sintomas);

                pacientes.Add(paciente);
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
            }
            else
            {
                Console.WriteLine("Por favor, insira um número inteiro válido.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida!");
        }
    }
    private void AdicionarAtendimento()
    {
        try
        {
            // Console.Write("Nome do produto: ");
            // string? name = Console.ReadLine();

            // Console.Write("Quantidade em estoque: ");
            // if (int.TryParse(Console.ReadLine(), out int amount))
            // {
            //     Console.Write("Preço unitário: ");
            //     if (double.TryParse(Console.ReadLine(), out double price))
            //     {
            //         Product newProduct = new Product(name, amount, price);
            //         stock.Add(newProduct);

            //         Console.WriteLine("Produto adicionado!");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Por favor, insira um número decimal válido.");
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("Por favor, insira um número inteiro válido.");
            // }
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida!");
        }
    }

    private void MenuRelatorios()
    {
        while (true)
        {
            Console.WriteLine("==== Escolha o relatório ====\n");
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
                    MenuRelatorios();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
                case "10":
                    Environment.Exit(0);
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
}
