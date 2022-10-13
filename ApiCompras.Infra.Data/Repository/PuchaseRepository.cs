using ApiCompras.Domain.Entitie;
using ApiCompras.Domain.Repository;
using ApiCompras.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Infra.Data.Repository
{
    public class PuchaseRepository : IPuchaseRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PuchaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Puchase> CreateAsync(Puchase puchase)
        {
            _dbContext.Puchases.Add(puchase);
            await _dbContext.SaveChangesAsync();
            return puchase;
        }

        public async Task DeleteAsync(Puchase puchase)
        {
           _dbContext.Remove(puchase);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task EditAsync(Puchase puchase)
        {
            _dbContext.Update(puchase);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Puchase>> GetAllAsync()
        {
            return await _dbContext.Puchases.ToListAsync();
        }

        public async Task<Puchase> GetByIdAsync(Guid id)
        {
            return await _dbContext.Puchases.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Puchase>> GetByPersonIdAsync(Guid personId)
        {
            return await _dbContext.Puchases
                .Include(x => x.Product)
                .Include(x=> x.Person)
                .Where(x => x.PersonId == personId).ToListAsync();
        }

        public async Task<ICollection<Puchase>> GetByProductIdAsync(Guid productId)
        {
            return await _dbContext.Puchases
                .Include(x => x.Product)
                .Include(x => x.Person)
                .Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}
