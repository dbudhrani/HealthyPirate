using UnityEngine;
using System.Collections;

public class BoatCollision : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		Debug.Log("Object name = " + col.gameObject.name);
		if (col.gameObject.name == "Stone(Clone)" || col.gameObject.name == "Stone") {
			Debug.Log("Damn, I crashed");
		}
		if (col.gameObject.name == "cruscarp(Clone)" || col.gameObject.name == "cruscarp") {
			Debug.Log("Genius, I got a fish!");
		}
		if (col.gameObject.name == "Tree(Clone)" || col.gameObject.name == "Tree") {
			Debug.Log("I crashed with a tree!");
		}
	}

}
