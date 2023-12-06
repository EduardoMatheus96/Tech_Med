public class BoletoBancario: IPagamento{
    public void RealizarPagamento(double valor){
      Console.WriteLine($"Pagamento de {valor} pagamento concluído com sucesso");
   }

   public void Descrição(string descricao){ {
      Console.WriteLine("Boleto bancário");
   }

   public void valorbruto(double valor){
      Console.WriteLine($"Valor bruto: {valor}");
   }

   public void desconto(double desconto){
       Console.WriteLine("Desconto: " + desconto);
   }

   public void DataPagamento(DateTime data){
       Console.WriteLine("Data de pagamento: " + data);
   }
}