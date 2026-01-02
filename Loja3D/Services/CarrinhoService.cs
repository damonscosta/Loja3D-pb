using Loja3D.Models;

namespace Loja3D.Services {
    public class CarrinhoService {
        // A lista privada onde guardamos os itens
        private List<CarrinhoItem> itens = new List<CarrinhoItem>();

        // Evento para avisar o site: "Ei, o carrinho mudou! Atualiza o número lá em cima!"
        public event Action? OnChange;

        // Adiciona um produto ao carrinho
        public void Adicionar(Produto produto) {
            // Verifica se o produto já está no carrinho
            var itemExistente = itens.FirstOrDefault(i => i.Produto.Id == produto.Id);

            if (itemExistente == null) {
                // Se não tem, adiciona novo
                itens.Add(new CarrinhoItem { Produto = produto, Quantidade = 1 });
            }
            else {
                // Se já tem, só aumenta a quantidade
                itemExistente.Quantidade++;
            }

            // Avisa todo mundo que houve mudança
            NotificarMudanca();
        }

        // Remove um item
        public void Remover(Produto produto) {
            var item = itens.FirstOrDefault(i => i.Produto.Id == produto.Id);
            if (item != null) {
                itens.Remove(item);
                NotificarMudanca();
            }
        }

        // Pega todos os itens (para mostrar na tela de resumo)
        public List<CarrinhoItem> ObterItens() {
            return itens;
        }

        // Método auxiliar para avisar os componentes
        private void NotificarMudanca() => OnChange?.Invoke();
        public void Esvaziar() {
            itens.Clear();
            NotificarMudanca();
        }
    }

}