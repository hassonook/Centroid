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
    
    public partial class ProfileDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string DocType { get; set; }
        public int ProfileId { get; set; }
    
        public virtual PersonalInfo Profile { get; set; }
    }
}
