using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TargetMethod {
	public GameObject target;
	public Component component;
	public string method;
	public List<Object> args;

	public TargetMethod () {
		target = null;
		component = null;
		method = "";
		args = new List<Object>();
	}	
}
