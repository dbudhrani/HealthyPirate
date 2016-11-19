using UnityEngine;
using System.Collections;

public class TreeGeneration : MonoBehaviour {

	public GameObject prefab;
	public float minX = 20.0f;
	public float maxX = 30.0f;
	public float minWaitTime = 60.0f;
	public float maxWaitTime = 80.0f;
	public int minTrees = 1;
	public int maxTrees = 8;
	public float treeScale = 1.2f;
	public float distanceBetweenTrees = 15f;

	private bool levelCompleted;

	void Start () {
		levelCompleted = false;
		int numTrees = Random.Range(minTrees, maxTrees);
		StartCoroutine(generateRandomTrees(numTrees));
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

	IEnumerator generateRandomTrees(int qty) {
		while (!levelCompleted) {
			int treesCreated = 0;
			float waitTime = Random.Range(minWaitTime, maxWaitTime);
			yield return new WaitForSeconds (waitTime);
			Vector3 basePosition = new Vector3 (Random.Range (minX, maxX), 0.0f, 0.541536f);
			while (treesCreated < qty) {
				yield return new WaitForSeconds (2);
				Vector3 newTreePosition = new Vector3(basePosition.x + (treesCreated * distanceBetweenTrees), basePosition.y, basePosition.z);
				GameObject newTree = (GameObject)Instantiate (prefab, newTreePosition, Quaternion.Euler(new Vector3(-30, 0, 0)));
				newTree.transform.localScale = new Vector3(treeScale, treeScale, treeScale);
				treesCreated++;	
			}
		}
	}
}
