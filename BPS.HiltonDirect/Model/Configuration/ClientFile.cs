using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model.Configuration
{
    public class ClientFile
    {
        public string FileName { get; set; }
        public string ServerRelativeUrl { get; set; }
        public string SourceAbsolutePath { get; set; }
        public string FileContent { get; set; }
    }
}
