using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Facilities.Buildings.Objects
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BuildingHour
    {
        [Description("Open Time")]
        [DisplayName("A. Open"), Display(Order = 1)]
        public TimeOnly? openTime { get; set; } = new();

        [Description("Close Time")]
        [DisplayName("B. Close"), Display(Order = 2)]
        public TimeOnly? closeTime { get; set; } = new();

        public override string ToString()
        {
            if (BuildingClosed)
            {
                return "-CLOSED-";
            }
            return $"{openTime:h:mm tt} - {closeTime:h:mm tt}";
        }

        [Description("Building Closed")]
        [DisplayName("Closed")]
        public bool BuildingClosed { get; set; } = false;
    }
}
