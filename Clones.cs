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
            {"0_Scene",              "1_Name"},
            {"LongRailTransitionZone",  "OBJ_LogBridgeA_Prefab"},

            {"AshCanyonRegion",  "OBJ_LogBridgeA_Prefab"},

            {"BlackrockTransitionZone",  "TRN_CaveD_InnerBigL_Prefab"},
            {"BlackrockTransitionZone",  "TRN_CaveD_InnerSmall_Prefab"},



        };

        public static void ChangeObjects()
        {

            GameObject findTargetGO = new GameObject();



            for (int i = 1; i < itemDataArray.GetLength(0); i++)
            {
                // ----- Find Name -----------------------------------------------------------------
                if (GameObject.Find(itemDataArray[i, 1]) == null)
                {
                    //MelonLogger.Msg("ChangeObject is null.");
                    continue;
                }
                else
                {
                    findTargetGO = GameObject.Find(itemDataArray[i, 1]);
                    // GameObject.Find cannot find for already inactive game objects. So this needs to be reloaded after confermation.
                }
                // -------------------------------------------------------------------------------------


                if (findTargetGO != null)
                {
                    // ----- Scene check -----------------------------------------------------------------
                    if (findTargetGO.scene.name != itemDataArray[i, 0]) // Scene 
                    {
                        //MelonLogger.Msg("Scene name does not match.");
                        continue;
                    }
                    // -------------------------------------------------------------------------------------


                    // ==============================================================================================================
                    // Long Rail Transition Zone 
                    // ==============================================================================================================

                    if (itemDataArray[i, 0] == "LongRailTransitionZone" && Settings.options.branchlineSkip)
                    {

                        // Roof ------------------------------------------------------------------------------------------
                        if (itemDataArray[i, 1] == "OBJ_LogBridgeA_Prefab" && !GameObject.Find("OBJ_LogBridgeA_Prefab(Clone)"))
                        {
                            GameObject cloneObject = Instantiate(
                                findTargetGO,
                                new Vector3(-2.92f, 6.9236f, 94.273f),
                                Quaternion.Euler(7.6338f, 61.4907f, 331.7526f)
                            );
                            cloneObject.transform.localScale = new Vector3(1f, 0.8f, 1.2f);


                        }
                        // ------------------------------------------------------------------------------------------
                       

                    }

                    // ==============================================================================================================
                    // Ash Canyon
                    // ==============================================================================================================

                    /*
                    if (itemDataArray[i, 0] == "AshCanyonRegion")
                    {

                        // Roof ------------------------------------------------------------------------------------------
                        if (itemDataArray[i, 1] == "OBJ_LogBridgeA_Prefab" && !GameObject.Find("OBJ_LogBridgeA_Prefab(Clone)"))
                        {
                            GameObject cloneObject = Instantiate(
                                findTargetGO,
                                new Vector3(-2.92f, 6.9236f, 94.273f),
                                Quaternion.Euler(7.6338f, 61.4907f, 331.7526f)
                            );
                            cloneObject.transform.localScale = new Vector3(1f, 0.8f, 1.2f);


                        }
                        // ------------------------------------------------------------------------------------------


                    }
                    */

                    // ==============================================================================================================
                    // Ash Canyon
                    // ==============================================================================================================

                    if (itemDataArray[i, 0] == "BlackrockTransitionZone" && Settings.options.keepersNorth)
                    {

                        
                        // Roof ------------------------------------------------------------------------------------------
                        if (itemDataArray[i, 1] == "TRN_CaveD_InnerBigL_Prefab" && !GameObject.Find("TRN_CaveD_InnerBigL_Prefab(Clone)"))
                        {
                            GameObject cloneObject = Instantiate(
                                findTargetGO,
                                new Vector3(845.0787f, 230.1365f, -20.8914f),
                                Quaternion.Euler(-0, 195.2845f, 355.7997f)
                            );
                            cloneObject.transform.localScale = new Vector3(1.1f, 1f, .6f);


                        }
                        // ------------------------------------------------------------------------------------------


                    }

                }

            }

        }

    }
}
