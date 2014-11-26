using UnityEngine;
using System.Collections;

public class MaxAttribute : PropertyAttribute {

	public float maxValue = 0;
	
	public MaxAttribute (float maxValue) {
		this.maxValue = maxValue;
	}
	
	public MaxAttribute (int maxValue) {
		this.maxValue = maxValue;
	}
}
