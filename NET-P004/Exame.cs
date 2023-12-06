namespace AvaliacaoGrupo.dotnetP004
{
    public class Exame
    {
        string? titulo;
        float? valor;
        string? descricao;
        string? local;

        public Exame(string _titulo, float _valor, string _descricao, string _local) {
            titulo = _titulo;
            valor = _valor;
            descricao = _descricao;
            local = _local;
        }

        public string? Titulo
        {
            get { return titulo!; }
            set { titulo = value; }
        }

        public float? Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string? Descricao
        {
            get { return descricao!; }
            set { descricao = value; }
        }

        public string? Local
        {
            get { return local!; }
            set { local = value; }
        }

    }
}