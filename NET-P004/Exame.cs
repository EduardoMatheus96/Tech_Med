public class Exame {
    string titulo;
    float valor;
    string descricao;
    string local;

    public Exame(){}
    public string Titulo{
        get { return titulo; }
        set { titulo = value; }
    }

    public float Valor{
        get { return valor; }
        set { valor = value; }
    }

    public string Descricao{
        get{ return descricao; }
        set { descricao = value; }
    }

    public string Local {
        get { return local; }
        set { local = value; }
    }

}