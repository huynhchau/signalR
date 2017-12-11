//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BPS.HiltonDirect.Repositories
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request
    {
        public int Id { get; set; }
        public Nullable<int> EchannelRequestId { get; set; }
        public Nullable<int> DirectLeadId { get; set; }
        public Nullable<BPS.HiltonDirect.Model.RequestType> RequestType { get; set; }
        public string CreatedById { get; set; }
        public string ModifiedById { get; set; }
        public System.DateTimeOffset CreatedDate { get; set; }
        public System.DateTimeOffset ModifiedDate { get; set; }
    
        public virtual DirectLeadRequest DirectLeadRequest { get; set; }
        public virtual EchannelRequest EchannelRequest { get; set; }
        public virtual Person CreatedBy { get; set; }
        public virtual Person ModifiedBy { get; set; }
    }
}