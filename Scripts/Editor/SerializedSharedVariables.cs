/*
 * SerializedSharedVariables
 * Modify GenerateNewVariable() to generate new SSV
 *
 * by Adam Carballo (AdamEC).
 * https://github.com/AdamEC/Unity-SerializedSharedVariables
 */

using System;
using UnityEditor;

namespace EngyneCreations.SSV.Editor {

    public static class SerializedSharedVariables {

        public const string MenuItemCreatePath = "Assets/Create/Engyne Creations/Serialized Shared Variables/";

        
        [MenuItem(MenuItemCreatePath + "Generate New Variable", false, 111)]
        private static void GenerateNewVariable() {

            //////////////////////////////////////////////////////
            // Change this type for the desired type,           //
            // and then use the Menu Item to generate a new SSV //
            Type type = typeof(int);
            //////////////////////////////////////////////////////

            SerializedSharedVariablesGenerator.GenerateNewVariableData(type);
	        SerializedSharedVariablesGenerator.GenerateNewVariableEditor(type);
        }
    }
}