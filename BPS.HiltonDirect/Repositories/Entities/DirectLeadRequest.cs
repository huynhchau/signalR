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
    
    public partial class DirectLeadRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DirectLeadRequest()
        {
            this.Requests = new HashSet<Request>();
        }
    
        public int Id { get; set; }
        public string SPRId { get; set; }
        public string Admin1Id { get; set; }
        public string Note { get; set; }
    
        public virtual Person Admin1 { get; set; }
        public virtual Person SPRPerson { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
