using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model.Client.ViewModel
{
    public class BrowsePageViewModel<T>
    {
        public IEnumerable<T> BrowseItems { get; set; }
        public int TotalRows { get; set; }
        public int CurrentPage { get; set; }
    }
}
