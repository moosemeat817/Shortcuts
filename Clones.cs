using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shortcuts
{
    public class Clones : MonoBehaviour
    {
        public static string[,] itemDataArray =
        {
            {"0_Scene", "1_Path"},
            {"LongRailTransitionZone", "OBJ_LogBridgeA_Prefab"},
            {"AshCanyonRegion", "OBJ_LogBridgeA_Prefab"},
            {"BlackrockTransitionZone", "TRN_CaveD_InnerBigL_Prefab"},
            {"BlackrockTransitionZone", "TRN_CaveD_InnerSmall_Prefab"},
            {"CanneryRegion", "OBJ_DockDeck_A_Prefab (33)"},
            {"CanneryRegion", "TRN_SnowClumpFlat_K_Prefab"},
            {"CanneryRegion", "OBJ_DockGangwayHinge_A_Prefab"},
             {"CanneryRegion", "OBJ_DockGangway_A_Prefab"},
            {"DamRiverTransitionZoneB", "Design/Transitions/BrokenWindow/ExteriorLoadTrigger"},
            {"DamTransitionZone_SANDBOX", "Design/Transitions/BrokenWindow/DamWindowEnterPoint"},
        };

        public static void ChangeObjects()
        {
            for (int i = 1; i < itemDataArray.GetLength(0); i++)
            {
                GameObject findTargetGO = FindGameObjectByPath(itemDataArray[i, 1], itemDataArray[i, 0]);
                if (findTargetGO == null)
                    continue;

                string sceneName = itemDataArray[i, 0];
                string objectPath = itemDataArray[i, 1];

                switch (sceneName)
                {
                    case "LongRailTransitionZone":
                        HandleLongRailTransitionZone(findTargetGO, objectPath);
                        break;
                    case "DamRiverTransitionZoneB":
                        HandleDamOutie(findTargetGO, objectPath);
                        break;
                    case "DamTransitionZone_SANDBOX":
                        HandleDamInnie(findTargetGO, objectPath);
                        break;
                    case "BlackrockTransitionZone":
                        HandleBlackrockTransitionZone(findTargetGO, objectPath);
                        break;
                    case "CanneryRegion":
                        HandleCanneryRegion(findTargetGO, objectPath);
                        break;
                }
            }
        }

        /// <summary>
        /// Finds a GameObject by its hierarchical path or name within a specific scene
        /// </summary>
        /// <param name="path">Either a simple name or hierarchical path like "Parent/Child/Target"</param>
        /// <param name="sceneName">Name of the scene to search in</param>
        /// <returns>The found GameObject or null if not found</returns>
        private static GameObject FindGameObjectByPath(string path, string sceneName)
        {
            // If path doesn't contain '/', treat it as a simple name search
            if (!path.Contains("/"))
            {
                GameObject simpleFind = GameObject.Find(path);
                if (simpleFind != null && simpleFind.scene.name == sceneName)
                    return simpleFind;
                return null;
            }

            // Get the scene and validate it
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(sceneName);

            // Check if the scene is valid and loaded
            if (!scene.IsValid() || !scene.isLoaded)
            {
                Debug.LogWarning($"Scene '{sceneName}' is not valid or not loaded yet.");
                return null;
            }

            // Split the path into segments
            string[] pathSegments = path.Split('/');

            // Get root objects from the validated scene
            GameObject[] rootObjects;
            try
            {
                rootObjects = scene.GetRootGameObjects();
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Failed to get root objects from scene '{sceneName}': {ex.Message}");
                return null;
            }

            foreach (GameObject rootObj in rootObjects)
            {
                GameObject result = SearchInHierarchy(rootObj, pathSegments, 0);
                if (result != null)
                    return result;
            }

            return null;
        }

        /// <summary>
        /// Recursively searches through the GameObject hierarchy to find the target path
        /// </summary>
        /// <param name="current">Current GameObject being examined</param>
        /// <param name="pathSegments">Array of path segments to match</param>
        /// <param name="currentIndex">Current index in the path segments</param>
        /// <returns>The found GameObject or null if not found</returns>
        private static GameObject SearchInHierarchy(GameObject current, string[] pathSegments, int currentIndex)
        {
            // If we've reached the end of the path and the current object matches, we found it
            if (currentIndex >= pathSegments.Length)
                return current;

            // Check if current GameObject name matches the current path segment
            if (current.name == pathSegments[currentIndex])
            {
                // If this is the last segment, we found our target
                if (currentIndex == pathSegments.Length - 1)
                    return current;

                // Otherwise, search children for the next segment
                for (int i = 0; i < current.transform.childCount; i++)
                {
                    GameObject child = current.transform.GetChild(i).gameObject;
                    GameObject result = SearchInHierarchy(child, pathSegments, currentIndex + 1);
                    if (result != null)
                        return result;
                }
            }
            else
            {
                // Current name doesn't match, but continue searching children
                // This allows for partial path matching (e.g., starting from any level)
                for (int i = 0; i < current.transform.childCount; i++)
                {
                    GameObject child = current.transform.GetChild(i).gameObject;
                    GameObject result = SearchInHierarchy(child, pathSegments, currentIndex);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Extracts the object name from a path (the last segment)
        /// </summary>
        /// <param name="path">Full path or simple name</param>
        /// <returns>The object name</returns>
        private static string GetObjectNameFromPath(string path)
        {
            if (!path.Contains("/"))
                return path;

            string[] segments = path.Split('/');
            return segments[segments.Length - 1];
        }

        private static void HandleLongRailTransitionZone(GameObject original, string objectPath)
        {
            if (!Settings.options.branchlineSkip)
                return;

            string objectName = GetObjectNameFromPath(objectPath);

            switch (objectName)
            {
                case "OBJ_LogBridgeA_Prefab":
                    CreateCloneIfNotExists(original, "OBJ_LogBridgeA_Prefab(Clone)",
                        new Vector3(-2.92f, 6.9236f, 94.273f),
                        Quaternion.Euler(7.6338f, 61.4907f, 331.7526f),
                        new Vector3(1f, 0.8f, 1.2f));
                    break;
            }
        }

        private static void HandleDamOutie(GameObject original, string objectPath)
        {
            if (!Settings.options.enableDamDoor)
                return;

            string objectName = GetObjectNameFromPath(objectPath);

            switch (objectName)
            {
                case "ExteriorLoadTrigger":
                    CreateCloneIfNotExists(original, "ExteriorLoadTrigger(Clone)",
                        new Vector3(507.89f, 99.03f, 233.44f),
                        Quaternion.Euler(-0f, 160.7112f, 0f),
                        new Vector3(5.0674f, 3.6917f, 4.1176f));
                    break;
            }

        }

        private static void HandleDamInnie(GameObject original, string objectPath)
        {
            if (!Settings.options.enableDamDoor)
                return;

            string objectName = GetObjectNameFromPath(objectPath);

            switch (objectName)
            {
                case "DamWindowEnterPoint":
                    CreateCloneIfNotExists(original, "DamWindowEnterPoint(Clone)",
                        new Vector3(-8.76f, 1.142f, -8.74f),
                        Quaternion.Euler(-0f, 3.9256f, 0f),
                        new Vector3(1f, 1f, 1f));
                    break;
            }

        }

        private static void HandleBlackrockTransitionZone(GameObject original, string objectPath)
        {
            if (!Settings.options.keepersNorth)
                return;

            string objectName = GetObjectNameFromPath(objectPath);

            switch (objectName)
            {
                case "TRN_CaveD_InnerBigL_Prefab":
                    CreateCloneIfNotExists(original, "TRN_CaveD_InnerBigL_Prefab(Clone)",
                        new Vector3(845.0787f, 230.1365f, -20.8914f),
                        Quaternion.Euler(-0, 195.2845f, 355.7997f),
                        new Vector3(1.1f, 1f, 0.6f));
                    break;
                case "TRN_CaveD_InnerSmall_Prefab":
                    // Implementation for small cave if needed
                    break;
            }
        }

        private static void HandleCanneryRegion(GameObject original, string objectPath)
        {
            if (Settings.options.bleakDock)
            {

                string objectName = GetObjectNameFromPath(objectPath);

                switch (objectName)
                {
                    case "OBJ_DockDeck_A_Prefab (33)":
                        // Dock 1
                        CreateCloneIfNotExists(original, "OBJ_DockDeck_A_Prefab (33)(Clone)",
                            new Vector3(-403.4995f, 31.8196f, -572.6019f),
                            Quaternion.Euler(359.9f, 45f, 0.4f));

                        // Dock 2
                        CreateCloneIfNotExists(original, "OBJ_DockDeck_A_Prefab (33)2(Clone)",
                            new Vector3(-410.668f, 31.7596f, -565.4237f),
                            Quaternion.Euler(0.39f, 45f, 0.23f),
                            new Vector3(1.1f, 1f, 1f));
                        break;

                    case "TRN_SnowClumpFlat_K_Prefab":
                        // Snow Cover 1
                        CreateCloneIfNotExists(original, "TRN_SnowClumpFlat_K_Prefab(Clone)",
                            new Vector3(-408.3262f, 32.03f, -573.1393f),
                            Quaternion.Euler(-0, 30.2668f, 0f),
                            new Vector3(0.8f, 0.8f, 0.8f));

                        // Snow Cover 2
                        CreateCloneIfNotExists(original, "TRN_SnowClumpFlat_K_Prefab2(Clone)",
                            new Vector3(-415.2744f, 32.03f, -566.7308f),
                            Quaternion.Euler(-0, 30.2004f, 0f),
                            new Vector3(0.3f, 0.7f, 0.4f));
                        break;
                }
            }

            if (Settings.options.bleakRamps)
            {

                string objectName = GetObjectNameFromPath(objectPath);

                switch (objectName)
                {
                    case "OBJ_DockGangway_A_Prefab":
                        // Ramp 1
                        CreateCloneIfNotExists(original, "OBJ_DockGangway_A_Prefab(Clone)",
                            new Vector3(-394.2528f, 27.4039f, -571.3924f),
                            Quaternion.Euler(-0, 225.7141f, 336.9999f));
                        break;

                    case "OBJ_DockGangwayHinge_A_Prefab":
                        // Hinge 1
                        CreateCloneIfNotExists(original, "OBJ_DockGangwayHinge_A_Prefab(Clone)",
                            new Vector3(-391.5064f, 29.08f, -574.2695f),
                            Quaternion.Euler(-0, 225.114f, 0f));
                        break;
                }
            }
        }

        

        /// <summary>
        /// Creates a clone of the original GameObject if it doesn't already exist
        /// </summary>
        /// <param name="original">Original GameObject to clone</param>
        /// <param name="cloneName">Name for the clone</param>
        /// <param name="position">Position for the clone</param>
        /// <param name="rotation">Rotation for the clone</param>
        /// <param name="scale">Optional scale for the clone</param>
        /// <param name="postSetup">Optional callback for additional setup</param>
        private static void CreateCloneIfNotExists(GameObject original, string cloneName, Vector3 position,
            Quaternion rotation, Vector3? scale = null, Action<GameObject> postSetup = null)
        {
            if (GameObject.Find(cloneName) != null)
                return;

            GameObject clone = Instantiate(original, position, rotation);
            clone.name = cloneName;

            if (scale.HasValue)
                clone.transform.localScale = scale.Value;

            postSetup?.Invoke(clone);
        }
    }
}