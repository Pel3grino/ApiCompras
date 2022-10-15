using ApiCompras.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiCompras.Domain.Entitie
{
    public class Puchase
    {
        public Guid Id { get; private set; }
        public int Code { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; private set; }
        public Product Product { get; private set; }

        public Puchase(Guid id,int code,Guid productId, Guid personId)
        {
            DomainValidationException.When(code <= 0, "Código da compra deve ser maior que zero.");
            DomainValidationException.When(string.IsNullOrEmpty(id.ToString()), "O Id não foi informado.");
            Validation( Id, productId, personId);
            
            Id = id;
            Code = code;
        }

        public Puchase(Guid productId, Guid personId)
        {
            Validation(Id, productId, personId);
        }

        private void Validation(Guid id,Guid productId,Guid personId)
        {
            DomainValidationException.When(string.IsNullOrEmpty(id.ToString()), "O Id não foi informado.");
            DomainValidationException.When(string.IsNullOrEmpty(productId.ToString()), "Produto não encontrado ou não informado.");
            DomainValidationException.When(string.IsNullOrEmpty(personId.ToString()), "Pessoa não encontrada ou não informada.");
            
            Id = id;
            ProductId = productId;
            PersonId = personId;
            Date = DateTime.Now;

        }
    }
}
