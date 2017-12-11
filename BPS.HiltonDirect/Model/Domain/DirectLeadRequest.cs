using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model
{
    public class DirectLeadRequest
    {
        public int Id { get; set; }
        public Person Admin1 { get; set; }
        public Person SPR { get; set; }
        public string Note { get; set; }
    }
}
