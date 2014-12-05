using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopUpStringAttribute : PropertyAttribute {
	
	public List<string> _list;
	
	public PopUpStringAttribute(string val1) {
		_list = new List<string> (new string[] { val1 });
	}
	
	public PopUpStringAttribute(string val1, string val2) {
		_list = new List<string> (new string[] { val1, val2 });
	}
	
	public PopUpStringAttribute(string val1, string val2, string val3) {
		_list = new List<string> (new string[] { val1, val2, val3 });
	}
	
	public PopUpStringAttribute(string val1, string val2, string val3, string val4) {
		_list = new List<string> (new string[] { val1, val2, val3, val4 });
	}
	
	public PopUpStringAttribute(string val1, string val2, string val3, string val4, string val5) {
		_list = new List<string> (new string[] { val1, val2, val3, val4, val5 });
	}
	
	public PopUpStringAttribute(string val1, string val2, string val3, string val4, string val5, string val6) {
		_list = new List<string> (new string[] { val1, val2, val3, val4, val5, val6 });
	}
	
	public PopUpStringAttribute(string val1, string val2, string val3, string val4, string val5, string val6, string val7) {
		_list = new List<string> (new string[] { val1, val2, val3, val4, val5, val6, val7 });
	}
	
	public PopUpStringAttribute(string val1, string val2, string val3, string val4, string val5, string val6, string val7, string val8) {
		_list = new List<string> (new string[] { val1, val2, val3, val4, val5, val6, val7, val8 });
	}
	
	public PopUpStringAttribute(string val1, string val2, string val3, string val4, string val5, string val6, string val7, string val8, string val9) {
		_list = new List<string> (new string[] { val1, val2, val3, val4, val5, val6, val7, val8, val9 });
	}
	
	public PopUpStringAttribute(string val1, string val2, string val3, string val4, string val5, string val6, string val7, string val8, string val9, string val10) {
		_list = new List<string> (new string[] { val1, val2, val3, val4, val5, val6, val7, val8, val9, val10 });
	}
}
