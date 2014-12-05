using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof (PopUpIntAttribute))]
public class PopUpIntDrawer : PropertyDrawer {

	PopUpIntAttribute _attribute { get { return ((PopUpIntAttribute)attribute); } }

	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		
		return EditorGUI.GetPropertyHeight (prop, label, true);
	}
	
	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {

		if (prop.type == "int") {
			int l = _attribute._list.Count;
			GUIContent[] options = new GUIContent[l];

			for (int i = 0; i < l; i++) {
				options[i] = new GUIContent(""+_attribute._list[i]);
			}

			int selectedIndex = EditorGUI.Popup(position, label, _attribute._list.Contains(prop.intValue) ? _attribute._list.IndexOf(prop.intValue) : 0, options);
			prop.intValue = _attribute._list[selectedIndex];
		} else {
			EditorGUI.LabelField(position, label, new GUIContent("Use int popup with a int property."));
		}
	}
}
