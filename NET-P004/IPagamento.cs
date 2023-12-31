namespace AvaliacaoGrupo.dotnetP004
{
    public interface IPagamento
    {
        public string? Descricao { get; set; }
        public double ValorBruto { get; set; }

        public double Desconto { get; set; }

        public DateTime DataHora { get; set; }

        public void RealizarPagamento(double valor);        
    }
}