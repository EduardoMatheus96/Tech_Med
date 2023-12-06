namespace AvaliacaoGrupo.dotnetP004;

public class CartaoCredito : IPagamento
{
  public string Descricao = "Pagamento sendo realizado por Cartão de Credito";
  public double ValorBruto = 0;

  public double Desconto = 0;

  public DateTime DataHora = DateTime.Now;

  public void RealizarPagamento(double valor)
  {
    Console.WriteLine($"Pagamento de {valor} realizado com cartão de crédito");

  }
}