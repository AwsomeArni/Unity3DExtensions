using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof (ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer {

	ReadOnlyAttribute _attribute { get { return ((ReadOnlyAttribute)attribute); } }

	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		
		return EditorGUI.GetPropertyHeight (prop, label);
	}

	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {

		// TODO: Update the prop such that it holds the value of the script variable?

		GUI.enabled = false;
		EditorGUI.PropertyField(position, prop, label);
		GUI.enabled = true;
	}
}
