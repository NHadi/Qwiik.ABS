using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiik.ABS.Common.DTO
{
    public class ApiBadRequestResponse : ApiResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public ApiBadRequestResponse(int code, string message)
            : base(400)
        {
            Code = code;
            Message = message;
        }
    }
}
