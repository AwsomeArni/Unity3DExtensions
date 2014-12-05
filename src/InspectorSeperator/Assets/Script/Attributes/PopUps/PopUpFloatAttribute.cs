using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopUpFloatAttribute : PropertyAttribute {
	
	public List<float> _list;
	
	public PopUpFloatAttribute(float val1) {
		_list = new List<float> (new float[] { val1 });
	}
	
	public PopUpFloatAttribute(float val1, float val2) {
		_list = new List<float> (new float[] { val1, val2 });
	}
	
	public PopUpFloatAttribute(float val1, float val2, float val3) {
		_list = new List<float> (new float[] { val1, val2, val3 });
	}
	
	public PopUpFloatAttribute(float val1, float val2, float val3, float val4) {
		_list = new List<float> (new float[] { val1, val2, val3, val4 });
	}
	
	public PopUpFloatAttribute(float val1, float val2, float val3, float val4, float val5) {
		_list = new List<float> (new float[] { val1, val2, val3, val4, val5 });
	}
	
	public PopUpFloatAttribute(float val1, float val2, float val3, float val4, float val5, float val6) {
		_list = new List<float> (new float[] { val1, val2, val3, val4, val5, val6 });
	}
	
	public PopUpFloatAttribute(float val1, float val2, float val3, float val4, float val5, float val6, float val7) {
		_list = new List<float> (new float[] { val1, val2, val3, val4, val5, val6, val7 });
	}
	
	public PopUpFloatAttribute(float val1, float val2, float val3, float val4, float val5, float val6, float val7, float val8) {
		_list = new List<float> (new float[] { val1, val2, val3, val4, val5, val6, val7, val8 });
	}
	
	public PopUpFloatAttribute(float val1, float val2, float val3, float val4, float val5, float val6, float val7, float val8, float val9) {
		_list = new List<float> (new float[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
	}
	
	public PopUpFloatAttribute(float val1, float val2, float val3, float val4, float val5, float val6, float val7, float val8, float val9, float val10) {
		_list = new List<float> (new float[] { val1, val2, val3, val4, val5, val6, val7, val8, val9, val10 });
	}
}
