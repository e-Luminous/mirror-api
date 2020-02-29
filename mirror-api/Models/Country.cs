using System.Collections.Generic;

namespace mirror_api.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public Region Region { get; set; }
        public ICollection<Institution> Institutions { get; set; }
    }
}