using UnityEngine;
using System.Collections;

public class SeparatorAttribute : PropertyAttribute {

	public float height = 2;
	public Color color = new Color(0.155f, 0.155f, 0.155f, 0.65f);
	public float widthOfView = 1.0f;
	public float xOffset = 0.0f;

	public SeparatorAttribute () {

	}

	public SeparatorAttribute (float height) {
		this.height = height;
	}

//	public SeparatorAttribute (float height, Color color) {
//		this.height = height;
//		this.color = color;
//	}

	public SeparatorAttribute (float height/*, Color color*/, float widthOfView) {
		this.height = height;
//		this.color = color;
		this.widthOfView = widthOfView;
		this.xOffset = (1.0f - Mathf.Clamp01(this.widthOfView)) / 2.0f;
	}

	public SeparatorAttribute (float height/*, Color color*/, float widthOfView, float xOffset) {
		this.height = height;
//		this.color = color;
		this.widthOfView = widthOfView;
		this.xOffset = xOffset;
	}
}
