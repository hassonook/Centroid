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

    [MetadataType(typeof(ProfileDocumentMetadata))]
    public partial class ProfileDocument
    {
    }
    public class ProfileDocumentMetadata
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "File Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Display(Name = "File")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Document { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string DocType { get; set; }
        [Required]
        [Display(Name = "Profile")]
        public int ProfileId { get; set; }

    }
}

