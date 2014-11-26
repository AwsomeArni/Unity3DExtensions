using UnityEngine;
using System.Collections;

public class MaxLengthAttribute : PropertyAttribute {

	public int length = 0;

	public MaxLengthAttribute (int length) {
		this.length = length;
	}
}
