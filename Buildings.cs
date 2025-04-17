using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using FontAwesome.Sharp;
using Chronicle.Facilities.Buildings.Objects;
using Chronicle.Utils;

namespace Chronicle.Facilities.Buildings
{
    public partial class Buildings : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        public Buildings()
        {
            InitializeComponent();

            toolStripStatusLabel1.Text = "Loading Data";

        }

        private void populateBuildings()
        {
            SuspendLayout();
            using (MySqlConnection conn = new MySqlConnection(Globals.ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM BUILDINGS";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ListViewItem itm = new();
                    itm.Text = reader.GetInt32("buildingID").ToString();
                    itm.SubItems.Add(TypeConverter<string>.getData(reader, "buildingCode", ""));
                    itm.SubItems.Add(TypeConverter<string>.getData(reader, "buildingName", ""));
                    if (!reader.GetBoolean("active"))
                    {
                        itm.ForeColor = Color.Red;
                        itm.Font = new Font(itm.Font.FontFamily, itm.Font.Size, FontStyle.Italic);
                    }
                    listView1.Items.Add(itm);
                }

                reader.Close();


            }
            ResumeLayout(true);
            PerformLayout();
        }

        private IEnumerable<BuildingHourException> getBuildingHourExceptions(Building b)
        {
            List<BuildingHourException> buildingHourExceptions = new();
            using (MySqlConnection conn = new(Globals.ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM BUILDING_HOUR_EXCEPTIONS A WHERE A.effDate >= (SELECT MAX(B.effDate) FROM BUILDING_HOUR_RULES B " +
                    "WHERE A.buildingID = B.buildingID AND B.effDate < current_timestamp) AND A.buildingID = @bID";
                cmd.Parameters.AddWithValue("@bID", b.BuildingID);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BuildingHourException bh = new()
                    {
                        buildingHours = new()
                        {
                            openTime = reader["openTime"] is DBNull ? null : reader.GetTimeOnly("openTime"),
                            closeTime = reader["closeTime"] is DBNull ? null : reader.GetTimeOnly("closeTime")
                        },
                        effectiveDate = reader.GetDateOnly("effDate"),
                        BuildingHourExceptionID = reader.GetInt32("buildingHourExceptionID")
                    };

                }

            }
            return buildingHourExceptions;
        }

        private IEnumerable<BuildingHours> getBuildingHours(Building b)
        {
            List<BuildingHours> buildingHours = new();
            using (MySqlConnection conn = new(Globals.ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM BUILDING_HOUR_RULES A WHERE A.effDate >= (SELECT MAX(B.effDate) FROM BUILDING_HOUR_RULES B " +
                                  "WHERE A.buildingID = B.buildingID AND B.effDate < current_timestamp) AND A.buildingID = @bID;\r\n";
                cmd.Parameters.AddWithValue("@bID", b.buildingID);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BuildingHours bh = new();
                    bh.Monday = new BuildingHour()
                    {
                        openTime = reader["openM"] is DBNull ? null : reader.GetTimeOnly("openM"),
                        closeTime = reader["closeM"] is DBNull ? null : reader.GetTimeOnly("closeM"),
                        BuildingClosed = reader["openM"] is DBNull

                    };

                    bh.Tuesday = new()
                    {
                        openTime = reader["openT"] is DBNull ? null : reader.GetTimeOnly("openT"),
                        closeTime = reader["closeT"] is DBNull ? null : reader.GetTimeOnly("closeT"),
                        BuildingClosed = reader["closeT"] is DBNull
                    };
                    bh.Wednesday = new()
                    {
                        openTime = reader["openW"] is DBNull ? null : reader.GetTimeOnly("openW"),
                        closeTime = reader["closeW"] is DBNull ? null : reader.GetTimeOnly("closeW"),
                        BuildingClosed = reader["closeW"] is DBNull
                    };
                    bh.Thursday = new()
                    {
                        openTime = reader["openR"] is DBNull ? null : reader.GetTimeOnly("openR"),
                        closeTime = reader["closeR"] is DBNull ? null : reader.GetTimeOnly("closeR"),
                        BuildingClosed = reader["closeR"] is DBNull
                    };
                    bh.Friday = new()
                    {
                        openTime = reader["openF"] is DBNull ? null : reader.GetTimeOnly("openF"),
                        closeTime = reader["closeF"] is DBNull ? null : reader.GetTimeOnly("closeF"),
                        BuildingClosed = reader["closeF"] is DBNull
                    };
                    bh.Saturday = new()
                    {
                        openTime = reader["openA"] is DBNull ? null : reader.GetTimeOnly("openA"),
                        closeTime = reader["closeA"] is DBNull ? null : reader.GetTimeOnly("closeA"),
                        BuildingClosed = reader["closeA"] is DBNull
                    };
                    bh.Sunday = new()
                    {
                        openTime = reader["openS"] is DBNull ? null : reader.GetTimeOnly("openS"),
                        closeTime = reader["closeS"] is DBNull ? null : reader.GetTimeOnly("closeS"),
                        BuildingClosed = reader["closeS"] is DBNull
                    };
                    bh.effectiveDate = reader.GetDateOnly("effDate");
                    bh.BuildingHourRuleID = reader.GetInt32("buildingHourRuleID");
                    buildingHours.Add(bh);
                }
                reader.Close();
            }

            return buildingHours;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
            {
                propertyGrid1.SelectedObject = null;
                return;
            }
            int index = Int32.Parse(listView1.SelectedItems[0].Text);
            using (MySqlConnection conn = new MySqlConnection(Globals.ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM BUILDINGS WHERE buildingID = @bID";
                cmd.Parameters.AddWithValue("@bID", index);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                Building b = new Building();
                b.buildingID = reader.GetInt32("buildingID");
                b.Name = TypeConverter<string>.getData(reader, "buildingName", "");
                b.BuildingCode = TypeConverter<string>.getData(reader, "buildingCode", "");
                b.Notes = TypeConverter<string>.getData(reader, "buildingNotes", "");
                b.URL = TypeConverter<string>.getData(reader, "buildingURL", "");
                b.Location = TypeConverter<string>.getData(reader, "buildingAddress", "");
                b.Coordinates.Latitude = TypeConverter<float>.getData(reader, "buildingLat", 0f);
                b.Coordinates.Longitude = TypeConverter<float>.getData(reader, "buildingLong", 0f);
                b.Timezone = TypeConverter<string>.getData(reader, "buildingTimezone", "");
                b.active = reader.GetBoolean("active");
                b.buildingHours.AddRange(getBuildingHours(b));
                b.buildingHourExceptions.AddRange(getBuildingHourExceptions(b));
                propertyGrid1.SelectedObject = b;
            }

        }

        private void insertBuildingHourException(BuildingHourException bh, Building b)
        {
            using (MySqlConnection conn = new MySqlConnection(Globals.ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO BUILDING_HOUR_EXCEPTIONS (buildingID, effDate, openTime, closeTime) VALUES (@bID, @effDate, @oTime, @cTime);";
                cmd.Parameters.AddWithValue("@bID", b.BuildingID);
                cmd.Parameters.AddWithValue("@effDate", bh.effectiveDate);
                cmd.Parameters.AddWithValue("@oTime", bh.buildingHours.openTime);
                cmd.Parameters.AddWithValue("@cTime", bh.buildingHours.closeTime);
                cmd.ExecuteNonQuery();
                bh.BuildingHourExceptionID = (int)cmd.LastInsertedId;
            }
        }


        private void updateBuildingHourException(BuildingHourException bh, Building b)
        {
            using (MySqlConnection conn = new MySqlConnection(Globals.ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE BUILDING_HOUR_EXCEPTIONS SET buildingID = @bID, effDate = @effDate, openTime = @oTime, closeTime = @cTime WHERE buildingHourExceptionID = @bheid;";
                cmd.Parameters.AddWithValue("@bID", b.BuildingID);
                cmd.Parameters.AddWithValue("@effDate", bh.effectiveDate);
                cmd.Parameters.AddWithValue("@oTime", bh.buildingHours.openTime);
                cmd.Parameters.AddWithValue("@cTime", bh.buildingHours.closeTime);
                cmd.Parameters.AddWithValue("@bheid", bh.BuildingHourExceptionID);
                cmd.ExecuteNonQuery();
            }
        }

        private void insertBuilding(Building b)
        {
            using (MySqlConnection conn = new MySqlConnection(Globals.ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO BUILDINGS " +
                                  "(buildingName, buildingCode, buildingNotes, buildingURL, buildingAddress, buildingLat, buildingLong, buildingTimezone, active) " +
                                  "VALUES (@name, @code, @notes, @url, @addr, @lat, @long, @tz, @active);";
                cmd.Parameters.AddWithValue("@name", b.Name);
                cmd.Parameters.AddWithValue("@code", b.BuildingCode);
                cmd.Parameters.AddWithValue("@notes", b.Notes);
                cmd.Parameters.AddWithValue("@url", b.URL);
                cmd.Parameters.AddWithValue("@addr", b.Location);
                cmd.Parameters.AddWithValue("@lat", b.Coordinates.Latitude);
                cmd.Parameters.AddWithValue("@long", b.Coordinates.Longitude);
                cmd.Parameters.AddWithValue("@tz", b.Timezone);
                cmd.Parameters.AddWithValue("@active", b.active);
                cmd.ExecuteNonQuery();
                b.buildingID = (int)cmd.LastInsertedId;
                propertyGrid1.Refresh();
                
                ListViewItem itm = new();
                itm.Text = b.buildingID.ToString();
                itm.SubItems.Add(b.BuildingCode);
                itm.SubItems.Add(b.Name);
                if (!b.active)
                {
                    itm.ForeColor = Color.Red;
                    itm.Font = new Font(itm.Font.FontFamily, itm.Font.Size, FontStyle.Italic);
                }
                listView1.Items.Add(itm);

            }
        }

        private void insertBuildingHours(BuildingHours bh, Building b)
        {
            using (MySqlConnection conn = new MySqlConnection(Globals.ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO BUILDING_HOUR_RULES " +
                    "(buildingID, effDate, openM, closeM, openT, closeT, openW, closeW, openR, closeR, openF, closeF, openA, closeA, openS, closeS) " +
                    "VALUES (@bID, @effDate, @oM, @cM, @oT, @cT, @oW, @cW, @oR, @cR, @oF, @cF, @oA, @cA, @oS, @cS);";
                cmd.Parameters.AddWithValue("@bID", b.BuildingID);
                cmd.Parameters.AddWithValue("@effDate", bh.effectiveDate);
                cmd.Parameters.AddWithValue("@oM", bh.Monday.BuildingClosed ? null : bh.Monday.openTime);
                cmd.Parameters.AddWithValue("@cM", bh.Monday.BuildingClosed ? null : bh.Monday.closeTime);
                cmd.Parameters.AddWithValue("@oT", bh.Tuesday.BuildingClosed ? null : bh.Tuesday.openTime);
                cmd.Parameters.AddWithValue("@cT", bh.Tuesday.BuildingClosed ? null : bh.Tuesday.openTime);
                cmd.Parameters.AddWithValue("@oW", bh.Wednesday.BuildingClosed ? null : bh.Wednesday.openTime);
                cmd.Parameters.AddWithValue("@cW", bh.Wednesday.BuildingClosed ? null : bh.Wednesday.openTime);
                cmd.Parameters.AddWithValue("@oR", bh.Thursday.BuildingClosed ? null : bh.Thursday.openTime);
                cmd.Parameters.AddWithValue("@cR", bh.Thursday.BuildingClosed ? null : bh.Thursday.openTime);
                cmd.Parameters.AddWithValue("@oF", bh.Friday.BuildingClosed ? null : bh.Friday.openTime);
                cmd.Parameters.AddWithValue("@cF", bh.Friday.BuildingClosed ? null : bh.Friday.openTime);
                cmd.Parameters.AddWithValue("@oA", bh.Saturday.BuildingClosed ? null : bh.Saturday.openTime);
                cmd.Parameters.AddWithValue("@cA", bh.Saturday.BuildingClosed ? null : bh.Saturday.openTime);
                cmd.Parameters.AddWithValue("@oS", bh.Sunday.BuildingClosed ? null : bh.Sunday.openTime);
                cmd.Parameters.AddWithValue("@cS", bh.Sunday.BuildingClosed ? null : bh.Sunday.openTime);
                cmd.ExecuteNonQuery();
                bh.BuildingHourRuleID = (int)cmd.LastInsertedId;
            }
        }

        private void updateBuildingHours(BuildingHours bh, Building b)
        {


            using (MySqlConnection conn = new MySqlConnection(Globals.ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE BUILDING_HOUR_RULES SET " +
                                "buildingID = @bID, effDate = @effDate, openM = @oM, closeM = @cM, openT = @oT, closeT = @cT," +
                                "openW = @oW, closeW = @cW, openR = @oR, closeR = @cR, openF = @oF, closeF = @cF, openA = @oA," +
                                "closeA = @cA, openS = @oS, closeS = @cS WHERE buildingHourRuleID = @bhrid";
                cmd.Parameters.AddWithValue("@bID", b.BuildingID);
                cmd.Parameters.AddWithValue("@effDate", bh.effectiveDate);
                cmd.Parameters.AddWithValue("@oM", bh.Monday.BuildingClosed ? null : bh.Monday.openTime);
                cmd.Parameters.AddWithValue("@cM", bh.Monday.BuildingClosed ? null : bh.Monday.closeTime);
                cmd.Parameters.AddWithValue("@oT", bh.Tuesday.BuildingClosed ? null : bh.Tuesday.openTime);
                cmd.Parameters.AddWithValue("@cT", bh.Tuesday.BuildingClosed ? null : bh.Tuesday.openTime);
                cmd.Parameters.AddWithValue("@oW", bh.Wednesday.BuildingClosed ? null : bh.Wednesday.openTime);
                cmd.Parameters.AddWithValue("@cW", bh.Wednesday.BuildingClosed ? null : bh.Wednesday.openTime);
                cmd.Parameters.AddWithValue("@oR", bh.Thursday.BuildingClosed ? null : bh.Thursday.openTime);
                cmd.Parameters.AddWithValue("@cR", bh.Thursday.BuildingClosed ? null : bh.Thursday.openTime);
                cmd.Parameters.AddWithValue("@oF", bh.Friday.BuildingClosed ? null : bh.Friday.openTime);
                cmd.Parameters.AddWithValue("@cF", bh.Friday.BuildingClosed ? null : bh.Friday.openTime);
                cmd.Parameters.AddWithValue("@oA", bh.Saturday.BuildingClosed ? null : bh.Saturday.openTime);
                cmd.Parameters.AddWithValue("@cA", bh.Saturday.BuildingClosed ? null : bh.Saturday.openTime);
                cmd.Parameters.AddWithValue("@oS", bh.Sunday.BuildingClosed ? null : bh.Sunday.openTime);
                cmd.Parameters.AddWithValue("@cS", bh.Sunday.BuildingClosed ? null : bh.Sunday.openTime);
                cmd.Parameters.AddWithValue("@bhrid", bh.BuildingHourRuleID);
                cmd.ExecuteNonQuery();
            }
        }

        private void updateBuilding(Building b)
        {
            using (MySqlConnection conn = new MySqlConnection(Globals.ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE BUILDINGS SET buildingName = @name," +
                                  "buildingCode = @code, buildingNotes = @notes," +
                                  "buildingURL = @url, buildingAddress= @addr," +
                                  "buildingLat = @lat,buildingLong = @long," +
                                  "buildingTimezone = @tz, active=@active WHERE buildingID = @id";
                cmd.Parameters.AddWithValue("@name", b.Name);
                cmd.Parameters.AddWithValue("@code", b.BuildingCode);
                cmd.Parameters.AddWithValue("@notes", b.Notes);
                cmd.Parameters.AddWithValue("@url", b.URL);
                cmd.Parameters.AddWithValue("@addr", b.Location);
                cmd.Parameters.AddWithValue("@lat", b.Coordinates.Latitude);
                cmd.Parameters.AddWithValue("@long", b.Coordinates.Longitude);
                cmd.Parameters.AddWithValue("@tz", b.Timezone);
                cmd.Parameters.AddWithValue("@id", b.BuildingID);
                cmd.Parameters.AddWithValue("@active", b.active);
                cmd.ExecuteNonQuery();
                propertyGrid1.Refresh();
                ListViewItem itm = listView1.SelectedItems[0];
                itm.Text = b.buildingID.ToString();
                itm.SubItems.Add(b.BuildingCode);
                itm.SubItems.Add(b.Name);
                if (!b.active)
                {
                    itm.ForeColor = Color.Red;
                    itm.Font = new Font(itm.Font.FontFamily, itm.Font.Size, FontStyle.Italic);
                }
            }
        }


        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (propertyGrid1.SelectedObject is not Building b) return;

            toolStripStatusLabel1.Text = "Saving - Please Wait.";


            if (b.buildingID == 0) insertBuilding(b);
            else updateBuilding(b);



            foreach (BuildingHours bh in b.buildingHours)
            {
                if (bh.BuildingHourRuleID == 0) insertBuildingHours(bh, b);
                else updateBuildingHours(bh, b);
            }

            foreach (BuildingHourException bh in b.buildingHourExceptions)
            {
                if (bh.BuildingHourExceptionID == 0) insertBuildingHourException(bh, b);
                else updateBuildingHourException(bh, b);
            }
            toolStripStatusLabel1.Text = "Ready";
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Building b = new();
            propertyGrid1.SelectedObject = b;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Application.OpenForms.Count > 0)
            {
                Application.Exit();
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        public void loadData()
        {
            populateBuildings();
            // Create an instance of a ListView column sorter and assign it
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            Form1.populateMenu(menuToolStripMenuItem.DropDownItems, "/");
            toolStripStatusLabel1.Text = "Ready";
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (propertyGrid1.SelectedObject is not Building b) return;

            toolStripStatusLabel1.Text = "Saving - Please Wait.";

            insertBuilding(b);


            foreach (BuildingHours bh in b.buildingHours)
            {   
                insertBuildingHours(bh, b);
                
            }

            foreach (BuildingHourException bh in b.buildingHourExceptions)
            {
                insertBuildingHourException(bh, b);
            }
            toolStripStatusLabel1.Text = "Ready";
        }
    }


}
