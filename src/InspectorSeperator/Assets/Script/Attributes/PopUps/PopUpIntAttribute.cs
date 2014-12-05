using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopUpIntAttribute : PropertyAttribute {

	public List<int> _list;
	
	public PopUpIntAttribute(int val1) {
		_list = new List<int> (new int[] { val1 });
	}

	public PopUpIntAttribute(int val1, int val2) {
		_list = new List<int> (new int[] { val1, val2 });
	}

	public PopUpIntAttribute(int val1, int val2, int val3) {
		_list = new List<int> (new int[] { val1, val2, val3 });
	}

	public PopUpIntAttribute(int val1, int val2, int val3, int val4) {
		_list = new List<int> (new int[] { val1, val2, val3, val4 });
	}

	public PopUpIntAttribute(int val1, int val2, int val3, int val4, int val5) {
		_list = new List<int> (new int[] { val1, val2, val3, val4, val5 });
	}

	public PopUpIntAttribute(int val1, int val2, int val3, int val4, int val5, int val6) {
		_list = new List<int> (new int[] { val1, val2, val3, val4, val5, val6 });
	}

	public PopUpIntAttribute(int val1, int val2, int val3, int val4, int val5, int val6, int val7) {
		_list = new List<int> (new int[] { val1, val2, val3, val4, val5, val6, val7 });
	}

	public PopUpIntAttribute(int val1, int val2, int val3, int val4, int val5, int val6, int val7, int val8) {
		_list = new List<int> (new int[] { val1, val2, val3, val4, val5, val6, val7, val8 });
	}

	public PopUpIntAttribute(int val1, int val2, int val3, int val4, int val5, int val6, int val7, int val8, int val9) {
		_list = new List<int> (new int[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
	}

	public PopUpIntAttribute(int val1, int val2, int val3, int val4, int val5, int val6, int val7, int val8, int val9, int val10) {
		_list = new List<int> (new int[] { val1, val2, val3, val4, val5, val6, val7, val8, val9, val10 });
	}
}
