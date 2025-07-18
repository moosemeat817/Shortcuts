using MelonLoader.Utils;
using UnityEngine.AddressableAssets;
using Il2CppSystem;
using UnityEngine.UIElements;
using UnityEngine;
using Il2Cpp;


namespace Shortcuts
{
    public class ShortcutManager :MonoBehaviour
    {

        public void PlaceTerrain()
        {
            string scene = GameManager.m_ActiveScene;


            if (scene == "AirfieldRegion" && Settings.options.forsakenShort)
            {

                // Forsaken Log Bridge
                GameObject logBridge = GameObject.Find("OBJ_LogBridge_D Variant 2");

                Vector3 position = new Vector3(485.3372f, 271.4397f, -1238.838f);
                Vector3 rotation = new Vector3(0.5093f, 224.9446f, 33.6f);
                Vector3 scale = new Vector3(1, 1, 1);

                SceneUtils.InstantiateObjectInScene(logBridge, position, rotation, scale);


                // Forsaken Midpoint Rock
                GameObject midpointRock = GameObject.Find("TRN_RockCliff_08_Big_C_Prefab");

                Vector3 position2 = new Vector3(117.4428f, 301.0225f, -1267.037f);
                Vector3 rotation2 = new Vector3(11.0001f, 159.3709f, 0);
                Vector3 scale2 = new Vector3(.5f, .5f, .5f);

                SceneUtils.InstantiateObjectInScene(midpointRock, position2, rotation2, scale2);

            }


            if (scene == "HubRegion" && Settings.options.forsakenShort)
            {

                // Forsaken Log Bridge
                GameObject logBridge = GameObject.Find("OBJ_LogBridgeA_Prefab");

                Vector3 position = new Vector3(-283.0278f, 318.4634f, 150.2178f);
                Vector3 rotation = new Vector3(0.0f, 202.2307f, 216.1678f);
                Vector3 scale = new Vector3(1, 1, 1);

                SceneUtils.InstantiateObjectInScene(logBridge, position, rotation, scale);

            }



            if (scene == "RiverValleyRegion" && Settings.options.hushedBridge1)
            {

                // HRV Log Bridge 1
                GameObject logBridge = GameObject.Find("OBJ_LogBridgeB_Prefab (1)");

                Vector3 position = new Vector3(542.9996f, 100.4669f, 1165.538f);
                Vector3 rotation = new Vector3(350, 21.6364f, 10.2546f);
                Vector3 scale = new Vector3(2.2f, 2.2f, 2.2f);

                SceneUtils.InstantiateObjectInScene(logBridge, position, rotation, scale);

            }

            if (scene == "RiverValleyRegion" && Settings.options.hushedBridge2)
            {

                // HRV Log Bridge 2
                GameObject logBridge2 = GameObject.Find("OBJ_LogBridgeC_Prefab");

                Vector3 position2 = new Vector3(866.3497f, 103.045f, 1110.256f);
                Vector3 rotation2 = new Vector3(345.3351f, 111f, 14.3736f);
                Vector3 scale2 = new Vector3(1.7f, 1.7f, 1.7f);

                SceneUtils.InstantiateObjectInScene(logBridge2, position2, rotation2, scale2);

            }

            if (scene == "RiverValleyRegion" && Settings.options.hushedBridge3)
            {

                // HRV Log Bridge 3
                GameObject logBridge3 = GameObject.Find("OBJ_LogBridgeC_Prefab");

                Vector3 position3 = new Vector3(1084.412f, 213.2838f, 1376.174f);
                Vector3 rotation3 = new Vector3(345.3351f, 161.5457f, 11.3736f);
                Vector3 scale3 = new Vector3(1.6f, 1.6f, 1.6f);

                SceneUtils.InstantiateObjectInScene(logBridge3, position3, rotation3, scale3);

            }


            if (scene == "WhalingStationRegion" && Settings.options.lighthouseRock)
            {

                // Lighthouse Rock 1

                GameObject lighthouseRock = GameObject.Find("TRN_RockMid01_Top_Prefab (11)");

                Vector3 position = new Vector3(742.4373f, 22.5393f, 719.7441f);
                Vector3 rotation = new Vector3(354, 311.29f, 180f);
                Vector3 scale = new Vector3(1.5f, 1.3f, 1.3f);

                SceneUtils.InstantiateObjectInScene(lighthouseRock, position, rotation, scale);

                // Lighthouse Rock 2
                GameObject lighthouseRock2 = GameObject.Find("TRN_RockCliffBig06_ClimbA_Prefab");

                Vector3 position2 = new Vector3(730.6368f, -20.7335f, 747.1247f);
                Vector3 rotation2 = new Vector3(332.9999f, 312.2691f, 0);
                Vector3 scale2 = new Vector3(.8f, .7f, 1);

                SceneUtils.InstantiateObjectInScene(lighthouseRock2, position2, rotation2, scale2);

            }


            if (scene == "TracksRegion" && Settings.options.railroadTree)
            {

                // BRoken Railroad Log Bridge
                GameObject logBridge = GameObject.Find("OBJ_LogBridgeA_Prefab");

                Vector3 position = new Vector3(670.4035f, 241.3179f, 1232.979f);
                Vector3 rotation = new Vector3(357.6259f, 95.9862f, 20.8763f);
                Vector3 scale = new Vector3(2f, 1.5f, 1.5f);

                SceneUtils.InstantiateObjectInScene(logBridge, position, rotation, scale);

            }


            if (scene == "BlackrockTransitionZone" && Settings.options.keepersNorth)
            {

                // BRoken Railroad Log Bridge
                GameObject rockFiller = GameObject.Find("TRN_RockCliff_09_Big_A_HS_Prefab (2)");

                Vector3 position = new Vector3(845.3787f, 263.5678f, 8.6656f);
                Vector3 rotation = new Vector3(358.1999f, 178.8229f, 0f);
                Vector3 scale = new Vector3(1.3f, 0.7f, 1f);

                SceneUtils.InstantiateObjectInScene(rockFiller, position, rotation, scale);

            }

            if (scene == "LongRailTransitionZone" && Settings.options.branchlineTree)
            {

                // BRoken Railroad Log Bridge
                GameObject logBridge = GameObject.Find("OBJ_LogBridgeA_Prefab");

                Vector3 position = new Vector3(-4.1286f, 5.86f, 90.8928f);
                Vector3 rotation = new Vector3(5.2229f, 72.4893f, 334.5515f);
                Vector3 scale = new Vector3(1.2f, .9f, 1f);

                SceneUtils.InstantiateObjectInScene(logBridge, position, rotation, scale);

            }

        }






        public void PlaceAssets()
        {
            string scene = GameManager.m_ActiveScene;

            if (scene == "MountainPassRegion" && Settings.options.sunderedPlank)
            {

                // Sundered Bridge Plank
                Vector3 position = new Vector3(380.9419f, 462.3344f, -607.3192f);
                Vector3 rotation = new Vector3(1.4751f, 32.2775f, 6.54f);
                Vector3 scale = new Vector3(3.85f, 2f, 3.5f);

                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", position, rotation, scale);

            }

            /*
            else if (scene == "CanneryRegion" && Settings.options.bleakPlank)
            {

                // Workshop Bridge Plank
                Vector3 position2 = new Vector3(-409.6051f, 31.8377f, -567.3127f);
                Vector3 rotation2 = new Vector3(1.4751f, 37.5107f, 359.649f);
                Vector3 scale2 = new Vector3(2.8f, 2f, 3f);

                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle", position2, rotation2, scale2);
            }
            */

            else if (scene == "LongRailTransitionZone" && Settings.options.branchlineSkip)
            {

                // Tracks Exit Black
                Vector3 position = new Vector3(92.0998f, 0.6497f, -580.5698f);
                Vector3 rotation = new Vector3(87.8053f, 22.8065f, 359.6488f);
                Vector3 scale = new Vector3(50f, 5f, 30f);

                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle2", position, rotation, scale);


                // Hub Exit Black
                Vector3 position2 = new Vector3(-176.7968f, -1.0809f, 1234.891f);
                Vector3 rotation2 = new Vector3(82.5236f, 5f, 0.0001f);
                Vector3 scale2 = new Vector3(50f, 5f, 30f);

                SceneUtils.PlaceAssetsInScene("OBJ_WoodPlankSingle2", position2, rotation2, scale2);
            }

        }

    }
}
