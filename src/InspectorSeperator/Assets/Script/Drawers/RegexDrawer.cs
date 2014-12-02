using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text.RegularExpressions;

[CustomPropertyDrawer (typeof (RegexAttribute))]
public class RegexDrawer : PropertyDrawer {

	RegexAttribute _attribute { get { return ((RegexAttribute)attribute); } }
	
	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		
		return EditorGUI.GetPropertyHeight (prop, label, true);
	}
	
	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {

		EditorGUI.BeginChangeCheck ();
		position.width -= 18;
		string value = EditorGUI.TextField (position, label, prop.stringValue);
		if (EditorGUI.EndChangeCheck ()) {
			prop.stringValue = value;
		}

		GUI.enabled = false;
		position.x = EditorGUIUtility.currentViewWidth - 18;
		EditorGUI.Toggle(position, IsValid(prop));
		GUI.enabled = true;
	}

	// Test if the propertys string value matches the regex pattern.
	bool IsValid (SerializedProperty prop) {
		return Regex.IsMatch (prop.stringValue, _attribute.regex);
	}
}
