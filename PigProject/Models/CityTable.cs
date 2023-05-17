using System;
using System.Collections.Generic;

namespace PigProject.Models
{
    public partial class CityTable
    {
        public CityTable()
        {
            CarDataTables = new HashSet<CarDataTable>();
        }

        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int? CountyId { get; set; }

        public virtual CountyTable? County { get; set; }
        public virtual ICollection<CarDataTable> CarDataTables { get; set; }
    }
}
