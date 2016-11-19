using UnityEngine;
using System.Collections;

public class TreeGeneration : MonoBehaviour {

	public GameObject prefab;
	public float minX = 20.0f;
	public float maxX = 30.0f;
	public float minWaitTime = 2.0f;
	public float maxWaitTime = 4.0f;
	public float treeScale = 1.2f;

	private bool levelCompleted;

	void Start () {
		levelCompleted = false;
		StartCoroutine(generateRandomTree());
	}
	
	void Update () {

	}

	IEnumerator generateRandomTree() {
		while (!levelCompleted) {
			float waitTime = Random.Range(minWaitTime, maxWaitTime);
			yield return new WaitForSeconds (waitTime);
			Vector3 position = new Vector3 (Random.Range (minX, maxX), 0.0f, 0.541536f);
			GameObject newTree = (GameObject)Instantiate (prefab, position, Quaternion.Euler(new Vector3(-30, 0, 0)));
			newTree.transform.localScale = new Vector3(treeScale, treeScale, treeScale);
		}
	}
}
