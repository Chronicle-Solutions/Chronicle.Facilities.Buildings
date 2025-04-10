using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle.Facilities.Buildings.Objects
{
    public class Building
    {
        [Category("Identification")]
        [DisplayName("Building ID")]
        [Description("Building Unique Internal Identifier")]
        public int BuildingID { get => buildingID; }

        // Do not expose this variable.
        [Browsable(false)]
        public int buildingID { get; set; }

        [Category("Identification")]
        [DisplayName("Building Name")]
        [Description("The name of the building.")]
        public string Name { get; set; }

        [Category("Identification")]
        [DisplayName("Building Code")]
        [Description("Short Code to identify building")]
        public string BuildingCode { get; set; }

        [Category("General Information")]
        [DisplayName("Notes")]
        [Description("Notes about the building")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Notes { get; set; }

        [Category("General Information")]
        [DisplayName("URL")]
        [Description("Building Web Page")]
        public string URL { get; set; }

        [Category("General Information")]
        [DisplayName("Active")]
        public bool active { get; set; }

        [Category("Location")]
        [DisplayName("Address")]
        [Description("Physical Address of the Building")]
        public string Location { get; set; }

        [Category("Location")]
        [Description("The coordinates of the building.")]
        public LatLong Coordinates { get; set; } = new LatLong();


        [Category("Location")]
        [Description("Timezone of the building location.")]
        [TypeConverter(typeof(TimezoneConverter))]
        public string Timezone { get; set; } = "UTC";

        [Category("Schedule")]
        [Description("The hours the building is open")]
        [DisplayName("Building Hours")]
        [Editor(typeof(BuildingHoursCollectionEditor), typeof(UITypeEditor))]
        public List<BuildingHours> buildingHours { get; set; } = new();

        [Category("Schedule")]
        [Description("The hours the building is open")]
        [DisplayName("Building Hour Exceptions")]
        [Editor(typeof(BuildingHoursCollectionEditor), typeof(UITypeEditor))]
        public List<BuildingHourException> buildingHourExceptions { get; set; } = new();
    }
}
