// This class is Auto-Generated
using EngyneCreations.SSV.Editor;
using EngyneCreations.SSV.Models.Editor;

namespace EngyneCreations.SSV.Variables.Editor {

    [UnityEditor.CustomPropertyDrawer(typeof(Vector3Reference))]
    public class Vector3ReferenceDrawer : SerializedSharedReferenceDrawer {

        [UnityEditor.MenuItem(SerializedSharedVariables.MenuItemCreatePath + "Vector3", false, 100)]
        public static void CreateAsset() {
            SerializedVariablesHelper.CreateAsset<Vector3Variable>();
        }
    }
}
