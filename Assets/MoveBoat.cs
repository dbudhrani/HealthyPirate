using UnityEngine;
using System.Collections;

public class MoveBoat : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}

	}
}
