/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

/*
 * SerializedSharedVariablesEditor
 * SSV generator. Modify GenerateNewVariable() to generate new SSV
 *
 * by Adam Carballo (AdamEC).
 * https://github.com/AdamEC/Unity-SerializedSharedVariables
 */

using System;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EngyneCreations.SSV.Editor {

    public static class SerializedSharedVariablesEditor {

        public const string MenuItemCreatePath = "Assets/Create/Engyne Creations/Serialized Shared Variables/";


        [MenuItem(MenuItemCreatePath + "Generate New Variable", false, 50)]
        private static void GenerateNewVariable() {

            //////////////////////////////////////////////////////
            // Change this type for the desired type,           //
            // and then use the Menu Item to generate a new SSV //
            Type type = typeof(int);
            //////////////////////////////////////////////////////

            GenerateNewVariableData(type);
            GenerateNewVariableEditor(type);
        }

        private static void GenerateNewVariableData(Type type) {

            string typeName = FirstLetterToUpper(type.Name);
            string typeFullName = typeof(int).FullName;
            string variableClass = typeName + "Variable";
            string referenceClass = typeName + "Reference";

            // The generated filepath
            string scriptFile = Application.dataPath + "/SOVariables/GeneratedVariables/" + variableClass + ".cs";

            // The class string
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("// This class is Auto-Generated");
            sb.AppendLine("using EngyneCreations.SSV.Models;");
            sb.AppendLine("");
            sb.AppendLine("namespace EngyneCreations.SSV.Variables {");
            sb.AppendLine("");
            sb.AppendLine("    public class " + variableClass + " : SerializedSharedVariable<" + typeFullName + "> { }");
            sb.AppendLine("");
            sb.AppendLine("    [System.Serializable]");
            sb.AppendLine("    public class " + referenceClass + " : SerializedSharedReference<" + variableClass + ", " + typeFullName + "> { }");
            sb.AppendLine("}");

            // Writes the class and imports it so it is visible in the Project window
            System.IO.File.Delete(scriptFile);
            System.IO.File.WriteAllText(scriptFile, sb.ToString(), Encoding.UTF8);
            AssetDatabase.ImportAsset("Assets/SOVariables/GeneratedVariables/" + variableClass + ".cs");
        }

        private static void GenerateNewVariableEditor(Type type) {

            string typeName = FirstLetterToUpper(type.Name);
            string variableClass = typeName + "Variable";
            string referenceClass = typeName + "Reference";
            string referenceDrawerClass = referenceClass + "Drawer";

            // The generated filepath
            string scriptFile = Application.dataPath + "/SOVariables/Editor/GeneratedDrawers/" + referenceDrawerClass + ".cs";

            // The class string
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("// This class is Auto-Generated");
            sb.AppendLine("using EngyneCreations.SSV.Models.Editor;");
            sb.AppendLine("using EngyneCreations.SSV.Editor;");
            sb.AppendLine("");
            sb.AppendLine("namespace EngyneCreations.SSV.Variables.Editor {");
            sb.AppendLine("");
            sb.AppendLine("    [UnityEditor.CustomPropertyDrawer(typeof(" + referenceClass + "))]");

            sb.AppendLine("    public class " + referenceDrawerClass + " : SerializedSharedReferenceDrawer {");
            sb.AppendLine("");
            sb.AppendLine("        [UnityEditor.MenuItem(SerializedSharedVariablesEditor.MenuItemCreatePath + \"" + typeName + "\", false, 0)]");
            sb.AppendLine("        public static void CreateAsset() {");
            sb.AppendLine("            SerializedVariablesHelper.CreateAsset<" + variableClass + ">();");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            // Writes the class and imports it so it is visible in the Project window
            System.IO.File.Delete(scriptFile);
            System.IO.File.WriteAllText(scriptFile, sb.ToString(), Encoding.UTF8);
            AssetDatabase.ImportAsset("Assets/SOVariables/Editor/GeneratedDrawers/" + referenceDrawerClass + ".cs");
        }

        private static string FirstLetterToUpper(string str) {

            if (str == null) return null;
            if (str.Length > 1) return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }
}