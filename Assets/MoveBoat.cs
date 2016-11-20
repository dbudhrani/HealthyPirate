using UnityEngine;
using System.Collections;

public class MoveBoat : MonoBehaviour {

	public float speed = 10f;
	public float jumpHeight = 3.5f;
	private Rigidbody boat;

	// Use this for initialization
	void Start () {
		boat = GetComponent<Rigidbody>();
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
		if (Input.GetKey(KeyCode.Space)) {
			//transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
			//GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
			transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, jumpHeight, transform.position.z), 0.75f);

		} else {
			transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0, transform.position.z), 0.75f);
		}
	}
}
