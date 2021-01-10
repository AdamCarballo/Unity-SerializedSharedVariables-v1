/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

/*
 * SerializedSharedReferenceDrawer
 * Base class of SerializedSharedReference property drawer.
 *
 * by Adam Carballo (AdamCarballo).
 * https://github.com/AdamCarballo/Unity-SerializedSharedVariables
 */

using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EngyneCreations.SSV.Models.Editor {
	public abstract class SerializedSharedReferenceDrawer : PropertyDrawer {

		private const string DropdownIconGuid = "258165f075bc7d345bb55cf2583a8eda";

		protected SerializedProperty UseConstantProperty = null;
		protected SerializedProperty ConstantValue = null;
		protected SerializedProperty Variable = null;

		protected GUIStyle PopupStyle = null;

		private int _amountOfProperties;

		protected virtual void SetProperties(SerializedProperty property) {
			UseConstantProperty = property.FindPropertyRelative("_useConstant");
			ConstantValue = property.FindPropertyRelative("_constantValue");
			Variable = property.FindPropertyRelative("_variable");

			var copyConstantValue = ConstantValue.Copy();
			_amountOfProperties = copyConstantValue.CountInProperty() - 1;

			PopupStyle = new GUIStyle(EditorStyles.label);
			PopupStyle.focused.textColor = PopupStyle.normal.textColor = new Color(0, 0, 0, 0);
			PopupStyle.focused.background = PopupStyle.normal.background = LoadIconWithGuid(DropdownIconGuid);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			EditorGUI.BeginProperty(position, label, property);

			SetProperties(property);

			// Draw label
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			var variablePos = new Rect(position.x + 18, position.y, position.width - 19, position.height);
			var variableMultiplePos = new Rect(position.x + 20, position.y, position.width - 21, 15);
			var popupPos = new Rect(position.x, position.y + 4, 16, 11);

			if (UseConstantProperty.depth == 2) {
				// if list
				popupPos.width = 31;
			}

			// Draw Popup
			UseConstantProperty.boolValue = EditorGUI.Popup(popupPos, Convert.ToInt32(UseConstantProperty.boolValue),
				new[] {"Use Variable", "Use Constant"}, PopupStyle) != 0;

			if (HasMultipleProperties()) {
				ConstantValue.isExpanded = true;

				bool accessChildren = true;
				int index = _amountOfProperties;
				while (ConstantValue.NextVisible(accessChildren) && index > 0) {
					index--;

					EditorGUI.PropertyField(variableMultiplePos, ConstantValue, false);
					variableMultiplePos.y += 18;

					accessChildren = ConstantValue.isArray && ConstantValue.isExpanded;
				}
			} else {
				// Draw variable field
				EditorGUI.PropertyField(HasMultipleProperties() ? variableMultiplePos : variablePos,
					UseConstantProperty.boolValue ? ConstantValue : Variable, GUIContent.none, true);
			}

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			SetProperties(property);

			float totalHeight = EditorGUI.GetPropertyHeight(property, label);
			if (HasMultipleProperties()) {
				totalHeight = totalHeight * _amountOfProperties;
				totalHeight += 2f * _amountOfProperties; // Spacing
			}

			return totalHeight;
		}

		private static Texture2D LoadIconWithGuid(string guid) {
			return AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath(guid));
		}

		private bool HasMultipleProperties() {
			return UseConstantProperty.boolValue && _amountOfProperties > 0;
		}

	}

// Temp
	public static class SerializedVariablesHelper {

		// Temp
		public static void CreateAsset<T>() where T : ScriptableObject {
			var asset = ScriptableObject.CreateInstance<T>();

			string path = AssetDatabase.GetAssetPath(Selection.activeObject);
			if (string.IsNullOrEmpty(path)) {
				path = "Assets";
			} else if (!string.IsNullOrEmpty(Path.GetExtension(path))) {
				path = path.Replace(Path.GetFileName(path), "");
			}

			string finalPath = AssetDatabase.GenerateUniqueAssetPath(path + "/New" + typeof(T).Name + ".asset");

			AssetDatabase.CreateAsset(asset, finalPath);
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();
			Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(finalPath);
		}

	}
}