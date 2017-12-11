using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model.Client.ViewModel
{
    public class BaseCRUDEntityViewModel
    {
        public string CreatedDate { get; set; }
        public Person CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Person ModifiedBy { get; set; }
    }
}
