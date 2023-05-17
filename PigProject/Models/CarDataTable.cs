using System;
using System.Collections.Generic;

namespace PigProject.Models
{
    public partial class CarDataTable
    {
        public int VehicleId { get; set; }
        public string? Vin { get; set; }
        public int? ModelYear { get; set; }
        public int? ModelId { get; set; }
        public int? CityId { get; set; }

        public virtual CityTable? City { get; set; }
        public virtual VehicleTable? Model { get; set; }
    }
}
