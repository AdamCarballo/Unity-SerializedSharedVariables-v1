/*
 * SerializedSharedVariables
 * Modify GenerateNewVariable() to generate new SSV
 *
 * by Adam Carballo (AdamCarballo).
 * https://github.com/AdamCarballo/Unity-SerializedSharedVariables
 */

using UnityEditor;
using UnityEngine;

namespace EngyneCreations.SSV.Editor {
	public class SerializedSharedVariableWindow : EditorWindow {

		private const string EditorPrefPrefix = "SSV_";

		private const string GeneratedVariablesPathKey = "GeneratedVariablesPath";
		
		private const string GeneratedVariablesPathDefault = "SerializedSharedVariables/Generated";

		private const string GeneratedDrawersPathKey = "GeneratedDrawersPath";
		
		private const string GeneratedDrawersPathDefault = "SerializedSharedVariables/Generated/Editor";

		private string _generatedVariablesPath;

		private string _generatedDrawersPath;

		private string _newVariableFullName = "MyAmazingNamespace.MyNewClass";

		/// <summary>
		/// Menu item to open the SSV editor window
		/// </summary>
		[MenuItem("Window/Serialized Shared Variables")]
		private static void Init() {
			var window = (SerializedSharedVariableWindow)CreateInstance(typeof(SerializedSharedVariableWindow));
			window.titleContent = new GUIContent("Serialized Shared Variables");
			window.minSize = window.maxSize = new Vector2(640, 260);
			
			window.LoadDefaults();
			window.ShowUtility();
		}

		private void LoadDefaults() {
			_generatedVariablesPath = LoadFromEditorPrefs(GeneratedVariablesPathKey, GeneratedVariablesPathDefault);
			_generatedDrawersPath = LoadFromEditorPrefs(GeneratedDrawersPathKey, GeneratedDrawersPathDefault);
		}

		private void OnGUI() {
			GUILayout.Space(6);
			
			EditorGUILayout.LabelField("Variable Generation", EditorStyles.largeLabel);
			
			_newVariableFullName = EditorGUILayout.TextField("Type Full Name", _newVariableFullName);
			EditorGUILayout.LabelField("Include the full type name, including namespaces (if any).", EditorStyles.miniLabel);
			EditorGUILayout.LabelField("If the type you try to generate is under an assembly (.asmdef) make sure to reference it to the SSV assembly before generating.", EditorStyles.miniLabel);

			GUILayout.Space(4);
			
			if (GUILayout.Button("Generate New Variable")) {
				GenerateNewVariable();
			}
			
			GUILayout.Space(4);
			GUILayout.Box(string.Empty, GUILayout.Height(2), GUILayout.Width(633));
			GUILayout.Space(4);
			
			EditorGUILayout.LabelField("Generation Paths", EditorStyles.largeLabel);

			_generatedVariablesPath = EditorGUILayout.TextField("Variables Path", _generatedVariablesPath);
			EditorGUILayout.LabelField("Path where generated (runtime) variables scripts will be created. Don't include \"/Assets\".", EditorStyles.miniLabel);
			
			GUILayout.Space(4);

			_generatedDrawersPath = EditorGUILayout.TextField("Editor Drawers Path", _generatedDrawersPath);
			EditorGUILayout.LabelField("Path where generated editor drawers scripts will be created. Don't include \"/Assets\".", EditorStyles.miniLabel);

			GUILayout.Space(4);
			
			if (GUILayout.Button("Save Paths")) {
				SaveToEditorPrefs(GeneratedVariablesPathKey, _generatedVariablesPath);
				SaveToEditorPrefs(GeneratedDrawersPathKey, _generatedDrawersPath);
			}
		}

		private void GenerateNewVariable() {
			// Generate Scriptable Object script
			SerializedSharedVariablesGenerator.GenerateNewVariableData(_newVariableFullName, _generatedVariablesPath);

			// Generate Property Drawer script
			SerializedSharedVariablesGenerator.GenerateNewVariableEditor(_newVariableFullName, _generatedDrawersPath);
		}

		private static string LoadFromEditorPrefs(string key, string @default) {
			return EditorPrefs.GetString($"{EditorPrefPrefix}{key}", @default);
		}

		private static void SaveToEditorPrefs(string key, string value) {
			EditorPrefs.SetString($"{EditorPrefPrefix}{key}", value);
		}

	}
}