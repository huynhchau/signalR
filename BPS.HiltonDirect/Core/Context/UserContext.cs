using BPS.HiltonDirect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Core.Context
{
    public interface IUserContext
    {
        SessionUser User { get; set; }
        Model.Person CurrentUser { get; set; }
    }

    public class UserContext : IUserContext
    {
        public UserContext()
        {

        }
        public SessionUser User { get; set; }
        public Model.Person CurrentUser { get; set; }
    }
}
