// This class is Auto-Generated
using EngyneCreations.SSV.Editor;
using EngyneCreations.SSV.Models.Editor;

namespace EngyneCreations.SSV.Variables.Editor {

    [UnityEditor.CustomPropertyDrawer(typeof(StringReference))]
    public class StringReferenceDrawer : SerializedSharedReferenceDrawer {

        [UnityEditor.MenuItem(MenuItemCreatePath + "String", false, 100)]
        public static void CreateAsset() {
            SerializedVariablesHelper.CreateAsset<StringVariable>();
        }
    }
}