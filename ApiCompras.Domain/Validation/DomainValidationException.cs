using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Domain.Validation
{
    internal class DomainValidationException : Exception
    {
        public DomainValidationException(string error) : base(error)
        {
        }
        public  static void When(bool haserror, string messaage)
        {
            if (haserror)
            {
                throw new DomainValidationException(messaage);
            }
        }
    }
}
