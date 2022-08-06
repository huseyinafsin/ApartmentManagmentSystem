using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.Utilities.Results
{
    public class CustomReponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }

        public static CustomReponseDto<T> Success(int statusCode, T data)
        {
            return new CustomReponseDto<T> { Data = data, StatusCode = statusCode };
        }

        public static CustomReponseDto<T> Success(int statusCode)
        {
            return new CustomReponseDto<T> { StatusCode = statusCode };
        }
        public static CustomReponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomReponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomReponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomReponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }

    }
}
