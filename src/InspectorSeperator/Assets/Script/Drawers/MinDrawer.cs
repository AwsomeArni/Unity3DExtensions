using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

[CustomPropertyDrawer (typeof (MinAttribute))]
public class MinDrawer : PropertyDrawer {

	MinAttribute _attribute { get { return ((MinAttribute)attribute); } }
	
	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		
		return EditorGUI.GetPropertyHeight (prop, label, true);
	}
	
	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {

		prop.serializedObject.Update ();

		string proptype = prop.type;
		float constraintValue = _attribute.minValue;
		
		// TODO: Use a more proper way of comparing the types..
		if (proptype == (typeof(Vector2).Name+"f")) {
			
			Vector2 val = prop.vector2Value;
			
			val.x = val.x < constraintValue ? constraintValue : val.x;
			val.y = val.y < constraintValue ? constraintValue : val.y;
			
			prop.vector2Value = val;
			
			EditorGUI.PropertyField(position, prop, label);
		} else if (proptype == (typeof(Vector3).Name+"f")) {
			
			Vector3 val = prop.vector3Value;
			
			val.x = val.x < constraintValue ? constraintValue : val.x;
			val.y = val.y < constraintValue ? constraintValue : val.y;
			val.z = val.z < constraintValue ? constraintValue : val.z;
			
			prop.vector3Value = val;
			
			EditorGUI.PropertyField(position, prop, label);
		} else if (proptype == (typeof(Vector4).Name+"f")) {
			
			Vector4 val = prop.vector4Value;
			
			val.x = val.x < constraintValue ? constraintValue : val.x;
			val.y = val.y < constraintValue ? constraintValue : val.y;
			val.z = val.z < constraintValue ? constraintValue : val.z;
			val.w = val.w < constraintValue ? constraintValue : val.w;
			
			prop.vector4Value = val;
			
			EditorGUI.PropertyField(position, prop, label, true);
		} else if (proptype == "int"/*typeof(int).Name*/) {
			int val = prop.intValue;
			
			val = val < constraintValue ? Mathf.CeilToInt(constraintValue) : val;
			
			prop.intValue = val;
			
			EditorGUI.PropertyField(position, prop, label);
		} else if (proptype == "float"/*(typeof(float).Name)*/) {
			float val = prop.floatValue;
			
			val = val < constraintValue ? constraintValue : val;
			
			prop.floatValue = val;
			
			EditorGUI.PropertyField(position, prop, label);
		} else if (proptype == "double"/*(typeof(double).Name)*/) {
			double val = prop.floatValue;
			
			val = val < constraintValue ? constraintValue : val;
			
			prop.floatValue = (float)val;
			
			EditorGUI.PropertyField(position, prop, label);
		} else {
			EditorGUI.LabelField(position, label, new GUIContent("Use Min with Vectors or numbers."));
		}

		prop.serializedObject.ApplyModifiedProperties ();
	}
}
