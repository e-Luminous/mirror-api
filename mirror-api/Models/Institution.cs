using System;
using System.Collections.Generic;

namespace mirror_api.Models
{
    public class Institution
    {
        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime UTC { get; set; }
        public string Domain { get; set; }
        public Country Country { get; set; }
        public ICollection<Subscription> Subscribed { get; set; }
        public ICollection<InstLevelGroup> ILG { get; set; }
    }
}