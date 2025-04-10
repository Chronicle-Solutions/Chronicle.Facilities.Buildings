using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Facilities.Buildings.Objects
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BuildingHours
    {

        [Browsable(false)]
        [ReadOnly(true)]
        public int BuildingHourRuleID { get; set; }


        [Description("The date that this Building Hour Rule goes into effect.")]
        [DisplayName("Effective Date"), Display(Order = 1)]
        public DateOnly effectiveDate { get; set; } = new();
        
        [Description("Building Hours for Mondays")]
        [DisplayName("1. Monday"), Display(Order = 2)]
        public BuildingHour Monday { get; set; } = new();

        [Description("Building Hours for Tuesdays")]
        [DisplayName("2. Tuesday"), Display(Order = 3)]
        public BuildingHour Tuesday { get; set; } = new();

        [Description("Building Hours for Wednesdays")]
        [DisplayName("3. Wednesday"), Display(Order = 4)]
        public BuildingHour Wednesday { get; set; } = new();

        [Description("Building Hours for Thursdays")]
        [DisplayName("4. Thursday"), Display(Order = 5)]
        public BuildingHour Thursday { get; set; } = new();

        [Description("Building Hours for Fridays")]
        [DisplayName("5. Friday"), Display(Order = 6)]
        public BuildingHour Friday { get; set; } = new();

        [Description("Building Hours for Saturdays")]
        [DisplayName("6. Saturday"), Display(Order = 7)]
        public BuildingHour Saturday { get; set; } = new();

        [Description("Building Hours for Sundays")]
        [DisplayName("7. Sunday"), Display(Order = 8)]
        public BuildingHour Sunday { get; set; } = new();



    }
}
