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

        // Path where generated variables will appear on the Assets/Create menu
        public const string MenuItemCreatePath = "Assets/Create/Engyne Creations/Serialized Shared Variables/";
        
        // Path where generated variables scripts will be created. Don't include /Assets
        public const string GeneratedVariablesPath = "/EngyneCreations/SerializedSharedVariables/Generated/";
        
        // Path where generated drawers scripts will be created. Don't include /Assets
        public const string GeneratedDrawersPath = "/EngyneCreations/SerializedSharedVariables/Generated/Editor/";

        
        [MenuItem(MenuItemCreatePath + "Generate New Variable", false, 111)]
        private static void GenerateNewVariable() {

            //////////////////////////////////////////////////////
            // Change this type for the desired type,           //
            // and then use the Menu Item to generate a new SSV //
            Type type = typeof(int);
            //////////////////////////////////////////////////////

            // Generate Scriptable Object script
            SerializedSharedVariablesGenerator.GenerateNewVariableData(type);
            
            // Generate Property Drawer script
	        SerializedSharedVariablesGenerator.GenerateNewVariableEditor(type);
        }
    }
}