using UnityEngine;
using System.Collections;

public class MinAttribute : PropertyAttribute {

	public float minValue = 0;

	public MinAttribute (float minValue) {
		this.minValue = minValue;
	}

	public MinAttribute (int minValue) {
		this.minValue = minValue;
	}
}
