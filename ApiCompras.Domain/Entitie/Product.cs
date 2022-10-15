using ApiCompras.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Domain.Entitie
{
    public sealed class Product
    {
        public Guid Id { get; private set; }
        public int Code { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Puchase> Puchases { get; set; }

        public Product(int code, string name, string codErp, decimal price)
        {
            Validation(code, name, codErp, price);
            Puchases = new List<Puchase>();
        }

        public Product(Guid id, int code,string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(id.ToString()), "O Id não foi informado.");
            Id = id;    
            Validation(code, name, codErp, price);
            Puchases = new List<Puchase>();
        }
        private void Validation(int code, string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(code.ToString()), "O código deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser preenchido.");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "O código do ERP deve ser informado.");
            DomainValidationException.When(price > 0, "O preço deve ser maior que zero.");
     
            Code = code;
            Name = name;
            CodErp = codErp;
            Price = price;
            
        }
    }
}
