using System;
using System.Collections.Generic;
using System.Text;

namespace Cestech.Application.Dto
{
    public class ServiceResponse<T> : ServiceResult
    {
        public T Object { get; set; }
    }
}
