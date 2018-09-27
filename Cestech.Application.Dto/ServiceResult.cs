using System;
using System.Collections.Generic;
using System.Text;

namespace Cestech.Application.Dto
{
    public class ServiceResult
    {
        public List<string> Messages { get; set; }
        public bool Result { get; set; }
        public ServiceResult()
        {
            Messages = new List<string>();
        }
    }
}
