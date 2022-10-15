using ApiCompras.Application.DTO;
using ApiCompras.Application.DTO.Validation;
using ApiCompras.Application.Service.Interface;
using ApiCompras.Domain.Entitie;
using ApiCompras.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository  _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository personRepository,IMapper mapper )
        {
            _personRepository = personRepository;
            _mapper = mapper;     
        }
        public async Task<ResultService<PersonDto>> CreateAsync(PersonDto personDto)
        {
            if (personDto == null)
                return ResultService.Fail<PersonDto>("Objeto deve ser informado.");

            var result = new PersonDtoValidator().Validate(personDto);
                if (!result.IsValid)
                  return ResultService.RequestError<PersonDto>("Problema de validade!", result);

                    var person = _mapper.Map<Person>(personDto);
                    var data = await _personRepository.CreateAsync(person);
                    return ResultService.Ok<PersonDto>(_mapper.Map<PersonDto>(data));
                
            
        }
    }
}
