using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10
{
   
        public class Result
        {
            public bool IsSucces { get; set; }
            public string? Message { get; set; }
            public Result(bool isSuccess, string? message = null)
            {
                IsSucces = isSuccess;
                Message = message;
            }
        }
    
}
