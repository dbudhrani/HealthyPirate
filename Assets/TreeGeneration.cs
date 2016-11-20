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
	private bool includeCognitiveChallenge;
	private MainScript ms;

	void Start () {
		levelCompleted = false;
		int numTrees = Random.Range(minTrees, maxTrees);
		ms = GetComponent<MainScript>();
		StartCoroutine(generateRandomTrees(numTrees));
	}
	
	void Update () {

	}

	IEnumerator generateRandomTrees(int qty) {
		while (!levelCompleted) {
			int treesCreated = 0;
			float waitTime = Random.Range(minWaitTime, maxWaitTime);
			yield return new WaitForSeconds (waitTime);
			Vector3 basePosition = new Vector3 (Random.Range (minX, maxX), 0.0f, 0.541536f);
			while (treesCreated < qty) {
				yield return new WaitForSeconds (2);
				Vector3 newTreePosition;
				Quaternion qtn;
				if (includeCognitiveChallenge && Random.Range(0.0f, 2.0f) > 1.0f) {
					qtn = Quaternion.Euler(new Vector3(220, 0, 180));
					newTreePosition = new Vector3(basePosition.x + (treesCreated * distanceBetweenTrees), basePosition.y, 0f);
				} else {
					qtn = Quaternion.Euler(new Vector3(-30, 0, 0));
					newTreePosition = new Vector3(basePosition.x + (treesCreated * distanceBetweenTrees), basePosition.y, basePosition.z);
				}
				GameObject newTree = (GameObject)Instantiate (prefab, newTreePosition, qtn);
				newTree.transform.localScale = new Vector3(treeScale, treeScale, treeScale);
				treesCreated++;	
				ms.incrementTotalNumberTrees();
			}
		}
	}

	public void setIncludeCognitiveChallenge(bool b) {
		this.includeCognitiveChallenge = b;
	}
}
