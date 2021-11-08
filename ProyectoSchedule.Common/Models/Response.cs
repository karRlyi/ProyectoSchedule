using System.Collections.Generic;

namespace ProyectoSchedule.Common.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; internal set; }
        public object Result { get; internal set; }
    }
}
