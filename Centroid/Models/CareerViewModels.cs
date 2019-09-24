using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Centroid.Models
{
    public class CareerViewModels
    {
        public string CareerText { get; set; }
        public List<string> CareerMenu { get; set; }
        public IList<Job> Jobs { get; set; }
    }
}