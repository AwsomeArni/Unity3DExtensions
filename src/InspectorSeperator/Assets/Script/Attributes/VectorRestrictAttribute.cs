using UnityEngine;
using System.Collections;

public class VectorRestrictAttribute : PropertyAttribute {

	public bool considerMin = false;
	public float min = 0;
	public bool considerMax = false;
	public float max = 0;

	public VectorRestrictAttribute() {
		this.considerMin = false;
		this.considerMax = false;
	}

	public VectorRestrictAttribute(float min, float max) {
		if (!Mathf.Approximately(Mathf.Infinity, Mathf.Abs(min))) {
			this.min = min;
			this.considerMin = true;
		} else {
			this.considerMin = false;
		}
		if (!Mathf.Approximately(Mathf.Infinity, Mathf.Abs(max))) {
			this.max = max;
			this.considerMax = true;
		} else {
			this.considerMax = false;
		}
	}

}
