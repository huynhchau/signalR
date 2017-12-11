using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model
{
    public class BaseCRUDEntity
    {
        public DateTimeOffset CreatedDate { get; set; }
        public Person CreatedBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public Person ModifiedBy { get; set; }
    }
}
