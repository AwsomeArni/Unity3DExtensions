using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof (OneLineAttribute))]
public class OneLineDrawer : PropertyDrawer {
	
	OneLineAttribute _attribute { get { return ((OneLineAttribute)attribute); } }

	private GUIContent[] subLabels = new GUIContent[] {new GUIContent("X"), new GUIContent("Y"),
														new GUIContent("Z"), new GUIContent("W")};

	private float magicWidth = 333;

	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		
		return EditorGUI.GetPropertyHeight (prop, label) * (EditorGUIUtility.currentViewWidth < magicWidth ? 2 : 1 );
	}
	
	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {


		if (prop.type == "Vector4f") {
			EditorGUI.BeginProperty(new Rect(position.x, position.y, position.width, GetPropertyHeight(prop, label)),
			                        label, prop);

			float[] _floats = new float[] {prop.vector4Value.x, prop.vector4Value.y,
											prop.vector4Value.z, prop.vector4Value.w};
			EditorGUI.MultiFloatField(position, label, subLabels, _floats);
			prop.vector4Value = new Vector4(_floats[0], _floats[1], _floats[2], _floats[3]);

			EditorGUI.EndProperty ();
		} else {
			EditorGUI.LabelField(position, label, new GUIContent("OneLine only works on Vector4 properties."));
		}
	}
}
