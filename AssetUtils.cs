using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using MelonLoader;

namespace Shortcuts
{
    internal static class AssetUtils
    {
        public static Dictionary<string, GameObject> cachedPrefabs = new Dictionary<string, GameObject>();
        static Dictionary<string, bool> loadingPrefabs = new Dictionary<string, bool>();

        public static IEnumerator LoadPrefabAsync(string prefabName, Action<GameObject> onComplete)
        {
            if (cachedPrefabs.ContainsKey(prefabName) && cachedPrefabs[prefabName] != null)
            {
                onComplete?.Invoke(cachedPrefabs[prefabName]);
                yield break;
            }

            if (loadingPrefabs.ContainsKey(prefabName) && loadingPrefabs[prefabName])
            {
                while (loadingPrefabs[prefabName])
                {
                    yield return null;
                }
                onComplete?.Invoke(cachedPrefabs.ContainsKey(prefabName) ? cachedPrefabs[prefabName] : null);
                yield break;
            }

            loadingPrefabs[prefabName] = true;
            yield return MelonCoroutines.Start(GeneratePrefabAsync(prefabName, onComplete));
            loadingPrefabs[prefabName] = false;
        }

        private static IEnumerator GeneratePrefabAsync(string prefabName, Action<GameObject> onComplete)
        {
            string meshPath = "";
            string materialPath = "";

            switch (prefabName)
            {
                case "OBJ_WoodPlankSingle":
                    meshPath = "Assets/ArtAssets/Env/Structures/STR_CoastalHouseG/OBJ_WoodPlankSingle.fbx";
                    materialPath = "Assets/ArtAssets/Materials/Global/GLB_WallWoodNatural_B_Flat01.mat";
                    break;

                case "OBJ_WoodPlankSingle2":
                    meshPath = "Assets/ArtAssets/Env/Structures/STR_CoastalHouseG/OBJ_WoodPlankSingle.fbx";
                    materialPath = "Assets/ArtAssets/Materials/Global/GLB_Black_A01.mat";
                    break;

                default:
                    MelonLogger.Warning($"[AssetUtils] Unknown prefab name: {prefabName}");
                    onComplete?.Invoke(null);
                    yield break;
            }

            // Load mesh
            MelonLogger.Msg($"[AssetUtils] Loading mesh: {meshPath}");
            AsyncOperationHandle<Mesh> meshHandle = Addressables.LoadAssetAsync<Mesh>(meshPath);
            yield return meshHandle;

            if (meshHandle.Status != AsyncOperationStatus.Succeeded)
            {
                MelonLogger.Error($"[AssetUtils] Failed to load mesh: {meshPath}");
                if (meshHandle.OperationException != null)
                    MelonLogger.Error($"[AssetUtils] Exception: {meshHandle.OperationException}");
                onComplete?.Invoke(null);
                yield break;
            }

            Mesh loadedMesh = meshHandle.Result;
            if (loadedMesh == null)
            {
                MelonLogger.Error($"[AssetUtils] Loaded mesh is null: {meshPath}");
                onComplete?.Invoke(null);
                yield break;
            }

            // Load material
            MelonLogger.Msg($"[AssetUtils] Loading material: {materialPath}");
            AsyncOperationHandle<Material> materialHandle = Addressables.LoadAssetAsync<Material>(materialPath);
            yield return materialHandle;

            if (materialHandle.Status != AsyncOperationStatus.Succeeded)
            {
                MelonLogger.Error($"[AssetUtils] Failed to load material: {materialPath}");
                if (materialHandle.OperationException != null)
                    MelonLogger.Error($"[AssetUtils] Exception: {materialHandle.OperationException}");
                Addressables.Release(meshHandle);
                onComplete?.Invoke(null);
                yield break;
            }

            Material loadedMaterial = materialHandle.Result;
            if (loadedMaterial == null)
            {
                MelonLogger.Error($"[AssetUtils] Loaded material is null: {materialPath}");
                Addressables.Release(meshHandle);
                onComplete?.Invoke(null);
                yield break;
            }

            // Create GameObject and assign components
            GameObject go = null;

            try
            {
                go = new GameObject(prefabName);

                MeshFilter mf = go.AddComponent<MeshFilter>();
                MeshRenderer mr = go.AddComponent<MeshRenderer>();
                MeshCollider mc = go.AddComponent<MeshCollider>();

                if (mf == null)
                {
                    MelonLogger.Error($"[AssetUtils] Failed to create MeshFilter for {prefabName}");
                    UnityEngine.Object.Destroy(go);
                    Addressables.Release(meshHandle);
                    Addressables.Release(materialHandle);
                    onComplete?.Invoke(null);
                    yield break;
                }

                mf.sharedMesh = loadedMesh;

                if (mr != null)
                {
                    mr.sharedMaterial = loadedMaterial;
                }

                if (mc != null)
                {
                    mc.sharedMesh = loadedMesh;
                }

                MelonLogger.Msg($"[AssetUtils] Successfully created prefab: {prefabName}");
                cachedPrefabs[prefabName] = go;
                onComplete?.Invoke(go);
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"[AssetUtils] Exception creating prefab {prefabName}: {ex.Message}");
                MelonLogger.Error($"[AssetUtils] Stack trace: {ex.StackTrace}");
                if (go != null)
                {
                    UnityEngine.Object.Destroy(go);
                }
                Addressables.Release(meshHandle);
                Addressables.Release(materialHandle);
                onComplete?.Invoke(null);
            }
        }
    }
}