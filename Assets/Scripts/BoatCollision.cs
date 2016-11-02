using UnityEngine;
using System.Collections;

public class BoatCollision : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		Debug.Log("Object name = " + col.gameObject.name);
		if (col.gameObject.name == "Stone(Clone)") {
			Debug.Log("Damn, I crashed");
		}
	}

}
