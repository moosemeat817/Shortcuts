using ModSettings;

namespace Shortcuts
{
    internal class Shortcuts : JsonModSettings
    {

        [Name("Ash Canyon Rope")]
        [Description("Enable rope near the fishing cabin")]
        public bool ashCanyonRope = false;

        [Name("Blackrock Prison Fence")]
        [Description("Remove one section of the prison gate between the infirmary and barracks")]
        public bool prisonGate = false;

        [Name("Blackrock Workshop Door")]
        [Description("Unlock the prison workshop door")]
        public bool prisonDoor = false;

        [Name("Bleak Inlet Cannery Workshop Plank")]
        [Description("Add a plank to the broken dock by the workshop")]
        public bool bleakPlank = false;

        [Name("Bleak Inlet Rope")]
        [Description("Enable rope near the lookout")]
        public bool bleakRope = false;

        [Name("Broken Railroad Fallen Tree")]
        [Description("Fallen tree on the rocks blocking the railroad tracks")]
        public bool railroadTree = false;

        [Name("Desolation Point Lighthouse Rocks")]
        [Description("Add two rocks to create backside pathway to the lighthouse")]
        public bool lighthouseRock = false;

        [Name("Far Range Branch Line Skip")]
        [Description("Skip the Far Range Branch Line and go directly from Broken Railroad to Transfer Pass (results in a double load screen)")]
        public bool branchlineSkip = false;     

        [Name("Forlorn Muskeg Shortcuts")]
        [Description("Disable the weak ice.  Shortcuts everywhere!")]
        public bool muskegIce = false;

        [Name("Forsaken Airfield Shortcut")]
        [Description("Adds a fallen tree near the region entrance point and rock midway through the short path to the airfield")]
        public bool forsakenShort = false;

        [Name("HRV - Little Bear and Cub Falls Fallen Tree")]
        [Description("Fallen tree across river (leads to area that was previously inaccessible")]
        public bool hushedBridge3 = false;

        [Name("HRV - Reclusive Falls Fallen Tree")]
        [Description("Fallen tree across river")]
        public bool hushedBridge1 = false;

        [Name("HRV - Valley View Point Fallen Tree")]
        [Description("Fallen tree across river")]
        public bool hushedBridge2 = false;
   
        [Name("Sundered Pass Broken Bridge Plank")]
        [Description("Add a plank to the broken bridge")]
        public bool sunderedPlank = false;

        [Name("Timberwolf Mountain Rope")]
        [Description("Enable rope at the top of the creek")]
        public bool timberwolfRope = false;


        [Name("Winding River Dam Door!")]
        [Description("Make dam door open both ways")]
        public bool enableDamDoor = false;















    }

    internal static class Settings
    {
        public static Shortcuts options;

        public static void OnLoad()
        {
            options = new Shortcuts();
            options.AddToModSettings("Shortcuts", MenuType.Both);
        }
    }

}