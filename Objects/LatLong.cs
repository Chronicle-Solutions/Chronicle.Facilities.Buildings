using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Facilities.Buildings.Objects
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class LatLong
    {
        [Description("Latitude of the building location.")]
        public double Latitude { get; set; }

        [Description("Longitude of the building location.")]
        public double Longitude { get; set; }

        public override string ToString()
        {
            return $"{Latitude}, {Longitude}";
        }
    }
}
