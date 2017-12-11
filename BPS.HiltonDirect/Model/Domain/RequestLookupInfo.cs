using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model
{
    public class RequestLookupInfo
    {
        public RequestLookupInfo()
        {
            MeetingClasses = new List<GenericItem>();
            FollowUpActivities = new List<GenericItem>();
            Persons = new List<Person>();
        }

        public List<Model.GenericItem> MeetingClasses { get; set; }
        public List<Model.GenericItem> FollowUpActivities { get; set; }
        public List<Person> Persons { get; set; }
        public IEnumerable<GenericItem> RequestTypes
        {
            get
            {
                foreach (Model.RequestType type in Enum.GetValues(typeof(Model.RequestType)))
                {
                    switch (type)
                    {
                        case RequestType.eChannel:
                        case RequestType.Inbound:
                        case RequestType.NSO:
                            yield return new GenericItem
                            {
                                Id = (int)type,
                                Name = type.ToString()
                            };
                            break;
                    }
                }
            }
        }
    }
}
