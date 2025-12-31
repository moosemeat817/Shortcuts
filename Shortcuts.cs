using MelonLoader.Utils;
using UnityEngine.Rendering.PostProcessing;
using MelonLoader;
using UnityEngine;
using System.Collections;

namespace Shortcuts
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "CrashMountainRegion" && Settings.options.timberwolfRope)
            {
                GameObject.Find("/Art/Climbing/DisabledRopes/Climb50m_topcreek/INTERACTIVE_RopeCliff_50m/Rope_50m").gameObject.SetActive(true);
            }

            if (sceneName == "CanneryRegion" && Settings.options.bleakRope)
            {
                GameObject.Find("Art/Rocks/INTERACTIVE_RopeCliff_08_100m/Rope_100m").gameObject.SetActive(true);
            }

            if (sceneName == "CanneryRegion" && Settings.options.bleakDock)
            {
                GameObject.Find("Art/Ocean_Pier/OBJ_DockDeckBroken_A_Prefab (2)").gameObject.SetActive(false);
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

            if (sceneName == "RavineTransitionZone" && Settings.options.ravinebridgeSkip)
            {
                GameObject.Find("Design/Scripting/Transitions/CoastalRegion/TransitionZone").transform.SetPositionAndRotation(new Vector3(-350.77f, 136.18f, 11.42f), Quaternion.Euler(new Vector3(-0, 180, 0)));
                GameObject.Find("Design/Scripting/Transitions/CoastalRegion/TransitionContact").transform.SetPositionAndRotation(new Vector3(-350.77f, 136.18f, 11.42f), Quaternion.Euler(new Vector3(-0, 180, 0)));
                GameObject.Find("Design/Scripting/Transitions/CoastalRegion/CoastalRegionExitPoint").transform.SetPositionAndRotation(new Vector3(-359.63f, 136.50f, 7.67f), Quaternion.Euler(new Vector3(-0, 230, 0)));
            }

            if (sceneName == "BlackrockTransitionZone" && Settings.options.keepersNorth)
            {
                GameObject.Find("Design/Transitions/CanyonCaveTransition/TransitionZone").transform.SetPositionAndRotation(new Vector3(844.41f, 232.34f, -21.10f), Quaternion.Euler(new Vector3(-0, 0, 0)));
                GameObject.Find("Design/Transitions/CanyonCaveTransition/TransitionContact").transform.SetPositionAndRotation(new Vector3(846.50f, 233.09f, -13.41f), Quaternion.Euler(new Vector3(-0, 0, 0)));
                GameObject.Find("Design/Transitions/CanyonCaveTransition/CanyonCave_ExitPoint2").transform.SetPositionAndRotation(new Vector3(841.22f, 231.71f, -34.38f), Quaternion.Euler(new Vector3(-0, 180, 0)));
            }

            if (sceneName == "HubRegion" && Settings.options.hubToSundered)
            {
                GameObject.Find("Design/Transitions/Pass/TransitionZone").transform.SetPositionAndRotation(new Vector3(-199.25f, 396.71f, 691.83f), Quaternion.Euler(new Vector3(-0, 0, 0)));
                GameObject.Find("Design/Transitions/Pass/TransitionContact").transform.SetPositionAndRotation(new Vector3(-199.25f, 396.71f, 691.83f), Quaternion.Euler(new Vector3(-0, 0, 0)));
                GameObject.Find("Design/Transitions/Pass/PassExitPoint").transform.SetPositionAndRotation(new Vector3(-192.60f, 398.04f, 685.84f), Quaternion.Euler(new Vector3(-0, 70, 0)));
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "DamRiverTransitionZoneB" && Settings.options.enableDamDoor)
            {
                GameObject.Find("/Art/Structures/Dam/Fence/Fence_West").gameObject.SetActive(true);
                GameObject.Find("Design/Transitions/BrokenWindow/ExteriorLoadTrigger").transform.SetPositionAndRotation(new Vector3(606.7629f, 90.992f, 268.2598f), Quaternion.Euler(new Vector3(-0, 0, 0)));
                GameObject.Find("Design/Transitions/BrokenWindow/ExteriorLoadTrigger").gameObject.transform.localScale = new Vector3(1.8f, 2f, 2f);
                GameObject.Find("Art/Structures/Dam/Fence/Fence_West/OBJ_fenceSecurityChainB_Prefab 2").transform.SetPositionAndRotation(new Vector3(605.4829f, 91.7588f, 266.4743f), Quaternion.Euler(new Vector3(0, 235.0698f, 224.0751f)));
                GameObject.Find("Art/Structures/Dam/Fence/Fence_West/OBJ_fenceSecurityChainB_Prefab 2").gameObject.transform.localScale = new Vector3(.6f, .4f, .6f);
            }

            if (sceneName == "DamTransitionZone_SANDBOX" && Settings.options.enableDamDoor)
            {
                GameObject.Find("Design/Transitions/BrokenWindow/DamWindowEnterPoint").transform.SetPositionAndRotation(new Vector3(-74.5062f, -5.236f, -15.3471f), Quaternion.Euler(new Vector3(-0, 0, 0)));
            }

            if (sceneName == "AshCanyonRegion" || sceneName == "AirfieldRegion" || sceneName == "LongRailTransitionZone" || sceneName == "MountainTownRegion" || sceneName == "RiverValleyRegion" || sceneName == "WhalingStationRegion" || sceneName == "TracksRegion" || sceneName == "BlackrockTransitionZone")
            {
                new ShortcutManager().PlaceTerrain();
            }

            if (sceneName == "MountainPassRegion" || sceneName == "CanneryRegion" || sceneName == "LongRailTransitionZone")
            {
                MelonCoroutines.Start(new ShortcutManager().PlaceAssetsAsync());
            }

            if (sceneName == "LongRailTransitionZone" || sceneName == "BlackrockTransitionZone" || sceneName == "CanneryRegion" || sceneName == "DamTransitionZone_SANDBOX" || sceneName == "DamRiverTransitionZoneB")
            {
                Clones.ChangeObjects();
            }
        }
    }
}