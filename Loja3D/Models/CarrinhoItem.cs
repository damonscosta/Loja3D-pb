namespace Loja3D.Models {
    public class CarrinhoItem {
        public Produto Produto { get; set; } = new();
        public int Quantidade { get; set; }

        // Uma conta rápida para saber o subtotal (Preço x Quantidade)
        public decimal Subtotal => Produto.Preco * Quantidade;
    }
}