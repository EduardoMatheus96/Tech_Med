namespace AvaliacaoGrupo.dotnetP004;

public class CartaoCredito : IPagamento
{
  public string? Descricao { get; set; }
  public double ValorBruto { get; set; }

  public double Desconto { get; set; }

  public DateTime DataHora { get; set; }

   public CartaoCredito(double _ValorBruto){
            this.Descricao = "Pagamento com cartão de crédito";
            this.ValorBruto = _ValorBruto;
            this.DataHora= new DateTime();
            this.Desconto = 0;
        }
  public void RealizarPagamento(double valor)
  {
    Console.WriteLine($"Pagamento de {valor} realizado com cartão de crédito");

  }
}