using UnityEngine;
using System.Collections;

public class SeparatorAttribute : PropertyAttribute {

	public const float DEFAULT_HEIGHT 		= 2.0f;
	public const float DEFAULT_WIDTHOFVIEW 	= 1.0f;
	public const float DEFAULT_XOFFSET		= 0.0f;

	public float height = DEFAULT_HEIGHT;
	public float widthOfView = DEFAULT_WIDTHOFVIEW;
	public float xOffset = DEFAULT_XOFFSET;
	public Color color = new Color(0.155f, 0.155f, 0.155f, 0.65f);

	public SeparatorAttribute () {

	}

	public SeparatorAttribute (float height) {
		this.height = height;
	}

	public SeparatorAttribute (float height, float widthOfView) {
		this.height = height;
		this.widthOfView = widthOfView;
		this.xOffset = (1.0f - Mathf.Clamp01(this.widthOfView)) / 2.0f;
	}

	public SeparatorAttribute (float height, float widthOfView, float xOffset) {
		this.height = height;
		this.widthOfView = widthOfView;
		this.xOffset = xOffset;
	}

	public SeparatorAttribute (float height, float widthOfView, float xOffset, float color_r, float color_g, float color_b, float color_a) {
		this.height = height;
		this.widthOfView = widthOfView;
		this.xOffset = xOffset;
		this.color = new Color(color_r, color_g, color_b, color_a);
	}
}
