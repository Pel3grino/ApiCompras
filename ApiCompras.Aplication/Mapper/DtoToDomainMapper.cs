using ApiCompras.Application.DTO;
using ApiCompras.Domain.Entitie;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Application.Mapper
{
    public class DtoToDomainMapper : Profile
    {
        public DtoToDomainMapper()
        {
            CreateMap<PersonDto, Person>();
        }
    }
}
