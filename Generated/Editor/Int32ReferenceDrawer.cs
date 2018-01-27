// This class is Auto-Generated
using EngyneCreations.SSV.Editor;
using EngyneCreations.SSV.Models.Editor;

namespace EngyneCreations.SSV.Variables.Editor {

    [UnityEditor.CustomPropertyDrawer(typeof(Int32Reference))]
    public class Int32ReferenceDrawer : SerializedSharedReferenceDrawer {

        [UnityEditor.MenuItem(SerializedSharedVariables.MenuItemCreatePath + "Int32", false, 0)]
        public static void CreateAsset() {
            SerializedVariablesHelper.CreateAsset<Int32Variable>();
        }
    }
}