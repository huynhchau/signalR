using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model.Client.ViewModel
{
    public class RequestViewModel : BaseCRUDEntityViewModel
    {
        public int Id { get; set; }
        public Person Admin1 { get; set; }
        public Person SPR { get; set; }
        public string TaskDueDate { get; set; }

        public EchannelRequestViewModel EchannelRequest { get; set; }
        public DirectLeadRequestViewModel DirectLeadRequest { get; set; }
        public RequestType? Type { get; set; }
    }
}
