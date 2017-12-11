using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Repositories.Mapping
{
    public class BaseMapper
    {
        protected readonly HiltonDirectEntities context;
        public BaseMapper(HiltonDirectEntities context)
        {
            this.context = context;
        }
    }
}
