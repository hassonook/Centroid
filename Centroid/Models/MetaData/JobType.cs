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

    [MetadataType(typeof(JobTypeMetadata))]
    public partial class JobType
    {
    }
    public class JobTypeMetadata
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Job Type Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

    }
}

