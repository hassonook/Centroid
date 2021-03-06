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
    using System.Web;
    using System.Web.Mvc;

    [MetadataType(typeof(CareerMetadata))]
    public partial class Career
    {
    }
    public partial class CareerMetadata
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Career Text")]
        [DataType(DataType.MultilineText)]
        public string CareerMsg { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

    }
}

