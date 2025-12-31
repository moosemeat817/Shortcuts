using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2Cpp;
using UnityEngine;

namespace Shortcuts
{
    internal class SceneUtils
    {
        //Instantiate Terrain
        public static void InstantiateObjectInScene(GameObject prfb, Vector3 pos, Vector3 rot, Vector3 scale)
        {
            if (prfb == null)
            {
                return;
            }

            GameObject go = GameObject.Instantiate<GameObject>(prfb);
            go.transform.position = pos;
            go.transform.rotation = Quaternion.Euler(rot);
            go.transform.localScale = scale;
            go.name = "XXX_" + go.name;

            if (go.GetComponent<Collider>() == null)
            {
                go.AddComponent<MeshCollider>();
            }
        }

        //Instantiate Objects or Structures or Terrains
        public static void PlaceAssetsInScene(string name, Vector3 pos, Vector3 rot, Vector3 scale)
        {
            GameObject prfb = null;

            if (AssetUtils.cachedPrefabs.ContainsKey(name))
            {
                prfb = AssetUtils.cachedPrefabs[name];
            }

            if (prfb == null)
            {
                return;
            }

            GameObject go = GameObject.Instantiate<GameObject>(prfb);
            go.transform.position = pos;
            go.transform.rotation = Quaternion.Euler(rot);
            go.transform.localScale = scale;
            go.name = "ZZZ_" + go.name;
        }
    }
}