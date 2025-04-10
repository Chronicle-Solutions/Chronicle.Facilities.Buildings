using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chronicle.Facilities.Buildings
{
    public partial class BuildingHourForm : Form
    {
        public DateTime OpenTime
        {
            get => openTime.Value;
            set => openTime.Value = value;
        }

        public DateTime CloseTime
        {
            get => closeTime.Value;
            set => closeTime.Value = value;
        }

        public DateTime EffDate
        {
            get => effDate.Value;
            set => effDate.Value = value;
        }

        public string DayOfWeek
        {
            get => dayOfWeek.Text;
            set => dayOfWeek.Text = value;
        }

        public BuildingHourForm()
        {
            InitializeComponent();
            
        }
    }
}
