using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTOs.Response
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;

        public ServiceResponse() { }

        public ServiceResponse(T data, bool success = true, string message = null)
        {
            Data = data;
            Success = success;
            Message = message;
        }
    }

}
