using MelonLoader.Utils;
using UnityEngine.Rendering.PostProcessing;

namespace Shortcuts
{

    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();    // ModSettings

        }


        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {

            if (sceneName == "CrashMountainRegion" && Settings.options.timberwolfRope)
            {
                
                GameObject.Find("/Art/Climbing/DisabledRopes/Climb50m_topcreek/INTERACTIVE_RopeCliff_50m/Rope_50m").gameObject.SetActive(true);

            }

            if (sceneName == "AshCanyonRegion_EastRidge" && Settings.options.ashCanyonRope)
            {

                GameObject.Find("Root/Art/GrayBlack/INTERACTIVE_RopeCliff_08_50m (2)/Rope_50m").gameObject.SetActive(true);           

            }

            if (sceneName == "CanneryRegion" && Settings.options.bleakRope)
            {

                GameObject.Find("Art/Rocks/INTERACTIVE_RopeCliff_08_100m/Rope_100m").gameObject.SetActive(true);           

            }


            if (sceneName == "BlackrockPrisonSurvivalZone" && Settings.options.prisonGate)
            {

                GameObject.Find("BlackRock_Art/Fences/OBJ_Fence_SecurityMetal_GateVehicleB_Prefab").gameObject.SetActive(false);

            }

            if (sceneName == "BlackrockPrisonSurvivalZone" && Settings.options.prisonDoor)
            {

                GameObject.Find("Design/WorkshopDoor/INTERACTIVE_MetalDoorExt_E_Double_Prefab_UNLOCKED_startDISABLED").gameObject.SetActive(true);
                GameObject.Find("Design/WorkshopDoor/INTERACTIVE_MetalDoorExt_E_Double_Prefab_LOCKED").gameObject.SetActive(false);

            }

            if (sceneName == "LongRailTransitionZone" && Settings.options.branchlineSkip)
            {

                GameObject.Find("Design/Transitions/TracksRegion/TracksExitPoint").transform.SetPositionAndRotation(new Vector3(-178.7009f, 4.3f, 1237.159f), Quaternion.Euler(new Vector3(-0, 180, 0)));
                GameObject.Find("Design/Transitions/HubRegion/HubExitPoint").transform.SetPositionAndRotation(new Vector3(92.0381f, 4.3f, -578.91f), Quaternion.Euler(new Vector3(-0, 180, 0)));

            }

            if (sceneName == "MarshRegion_SANDBOX" && Settings.options.muskegIce)
            {

                GameObject.Find("Design/WeakIceHazards/").gameObject.SetActive(false);


            }




        }


        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {

            //Patches.ChangeObjects();

            if (sceneName == "AirfieldRegion" || sceneName == "MountainTownRegion" || sceneName == "RiverValleyRegion" || sceneName == "WhalingStationRegion" || sceneName == "TracksRegion")
            {
                new ShortcutManager().PlaceTerrain();
            }

            if(sceneName == "MountainPassRegion" || sceneName == "CanneryRegion" || sceneName == "LongRailTransitionZone")
            {
                new ShortcutManager().PlaceAssets();
            }
            
        }

    }
}
