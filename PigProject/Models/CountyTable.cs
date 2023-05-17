using System;
using System.Collections.Generic;

namespace PigProject.Models
{
    public partial class CountyTable
    {
        public CountyTable()
        {
            CityTables = new HashSet<CityTable>();
            PopDataTables = new HashSet<PopDataTable>();
        }

        public int CountyId { get; set; }
        public string? CountyName { get; set; }

        public virtual ICollection<CityTable> CityTables { get; set; }
        public virtual ICollection<PopDataTable> PopDataTables { get; set; }
    }
}
