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
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public PersonRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _DbContext.Add(person);
            await _DbContext.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _DbContext.Remove(person);
            await _DbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
            _DbContext.Update(person);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Person>> GetAllAsync()
        {
            return await _DbContext.People.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(Guid id)
        {
            return await _DbContext.People.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
