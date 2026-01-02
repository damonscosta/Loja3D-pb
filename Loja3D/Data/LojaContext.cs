using Loja3D.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja3D.Data {
    public class LojaContext : DbContext {
        // Construtor que recebe opções e as passa para a classe base DbContext 
        public LojaContext(DbContextOptions<LojaContext> options) : base(options) {
        }
        public DbSet<Produto> Produtos { get; set; }

        // Tabelas para pedidos e itens de pedido "Models/Pedido.cs" e "Models/ItemPedido.cs"
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
    }
}
