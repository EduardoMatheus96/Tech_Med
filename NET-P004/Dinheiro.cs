namespace AvaliacaoGrupo.dotnetP004
{
    public class Dinheiro : IPagamento
    {
        public string? Descricao { get; set; }
        public double ValorBruto { get; set; }

        public double Desconto { get; set; }

        public DateTime DataHora { get; set; }

        public Dinheiro(double _ValorBruto){
            this.Descricao = "Pagamento em Dinheiro Vivo";
            this.ValorBruto = _ValorBruto;
            this.DataHora= new DateTime();
            this.Desconto = 0;
        }

        public void RealizarPagamento(double valor){
            Console.WriteLine($"Pagamento de {valor} realizado com transferência bancária");
        }    
    }
}