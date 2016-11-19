using UnityEngine;
using System.Collections;

public class TreeMovement : MonoBehaviour {

	public float speed = 10f;

	void Start () {
	
	}
	
	void Update () {
		transform.Translate(Vector3.left * speed * Time.deltaTime);
	}


}
