using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Application.Service
{
    public class ResultService
    {
        public bool IsSucces { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService RequestError (string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSucces = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSucces = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService Fail (string message) => new ResultService { IsSucces = false, Message = message };
        public static ResultService<T> Fail<T>(string message) => new ResultService<T> { IsSucces = false, Message = message };
        public static ResultService Ok(string message) => new ResultService { IsSucces = true, Message = message };
        public static ResultService<T> Ok<T>(T data) => new ResultService<T> { IsSucces = true, Data = data };


    }
    public  class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
