namespace Namespace;
public class PlanoDeSaude
{
    string? titulo;
    double mensalidade;

    public PlanoDeSaude(string _titulo, double _mensalidade)
    {
        titulo = _titulo;
        mensalidade = _mensalidade;
    }

    public string? Titulo
    {
        get { return titulo!; }
        set { titulo = value; }
    }

    public double Mensalidade
    {
        get { return mensalidade; }
        set { mensalidade = value; }
    }

}