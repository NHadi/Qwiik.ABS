using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiik.ABS.Common.DTO
{
    public class ApiOkResponse : ApiResponse
    {
        public object Data { get; }
        public int TotalRows { get; }

        public ApiOkResponse(object result, int totalRows = 0)
            : base(200)
        {
            Data = result;
            TotalRows = totalRows;
        }
    }
}
