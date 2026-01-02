namespace Loja3D.Models {
    public class Pedido {

        public int Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public decimal ValorTotal { get; set; }
        public List<ItemPedido> Itens { get; set; } = new();
    }
}
