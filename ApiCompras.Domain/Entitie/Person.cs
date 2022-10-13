using ApiCompras.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Domain.Entitie
{
    public sealed class Person
    {
        public Guid Id { get; set; }
        public int Code { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string? Phone { get; private set; }

        public ICollection<Puchase> Puchases { get; set; }
        public Person(int code, string name, string document, string phone)
        {
            Validation(code,name, document, phone);
        }

        public Person(Guid id, int code,string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(id.ToString()), "O Id não foi informado.");
            Id = id;
            Validation(code, name, document, phone);
        }
        private void Validation(int code,string name, string document, string? phone)
        {
            DomainValidationException.When(code <= 0, "O código deve ser maior que zero");
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser preechido.");
            DomainValidationException.When(string.IsNullOrEmpty(document), "O número do documento deve ser informado.");
            
            Code = Code;
            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
