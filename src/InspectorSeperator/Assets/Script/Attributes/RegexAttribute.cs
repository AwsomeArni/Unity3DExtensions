using UnityEngine;
using System.Collections;

public class RegexAttribute : PropertyAttribute {

	public string regex;
	public string defaultValue;
	public string helpMessage;

	public RegexAttribute (string regex) {
		this.regex = regex;
		this.defaultValue = "String does not match regex.";
		this.helpMessage = "String must match regex: "+regex;
	}

	public RegexAttribute (string regex, string defaultValue) {
		this.regex = regex;
		this.defaultValue = defaultValue;
		this.helpMessage = "String must match regex: "+regex;
	}

	public RegexAttribute (string regex, string defaultValue, string helpMessage) {
		this.regex = regex;
		this.defaultValue = defaultValue;
		this.helpMessage = helpMessage;
	}
}
