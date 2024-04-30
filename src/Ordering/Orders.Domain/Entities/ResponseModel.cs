using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Entities
{
    public class ResponseModel
    {
        public string Message {  get; set; }
        public string StatusCode { get; set; }
        public bool IsSuccess { get; set; }
    }
}
