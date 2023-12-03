public class Atendimento
{
    DateTime inicio;
    DateTime fim;
    string? suspeitaInicial;
    List<(Exame, string)> exames = new List<(Exame, string)>();
    float valor;
    Medico? medicoResponsavel;
    Paciente? paciente;
    string? diagnosticoFinal;

    public DateTime Inicio
    {
        get { return inicio; }
        set { inicio = value; }
    }

    public DateTime Fim
    {
        get { return fim; }
        set { fim = value; }
    }

    public string SuspeitaInicial
    {
        get { return suspeitaInicial!; }
        set { suspeitaInicial = value; }
    }

    public List<(Exame, string)> Exames
    {
        get { return exames; }
        set
        {
            foreach (var exame in value)
            {
                exames.Add(exame);
            }

        }
    }

    public float Valor
    {
        get { return valor; }
        set { valor = value; }
    }

    public Medico MedicoResponsavel
    {
        get { return medicoResponsavel!; }
        set { medicoResponsavel = value; }
    }

    public Paciente Paciente
    {
        get { return paciente!; }
        set { paciente = value; }
    }

    public string DiagnosticoFinal
    {
        get { return diagnosticoFinal!; }
        set { diagnosticoFinal = value; }
    }

    public void iniciarAtendimento(string suspeita)
    {
        Inicio = DateTime.Now;
        SuspeitaInicial = suspeita;
    }

    public void finalizarAtendimento(string diagnostico)
    {
        if (Inicio < DateTime.Now)
        {
            Fim = DateTime.Now;
            diagnosticoFinal = diagnostico;

        }
    } 
}
