using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof (SpaceAttribute))]
public class SpaceDrawer : PropertyDrawer {
	
	SpaceAttribute spaceAttribute { get { return ((SpaceAttribute)attribute); } }
	
	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		
		return base.GetPropertyHeight (prop, label) + Mathf.Max(spaceAttribute.height, 0.0f);
	}
	
	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {
		
		float tmpHeight = Mathf.Max(spaceAttribute.height, 0.0f);
		
		Rect spaceRect = position;
		spaceRect.height = tmpHeight;
		spaceRect.x = 0;
		spaceRect.width = 0;

		EditorGUI.DrawRect(spaceRect, Color.black);
		EditorGUI.PropertyField(new Rect(position.x, position.y+tmpHeight, position.width, position.height-tmpHeight), prop, label);
	}
}
