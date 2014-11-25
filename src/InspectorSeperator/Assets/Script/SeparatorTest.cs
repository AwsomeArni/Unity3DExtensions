using UnityEngine;
using System.Collections;

public class SeparatorTest : MonoBehaviour {

	[ReadOnlyAttribute]
	public float a = 1245.8f;

	[ReadOnlyAttribute]
	public float aaa = 1245.8f;
	[SpaceAttribute (25)]
	public float b;
	[SeparatorAttribute (8.0f, 0.8f)]
	public float c;
	[ReadOnly]
	public float d = 124;
	
	[ReadOnlyAttribute]
	[SerializeField]
	private float e = 1288;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
