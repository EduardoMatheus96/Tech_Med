namespace AvaliacaoGrupo.dotnetP004;
public class BoletoBancario : IPagamento
{
    public string? Descricao { get; set; }
    public double ValorBruto { get; set; }

    public double Desconto { get; set; }

    public DateTime DataHora { get; set; }

    public BoletoBancario(double valor)
    {
        this.Descricao = "Pagamento em boleto bancário";
        this.ValorBruto = valor;
        this.DataHora = DateTime.Now();
        this.Desconto = 0;
    }

    public void RealizarPagamento(double valor)
    {
        Console.WriteLine($"Pagamento de {valor} - pagamento de boleto bancário realizado com sucesso!");
    }
}