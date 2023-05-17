using System;
using System.Collections.Generic;

namespace PigProject.Models
{
    public partial class VehicleTable
    {
        public VehicleTable()
        {
            CarDataTables = new HashSet<CarDataTable>();
        }

        public int ModelId { get; set; }
        public string? MakeName { get; set; }
        public string? ModelName { get; set; }

        public virtual ICollection<CarDataTable> CarDataTables { get; set; }
    }
}
