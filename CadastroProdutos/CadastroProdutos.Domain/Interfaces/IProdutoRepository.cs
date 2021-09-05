using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ListarAsync();
        Task<Produto> ConsultarAsync(int? id);
        Task<Produto> ConsultarProdutoPorCategoriaAsync(int? id);
        Task<Produto> CreateAsync(Produto produto);
        Task<Produto> UpdateAsync(Produto produto);
        Task<Produto> RemoveAsync(Produto produto);
    }
}
