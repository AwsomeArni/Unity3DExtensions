using UnityEngine;
using System.Collections;

public class SpaceAttribute : PropertyAttribute {

	public float height = 5;
	
	public SpaceAttribute () {
		
	}
	
	public SpaceAttribute (float height) {
		this.height = height;
	}

}
