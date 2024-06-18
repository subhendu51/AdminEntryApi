using System;
using System.Collections.Generic;

namespace AdminEntryApi.Models
{
    public partial class Country
    {
        public int Countryid { get; set; }
        public string CountryName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
