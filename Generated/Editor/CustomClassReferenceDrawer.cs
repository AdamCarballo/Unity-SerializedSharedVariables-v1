// This class is Auto-Generated
using EngyneCreations.SSV.Editor;
using EngyneCreations.SSV.Models.Editor;

namespace EngyneCreations.SSV.Variables.Editor {

    [UnityEditor.CustomPropertyDrawer(typeof(CustomClassReference))]
    public class CustomClassReferenceDrawer : SerializedSharedReferenceDrawer {

        [UnityEditor.MenuItem(MenuItemCreatePath + "CustomClass", false, 100)]
        public static void CreateAsset() {
            SerializedVariablesHelper.CreateAsset<CustomClassVariable>();
        }
    }
}