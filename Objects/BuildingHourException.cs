using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Facilities.Buildings.Objects
{
    public class BuildingHourException
    {
        [ReadOnly(true)]
        [Browsable(false)]
        public int BuildingHourExceptionID {get; set;}

        [Description("Building Hour Exception Date")]
        [DisplayName("Effective Date")]
        public DateOnly effectiveDate { get; set; } = new();

        [Description("Building Hour Exception Data")]
        [DisplayName("Building Hours")]
        public BuildingHour buildingHours {get; set;} = new();
    }
}
