using UnityEngine;
using System.Collections;

public class StoneGeneration : MonoBehaviour {

	public GameObject prefab;
	public float minX = -3.0f;
	public float maxX = 3.0f;
	public float minZ = -3.0f;
	public float maxZ = 3.0f;
	public float minWaitTime = 2.0f;
	public float maxWaitTime = 4.0f;
	public float minScale = 0.005f;
	public float maxScale = 0.01f;

	private bool levelCompleted;
	private int counter;

	// Use this for initialization
	void Start () {
		levelCompleted = false;
		StartCoroutine(generateRandomStone());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator generateRandomStone() {
		while (!levelCompleted) {
			float waitTime = Random.Range(minWaitTime, maxWaitTime);
			yield return new WaitForSeconds(waitTime);
			Vector3 position = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
			//Debug.Log(position);
			GameObject newStone = (GameObject) Instantiate(prefab, position, Quaternion.identity);
			float stoneScale = Random.Range(minScale, maxScale);
			newStone.transform.localScale = new Vector3(stoneScale, stoneScale, stoneScale);
		}
	}
}
