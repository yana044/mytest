using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Test_API_Json.Tests;

namespace Test_API_Json.Models
{
    internal class ResponseModel<T>
    {
        public int StatusCode { get; set; }
        public string? TypeResponseBody { get; set; }
        public List<T>? Data { get; set; }
    }
}
