using ApiCompras.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Domain.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<ICollection<Product>> GetAllAsync();
        Task<Product> CreateAsync(Product  product);
        Task EditAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
