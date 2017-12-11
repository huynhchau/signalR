using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model
{
    public enum RequestType
    {
        eChannel = 1,
        Inbound,
        NSO
    }

    public class Request : BaseCRUDEntity
    {
        public int Id { get; set; }
        public EchannelRequest EchannelRequest { get; set; }
        public DirectLeadRequest DirectLeadRequest { get; set; }
        public RequestType? Type { get; set; }
    }
}
