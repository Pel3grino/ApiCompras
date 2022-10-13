using ApiCompras.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Domain.Repository
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(Guid id);
        Task<ICollection<Person>> GetAllAsync();
        Task<Person> CreateAsync(Person person);
        Task EditAsync(Person person);
        Task DeleteAsync(Person person);
    }
}
