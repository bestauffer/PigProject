using System;
using System.Collections.Generic;

namespace PigProject.Models
{
    public partial class PopDataTable
    {
        public int AreaId { get; set; }
        public int? CountyId { get; set; }
        public string? CityName { get; set; }
        public int? Pop2008 { get; set; }
        public int? Pop2009 { get; set; }
        public int? Pop2010 { get; set; }
        public int? Pop2011 { get; set; }
        public int? Pop2012 { get; set; }
        public int? Pop2013 { get; set; }
        public int? Pop2014 { get; set; }
        public int? Pop2015 { get; set; }
        public int? Pop2016 { get; set; }
        public int? Pop2017 { get; set; }
        public int? Pop2018 { get; set; }
        public int? Pop2019 { get; set; }
        public int? Pop2020 { get; set; }
        public int? Pop2021 { get; set; }

        public virtual CountyTable? County { get; set; }
    }
}
