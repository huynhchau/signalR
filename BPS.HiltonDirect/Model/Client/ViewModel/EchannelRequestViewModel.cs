using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Model.Client.ViewModel
{
    public class EchannelRequestViewModel
    {
        public int Id { get; set; }
        public Person Admin2 { get; set; }
        public Person Admin3 { get; set; }
        public Person Admin4 { get; set; }
        public Person Admin5 { get; set; }
        public string DecisionDueDate { get; set; }
        public GenericItem FollowUpActivity { get; set; }
        public bool? IsCommissionable { get; set; }
        public bool? IsCreateTask { get; set; }
        public double? CommissionRate { get; set; }
        public GenericItem MeetingClass { get; set; }
    }
}
