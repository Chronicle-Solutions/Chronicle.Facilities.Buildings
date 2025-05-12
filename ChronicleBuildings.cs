using Chronicle.Plugins.Core;

namespace Chronicle.Facilities.Buildings
{

    public class ChronicleBuildings : IPlugable
    {
        public override string PluginName { get => "Chronicle Building Management"; }
        public override string PluginDescription { get => "Building Management for Facilities"; }
        public override Version Version { get => new Version(0,0,0,1); }



        public override int Execute()
        {
            Buildings b = new Buildings();
            b.Show();
            b.loadData();
            return 0;
        }
    }
}
