using Chronicle.Plugins.Core;

namespace Chronicle.Facilities.Buildings
{

    public class ChronicleBuildings : IPlugable
    {
        public string PluginName { get => "Chronicle Building Management"; }
        public string PluginDescription { get => "Building Management for Facilities"; }
        public  Version Version { get => new Version(0,0,0,1); }



        public int Execute()
        {
            Buildings b = new Buildings();
            b.Show();
            b.loadData();
            return 0;
        }
    }
}
