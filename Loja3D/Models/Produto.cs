namespace Loja3D.Models {
    public class Produto {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // Começa vazio pra não dar aviso amarelo
        public string Descricao { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty; // Link da foto
        public decimal Preco { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public int Estoque { get; set; } // Quantidade pronta entrega

    }
}
