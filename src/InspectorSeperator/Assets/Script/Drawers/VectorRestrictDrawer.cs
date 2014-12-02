using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

[CustomPropertyDrawer (typeof (VectorRestrictAttribute))]
public class VectorRestrictDrawer : PropertyDrawer {

	private Vector2 _prevVector2 = new Vector2(0,0);
	private Vector3 _prevVector3 = new Vector3(0,0,0);
	private Vector4 _prevVector4 = new Vector4(0,0,0,0);

	private bool _firstTime = true;

	VectorRestrictAttribute _attribute { get { return ((VectorRestrictAttribute)attribute); } }

	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		
		return EditorGUI.GetPropertyHeight (prop, label, true);
	}
	
	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {

		string proptype = prop.type;

		if (_attribute.considerMin && _attribute.considerMax) {
			if (_attribute.min > _attribute.max) {
				EditorGUI.LabelField(position, label, new GUIContent("Min value cannot be greater than max."));
				return;
			}
		}

		// TODO: Use a more proper way of comparing the types..
		if (proptype == (typeof(Vector2).Name+"f")) {

			Vector2 val = prop.vector2Value;
			if (_firstTime) {

				if (_attribute.considerMin) {
					val.x = val.x < _attribute.min ? _attribute.min : val.x;
				}
				if (_attribute.considerMax) {
					val.y = val.y > _attribute.max ? _attribute.max : val.y;
				}

				val.y = val.x > val.y ? val.x : val.y;

				_firstTime = false;
			} else {

				if (!Mathf.Approximately(val.x, _prevVector2.x) && val.x > val.y) {
					val.x = val.y;
				} else if (!Mathf.Approximately(val.y, _prevVector2.y) && val.x > val.y) {
					val.y = val.x;
				}

				if (_attribute.considerMin) {
					val.x = val.x < _attribute.min ? _attribute.min : val.x;
				}
				if (_attribute.considerMax) {
					val.y = val.y > _attribute.max ? _attribute.max : val.y;
				}
			}
			_prevVector2 = val;
			prop.vector2Value = val;

			EditorGUI.PropertyField(position, prop, label);
		} else if (proptype == (typeof(Vector3).Name+"f")) {
			
			Vector3 val = prop.vector3Value;
			
			if (_firstTime) {

				if (_attribute.considerMin) {
					val.x = val.x < _attribute.min ? _attribute.min : val.x;
				}

				if (_attribute.considerMax) {
					val.y = val.y > _attribute.max ? _attribute.max : val.y;
					val.z = val.z > _attribute.max ? _attribute.max : val.z;
				}

				val.y = val.x > val.y ? val.x : val.y;
				val.z = val.y > val.z ? val.y : val.z;

				_firstTime = false;
			} else {

				if (!Mathf.Approximately(val.x, _prevVector3.x) && val.x > val.y) {
					val.x = val.y;
				} else if (!Mathf.Approximately(val.y, _prevVector3.y) && val.y < val.x) {
					val.y = val.x;
				} else if (!Mathf.Approximately(val.y, _prevVector3.y) && val.y > val.z) {
					val.y = val.z;
				} else if (!Mathf.Approximately(val.z, _prevVector3.z) && val.z < val.y) {
					val.z = val.y;
				}

				if (_attribute.considerMin) {
					val.x = val.x < _attribute.min ? _attribute.min : val.x;
				}
				if (_attribute.considerMax) {
					val.y = val.y > _attribute.max ? _attribute.max : val.y;
					val.z = val.z > _attribute.max ? _attribute.max : val.z;
				}
			}
			_prevVector3 = val;
			prop.vector3Value = val;
			
			EditorGUI.PropertyField(position, prop, label);
		} else if (proptype == (typeof(Vector4).Name+"f")) {
			
			Vector4 val = prop.vector4Value;
			
			if (_firstTime) {

				if (_attribute.considerMin) {
					val.x = val.x < _attribute.min ? _attribute.min : val.x;
				}
				if (_attribute.considerMax) {
					val.y = val.y > _attribute.max ? _attribute.max : val.y;
					val.z = val.z > _attribute.max ? _attribute.max : val.z;
					val.w = val.w > _attribute.max ? _attribute.max : val.w;
				}

				val.y = val.x > val.y ? val.x : val.y;
				val.z = val.y > val.z ? val.y : val.z;
				val.w = val.z > val.w ? val.z : val.w;

				_firstTime = false;
			} else {
				
				if (!Mathf.Approximately(val.x, _prevVector4.x) && val.x > val.y) {
					val.x = val.y;
				} else if (!Mathf.Approximately(val.y, _prevVector4.y) && val.y < val.x) {
					val.y = val.x;
				} else if (!Mathf.Approximately(val.y, _prevVector4.y) && val.y > val.z) {
					val.y = val.z;
				} else if (!Mathf.Approximately(val.z, _prevVector4.z) && val.z < val.y) {
					val.z = val.y;
				} else if (!Mathf.Approximately(val.z, _prevVector4.z) && val.z > val.w) {
					val.z = val.w;
				} else if (!Mathf.Approximately(val.w, _prevVector4.w) && val.w < val.z) {
					val.w = val.z;
				}

				if (_attribute.considerMin) {
					val.x = val.x < _attribute.min ? _attribute.min : val.x;
				}
				if (_attribute.considerMax) {
					val.y = val.y > _attribute.max ? _attribute.max : val.y;
					val.z = val.z > _attribute.max ? _attribute.max : val.z;
					val.w = val.w > _attribute.max ? _attribute.max : val.w;
				}
			}
			_prevVector4 = val;
			prop.vector4Value = val;
			
			EditorGUI.PropertyField(position, prop, label, true);
		} else {
			EditorGUI.LabelField(position, label, new GUIContent("Use VectorRestrict with Vectors."));
		}
	}
}
