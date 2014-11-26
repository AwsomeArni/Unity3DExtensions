using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Reflection;
using bf = System.Reflection.BindingFlags; // put this at the top to reduce some typing
using System.Globalization;

[CustomPropertyDrawer (typeof (TargetMethod))]
public class TargetMethodDrawer : PropertyDrawer {

	private int selectedComponentIndex 	= 0;
	private int selectedMethodIndex 	= 0;
	private bool foldout				= false;
	private int argSize					= 0;

	// Here you must define the height of your property drawer. Called by Unity.
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {

		return base.GetPropertyHeight (prop, label) * (prop.isExpanded ? 6 + (foldout ? argSize : 0) : 1);
	}
	
	public override void OnGUI (Rect position, SerializedProperty prop, GUIContent label) {

		prop.serializedObject.Update ();

		float baseHeight = base.GetPropertyHeight (prop, label);
		
		Rect _position = new Rect(position.x, position.y, position.width, baseHeight);
		
		EditorGUI.PropertyField(_position,prop,label);
		
		if (prop.isExpanded) {

			SerializedProperty targetProp 		= prop.FindPropertyRelative("target");;
			SerializedProperty componentProp 	= prop.FindPropertyRelative("component");
			SerializedProperty methodProp 		= prop.FindPropertyRelative("method");
			SerializedProperty argsProp 		= prop.FindPropertyRelative("args");

			TextInfo textInfo = new CultureInfo("en-US",false).TextInfo;

			// TODO: Remove the IndentedRect call as it does not seem to work?
			Rect rect = _position;

			EditorGUI.indentLevel++;

			// - The target property

			rect.y += baseHeight;
			EditorGUI.PropertyField(rect, targetProp, new GUIContent(textInfo.ToTitleCase(targetProp.name)));

			// -

			// Disabled rest of the properties if no GameObject is set.
			bool isEnabled = targetProp.objectReferenceValue != null;
			GUI.enabled = isEnabled;

			// - The component property

			// If the target is set, then fetch its list of components
			Component[] allComponents = targetProp.objectReferenceValue == null ? new Component[0] : (targetProp.objectReferenceValue as GameObject).GetComponents(typeof (Component));

			// Build the list of selectable components
			GUIContent[] componentOptions = new GUIContent[1+allComponents.Length];

			// The list always contains the 'None' options.
			componentOptions[0] = new GUIContent("None");

			// Add the rest of the components, if there are any
			for (int i = 0; i < allComponents.Length; i++) {
				Component component = allComponents[i];
				componentOptions[i+1] = new GUIContent(component.GetType().Name);
			}



			rect.y += baseHeight;
			selectedComponentIndex = EditorGUI.Popup(rect, new GUIContent(textInfo.ToTitleCase(componentProp.name)), selectedComponentIndex, componentOptions);

			// -

			// - The method property

			MethodInfo[] allMethods = selectedComponentIndex > 0 ? allComponents[selectedComponentIndex-1].GetAllMethods((bf.Instance | bf.Public | bf.Default)).ToArray() : new MethodInfo[0];

			GUIContent[] methodOptions = new GUIContent[1+allMethods.Length];

			methodOptions[0] = new GUIContent("None");

			// Add the rest of the methods, if there are any
			for (int i = 0; i < allMethods.Length; i++) {
				MethodInfo method = allMethods[i];
				methodOptions[i+1] = new GUIContent(method.Name);

			}

			rect.y += baseHeight;

			// Only enable this property if a component actually has been chosen.
			GUI.enabled = GUI.enabled && selectedComponentIndex > 0;

			selectedMethodIndex = EditorGUI.Popup(rect, new GUIContent(textInfo.ToTitleCase(methodProp.name)), selectedComponentIndex > 0 ? selectedMethodIndex : 0, methodOptions);

			// -

			// - Show the return type of the selected method

			rect.y += baseHeight;
			EditorGUI.LabelField(rect,new GUIContent(textInfo.ToTitleCase("return type")), new GUIContent(selectedMethodIndex > 0 ? allMethods[selectedMethodIndex-1].ReturnType.Name : "None"));
			
			// -

			// - Show a list of the arguments
			// Change the view of the list of arguments
			// It must show the type of the argument and a container for it -> i.e. a list of serializedproperties? Manually create them?
			
			GUI.enabled = GUI.enabled && selectedMethodIndex > 0;

			rect.y += baseHeight;

			argsProp.arraySize = selectedMethodIndex > 0 ? allMethods[selectedMethodIndex-1].GetParameters ().Length : 0;
			argSize = argsProp.arraySize;
			argsProp.isExpanded = GUI.enabled ? argsProp.isExpanded : false;

			if (argsProp.arraySize > 0 ) {

				foldout = EditorGUI.Foldout(rect, foldout, new GUIContent(textInfo.ToTitleCase(argsProp.name)), true);

				if (foldout) {
					EditorGUI.indentLevel++;
					for (int i = 0; i < argsProp.arraySize; i++) {
						SerializedProperty _prop = argsProp.GetArrayElementAtIndex(i);
						ParameterInfo _param = allMethods[selectedMethodIndex-1].GetParameters()[i];
	//					_prop.objectReferenceValue = _param.DefaultValue;
	//					Debug.Log (_param.Name +" has default value of "+_param.DefaultValue);

						rect.y += baseHeight;
						EditorGUI.PropertyField(rect, _prop, new GUIContent((_param.IsOptional ? "" : "* ") + _param.Name + " : " + _param.ParameterType.Name));
					}
					EditorGUI.indentLevel--;
				}
			} else {
				EditorGUI.LabelField(rect,new GUIContent(textInfo.ToTitleCase("args")), new GUIContent("None"));
			}
			// -
			EditorGUI.indentLevel--;
			GUI.enabled = true;

			prop.serializedObject.ApplyModifiedProperties();
		}
	}
}
