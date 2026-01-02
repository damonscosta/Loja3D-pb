namespace Loja3D.Models {
    public class ItemPedido {
        public int Id { get; set; }

        //  Link com o produto
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;

        // Dados do produto no pedido
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;

        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; } // Salvamos o preço da época, se alterar depois o valor altera!


    }
}
