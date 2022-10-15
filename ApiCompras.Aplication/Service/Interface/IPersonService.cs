using ApiCompras.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Application.Service.Interface
{
    public interface IPersonService
    {
        Task<ResultService<PersonDto>> CreateAsync(PersonDto personDto);
    }
}
