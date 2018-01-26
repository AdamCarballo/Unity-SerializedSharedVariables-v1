// This class is Auto-Generated
using EngyneCreations.SSV.Models.Editor;
using EngyneCreations.SSV.Editor;

namespace EngyneCreations.SSV.Variables.Editor {

    [UnityEditor.CustomPropertyDrawer(typeof(CustomClassReference))]
    public class CustomClassReferenceDrawer : SerializedSharedReferenceDrawer {

        [UnityEditor.MenuItem(SerializedSharedVariablesEditor.MenuItemCreatePath + "CustomClass")]
        public static void CreateAsset() {
            SerializedVariablesHelper.CreateAsset<CustomClassVariable>();
        }
    }
}