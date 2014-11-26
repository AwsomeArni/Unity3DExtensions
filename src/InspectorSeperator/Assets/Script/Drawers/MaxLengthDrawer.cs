using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

[CustomPropertyDrawer (typeof (MaxLengthAttribute))]
public class MaxLengthDrawer : PropertyDrawer {

	MaxLengthAttribute _attribute { get { return ((MaxLengthAttribute)attribute); } }
	
	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		
		return EditorGUI.GetPropertyHeight (prop, label, true);
	}
	
	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {

		prop.serializedObject.Update();

		string proptype = prop.type;
		int length = _attribute.length;
		
		// TODO: Use a more proper way of comparing the types..
		if (proptype == "string"/*(typeof(string).Name)*/) {

			if (length < 0) {
				EditorGUI.LabelField(position, label, new GUIContent("Then length must be non-negative."));
			} else {
				string val = prop.stringValue;

				val = val.Length > length ? val.Substring(0,length) : val;

				prop.stringValue = val;
				
				EditorGUI.PropertyField(position, prop, label);
			}

		} else {
			EditorGUI.LabelField(position, label, new GUIContent("MaxLength only works on strings."));
		}

		prop.serializedObject.ApplyModifiedProperties ();
	}
}
