using ApiCompras.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Domain.Repository
{
    public interface IPuchaseRepository
    {
        Task<Puchase> GetByIdAsync(Guid id);
        Task<ICollection<Puchase>> GetAllAsync();
        Task<Puchase> CreateAsync(Puchase puchase);
        Task EditAsync(Puchase puchase);
        Task DeleteAsync(Puchase puchase);
        Task<ICollection<Puchase>> GetByPersonIdAsync(Guid personId);
        Task<ICollection<Puchase>> GetByProductIdAsync(Guid productId);

    }
}
