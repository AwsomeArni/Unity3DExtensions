using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof (IntAttribute))]
public class IntDrawer : PropertyDrawer {

	private Vector2 _realValueVector2 = new Vector2(0,0);
	private Vector3 _realValueVector3 = new Vector3(0,0,0);
	private Vector4 _realValueVector4 = new Vector4(0,0,0,0);
	private float _realValueFloat = 0.0f;
	private double _realValueDouble = 0.0f;

	private Vector2 _fakeValueVector2 = new Vector2(0,0);
	private Vector3 _fakeValueVector3 = new Vector3(0,0,0);
	private Vector4 _fakeValueVector4 = new Vector4(0,0,0,0);
	private float _fakeValueFloat = 0.0f;
	private double _fakeValueDouble = 0.0f;

	private bool _firstTime = true;

	IntAttribute _attribute { get { return ((IntAttribute)attribute); } }
	
	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		
		return EditorGUI.GetPropertyHeight (prop, label, true);
	}
	
	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {
		
		prop.serializedObject.Update ();
					
		string proptype = prop.type;

		// TODO: Use a more proper way of comparing the types..
		if (proptype == "float"/*(typeof(float).Name)*/) {
			float val = prop.floatValue;

			if (_firstTime) {
				_realValueFloat = val;
				_firstTime = false;
			} else {
				_realValueFloat += val - _fakeValueFloat;
			}

			val = Mathf.Floor(_realValueFloat);
			_fakeValueFloat = val;

			prop.floatValue = val;
			
			EditorGUI.PropertyField(position, prop, label);
		} else if (proptype == "double"/*(typeof(double).Name)*/) {
			double val = prop.floatValue;

			if (_firstTime) {
				_realValueDouble = val;
				_firstTime = false;
			} else {
				_realValueDouble += val - _fakeValueDouble;
			}

			val = Mathf.Floor((float)_realValueDouble);
			_fakeValueDouble = val;

			prop.floatValue = (float)val;
			
			EditorGUI.PropertyField(position, prop, label);
		} else if (proptype == (typeof(Vector2).Name+"f")) {
			
			Vector2 val = prop.vector2Value;
			
			if (_firstTime) {
				_realValueVector2 = val;
				_firstTime = false;
			} else {
				_realValueVector2 += val - _fakeValueVector2;
			}

			val = new Vector2(Mathf.Floor((float)_realValueVector2.x), Mathf.Floor((float)_realValueVector2.y));
			_fakeValueVector2 = val;

			prop.vector2Value = val;
			
			EditorGUI.PropertyField(position, prop, label);
		} else if (proptype == (typeof(Vector3).Name+"f")) {
			
			Vector3 val = prop.vector3Value;
			
			if (_firstTime) {
				_realValueVector3 = val;
				_firstTime = false;
			} else {
				_realValueVector3 += val - _fakeValueVector3;
			}
			
			val = new Vector3(Mathf.Floor((float)_realValueVector3.x), Mathf.Floor((float)_realValueVector3.y), Mathf.Floor((float)_realValueVector3.z));
			_fakeValueVector3 = val;

			prop.vector3Value = val;
			
			EditorGUI.PropertyField(position, prop, label);
		} else if (proptype == (typeof(Vector4).Name+"f")) {
			
			Vector4 val = prop.vector4Value;
			
			if (_firstTime) {
				_realValueVector4 = val;
				_firstTime = false;
			} else {
				_realValueVector4 += val - _fakeValueVector4;
			}
			
			val = new Vector4(Mathf.Floor((float)_realValueVector4.x), Mathf.Floor((float)_realValueVector4.y), Mathf.Floor((float)_realValueVector4.z), Mathf.Floor((float)_realValueVector4.w));
			_fakeValueVector4 = val;

			prop.vector4Value = val;
			
			EditorGUI.PropertyField(position, prop, label, true);
		} else {
			EditorGUI.LabelField(position, label, new GUIContent("Use Int with Vectors and decimal numbers."));
		}

		prop.serializedObject.ApplyModifiedProperties ();
	}
}
