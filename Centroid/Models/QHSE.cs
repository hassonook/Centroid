//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Centroid.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QHSE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QHSE()
        {
            this.IsoCertificates = new HashSet<IsoCertificate>();
        }
    
        public int Id { get; set; }
        public string Vision { get; set; }
        public string Mission { get; set; }
        public string QhsePolicy { get; set; }
        public string QhsePolicyAr { get; set; }
        public string QhseIMS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsoCertificate> IsoCertificates { get; set; }
    }
}