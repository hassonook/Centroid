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

    [MetadataType(typeof(CountryMetadata))]
    public partial class Country
    {
    }
    public class CountryMetadata
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Country")]
        [DataType(DataType.Text)]
        public string CountryName { get; set; }

    }
}
