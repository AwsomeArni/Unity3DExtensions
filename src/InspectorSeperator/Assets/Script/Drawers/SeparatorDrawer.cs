using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof (SeparatorAttribute))]
public class SeparatorDrawer : PropertyDrawer {

	const float heightPadding = 2.0f;

	SeparatorAttribute separatorAttribute { get { return ((SeparatorAttribute)attribute); } }

	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {

		return base.GetPropertyHeight (prop, label) + (separatorAttribute.height > 0 ? separatorAttribute.height + heightPadding : 0.0f);
	}

	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {

		float tmpHeight = Mathf.Max(separatorAttribute.height, 0.0f);

		Rect separatorRect = position;
		separatorRect.height = tmpHeight;
		separatorRect.x = EditorGUIUtility.currentViewWidth * Mathf.Clamp01(separatorAttribute.xOffset);;
		separatorRect.width = EditorGUIUtility.currentViewWidth * Mathf.Clamp01(separatorAttribute.widthOfView);

		tmpHeight = separatorAttribute.height > 0 ? separatorAttribute.height + heightPadding : 0.0f;

		EditorGUI.DrawRect(separatorRect, separatorAttribute.color);
		EditorGUI.PropertyField(new Rect(position.x, position.y+tmpHeight, position.width, position.height-tmpHeight), prop, label);
	}
}
