using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {

	public float waterLevel = 0f;
	public float floatHeight = 2f;
	public float bounceDamp = 0.05f;
	public Vector3 buoyancyCenterOffset;

	private float forceFactor;
	private Vector3 actionPoint;
	private Vector3 uplift;
	 	  	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		actionPoint = transform.position + transform.TransformDirection(buoyancyCenterOffset);
		forceFactor = 1f - ((actionPoint.y - waterLevel)/floatHeight);

		if (forceFactor > 0f) {
			uplift = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * bounceDamp);
			GetComponent<Rigidbody>().AddForceAtPosition(uplift, actionPoint);
		}
	}
}
