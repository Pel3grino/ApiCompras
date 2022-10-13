using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Application.DTO
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public int Code { get;  set; }
        public string Name { get;  set; }
        public string Document { get;  set; }
        public string? Phone { get;  set; }
    }
}
