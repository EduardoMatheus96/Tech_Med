using AvaliacaoGrupo.dotnetP004;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

App app = new App();
app.MenuPrincipal();

// List<Paciente> pacientes = new List<Paciente>();

// List<string> _sintomas = new() { "Dor de Cabeça", "Febre" };
// Paciente paciente01 = new Paciente("Eduardo", new DateTime(1996,05,08), "12345678910", "masculino", _sintomas);
// // paciente01.adicionarPaciente(paciente01, pacientes);
// pacientes.Add(paciente01);


// List<string> sintomas1 = new() { "Dor de Garganta", "Tosse" };
// Paciente paciente02 = new Paciente("Maria", new DateTime(1985, 11, 17), "98765432101", "feminino", sintomas1);
// // paciente02.adicionarPaciente(paciente02, pacientes);
// pacientes.Add(paciente02);

// List<string> sintomas2 = new() { "Dor nas Costas", "Cansaço" };
// Paciente paciente03 = new Paciente("Carlos", new DateTime(1990, 07, 12), "23456789012", "masculino", sintomas2);
// // paciente03.adicionarPaciente(paciente03, pacientes);
// pacientes.Add(paciente03);

// List<string> sintomas3 = new() { "Náusea", "Vômito" };
// Paciente paciente04 = new Paciente("Ana", new DateTime(1978, 02, 02), "34567890123", "feminino", sintomas3);
// // paciente04.adicionarPaciente(paciente04, pacientes);
// pacientes.Add(paciente04);

// List<string> sintomas4 = new() { "Dor Abdominal", "Diarréia" };
// Paciente paciente05 = new Paciente("José", new DateTime(1982, 03, 03), "45678901234", "masculino", sintomas4);
// // paciente05.adicionarPaciente(paciente05, pacientes);
// pacientes.Add(paciente05);

// // Criando Lista de medicos: 

// List<Medico> medicos = new List<Medico>();

// Medico medico01 = new Medico("Marcelo", new DateTime(1990, 02, 01), "12345678988", "1234");
// // medico01.adicionarMedico(medico01, medicos);
// medicos.Add(medico01);

// Medico medico02 = new Medico("Carolina", new DateTime(1985,12,08), "23454389012", "5678");
// // medico02.adicionarMedico(medico02, medicos);
// medicos.Add(medico02);

// Medico medico03 = new Medico("Antonio", new DateTime(1978, 04, 27), "34561190123", "9012");
// // medico03.adicionarMedico(medico03, medicos);
// medicos.Add(medico03);

// Medico medico04 = new Medico("Isabela", new DateTime(1993, 09, 22), "45678903334", "3456");
// // medico04.adicionarMedico(medico04, medicos);
// medicos.Add(medico04);

// Medico medico05 = new Medico("Roberto", new DateTime(1980, 11, 02), "56744012345", "7890");
// // medico05.adicionarMedico(medico05, medicos);
// medicos.Add(medico05);

//Crindo Lista de exames

// List<Exame> exames = new List<Exame>();
// Exame exame01 = new Exame("febre");
// exames.Add(exame01);
// Exame exame02 = new Exame("dor de cabeça");
// exames.Add(exame02);
// Exame exame03 = new Exame("tosse");
// exames.Add(exame03);
// Exame exame04 = new Exame("dor de garganta");
// exames.Add(exame04);
// Exame exame05 = new Exame("dor de braço");

//Criando Lista de atendimentos

// List<Atendimento> atendimentos = new List<Atendimento>();
// Atendimento atendimento01 = new Atendimento(paciente01, medico01, exames);
// atendimentos.Add(atendimento01);
// Atendimento atendimento02 = new Atendimento(paciente02, medico02, exames);
// atendimentos.Add(atendimento02);
// Atendimento atendimento03 = new Atendimento(paciente03, medico03, exames);
// atendimentos.Add(atendimento03);
// Atendimento atendimento04 = new Atendimento(paciente04, medico04, exames);
// atendimentos.Add(atendimento04);
// Atendimento atendimento05 = new Atendimento(paciente05, medico05, exames);
// atendimentos.Add(atendimento05);

// //Relatorio relatorio = new Relatorio(pacientes, medicos);

// Relatorio.mostrarMedicosPorIdade(medicos, 18, 40);
// Relatorio.MostrarPacientesPorIdade(pacientes, 18, 100);
// Relatorio.MostrarPacientesPorGenero(pacientes, "masculino");
// Relatorio.MostrarPacientesEmOrdemAlfabetica(pacientes);
// Relatorio.MostrarPacientesPorSintoma(pacientes, "febre");
// Relatorio.MostrarAniversariantesDoMes(medicos, pacientes, 11);
// Relatorio.relatorioAtendimentoComPalavra(pacientes, "febre");
// Relatorio.ordenarDecresAtendimentoSemFinalizar(pacientes);
// Relatorio.OrdenarMedicosDecresAtendimentoConcluido(medicos);
// Relatorio.ContemSintoma(pacientes, "febre");