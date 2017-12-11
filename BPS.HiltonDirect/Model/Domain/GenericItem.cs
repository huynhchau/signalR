using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model
{
    public class GenericItem
    {
        public GenericItem()
        {
            Children = new List<Model.GenericItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
        public bool Active { get; set; }
        public List<Model.GenericItem> Children { get; set; }
    }
}
