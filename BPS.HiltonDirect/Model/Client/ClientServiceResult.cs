using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model.Client
{
    public class ClientServiceResult<T, R>
    {
        public bool HasError { get; set; }
        public bool HasWarning { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetail { get; set; }
        public bool HasServerException { get; set; }
        public string WarningMessage { get; set; }
        public int DataCount { get; set; }
        public T Data { get; set; }
        public R Lookup { get; set; }
        public bool HasPermission { get; set; }
    }

    public class ClientServiceResult<T>
    {
        public bool HasError { get; set; }
        public bool HasWarning { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetail { get; set; }
        public bool HasServerException { get; set; }
        public string WarningMessage { get; set; }
        public int DataCount { get; set; }
        public T Data { get; set; }
        public bool HasPermission { get; set; }
    }
}
