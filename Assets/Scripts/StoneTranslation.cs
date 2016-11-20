using UnityEngine;
using System.Collections;

public class StoneTranslation : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
	}
}
