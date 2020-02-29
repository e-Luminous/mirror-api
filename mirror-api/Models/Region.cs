using System.Collections.Generic;

namespace mirror_api.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; } 
        public ICollection<Country> Countries { get; set; }
        public ICollection<Experiment> Exps { get; set; }
    }
}