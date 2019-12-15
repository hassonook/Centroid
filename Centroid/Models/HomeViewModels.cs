using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Centroid.Models
{
    public class HomeViewModels
    {
        public List<Home> HomeImages { get; set; }
        public string About { get; set; }
        public string Vision { get; set; }
        public List<KeyRecord> KeyRecords { get; set; }
    }

}