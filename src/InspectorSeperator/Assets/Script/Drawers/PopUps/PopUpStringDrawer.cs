using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof (PopUpStringAttribute))]
public class PopUpStringDrawer : PropertyDrawer {
	
	PopUpStringAttribute _attribute { get { return ((PopUpStringAttribute)attribute); } }
	
	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		
		return EditorGUI.GetPropertyHeight (prop, label, true);
	}
	
	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {

		if (prop.type == "string") {
			int l = _attribute._list.Count;
			GUIContent[] options = new GUIContent[l];
			
			for (int i = 0; i < l; i++) {
				options[i] = new GUIContent(""+_attribute._list[i]);
			}
			
			int selectedIndex = EditorGUI.Popup(position, label, _attribute._list.Contains(prop.stringValue) ? _attribute._list.IndexOf(prop.stringValue) : 0, options);
			prop.stringValue = _attribute._list[selectedIndex];
		} else {
			EditorGUI.LabelField(position, label, new GUIContent("Use string popup with a string property."));
		}
	}
}
