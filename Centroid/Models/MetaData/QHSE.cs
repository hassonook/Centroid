﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(QHSEMetadata))]
    public partial class QHSE
    {
    }
    public class QHSEMetadata
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Vision")]
        [DataType(DataType.MultilineText)]
        public string Vision { get; set; }
        [Required]
        [Display(Name = "Mission")]
        [DataType(DataType.MultilineText)]
        public string Mission { get; set; }
        [Required]
        [Display(Name = "Policy")]
        [DataType(DataType.MultilineText)]
        public string QhsePolicy { get; set; }
        [Required]
        [Display(Name = "Arabic Policy")]
        [DataType(DataType.MultilineText)]
        public string QhsePolicyAr { get; set; }
        [Required]
        [Display(Name = "IMS")]
        [DataType(DataType.MultilineText)]
        public string QhseIMS { get; set; }

    }
}
