using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Application.DTO.Validation
{
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento deve ser informado!");
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome deve ser informado!");
            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Telfone deve ser informado!");

        }
    }
}
