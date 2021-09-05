using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> ListarAsync();
        Task<Categoria> ConsultarAsync(int? id);
        Task<Categoria> CreateAsync(Categoria categoria);
        Task<Categoria> UpdateAsync(Categoria categoria);
        Task<Categoria> RemoveAsync(Categoria categoria);
    }
}
