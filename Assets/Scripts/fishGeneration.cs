using UnityEngine;
using System.Collections;

public class fishGeneration : MonoBehaviour {

	public GameObject prefab;
	public float minX = 10.0f;
	public float maxX = 12.0f;
	public float minZ = -3f;
	public float maxZ = 3f;
	public float minWaitTime = 2.0f;
	public float maxWaitTime = 4.0f;
	public float minScale = 0.005f;
	public float maxScale = 0.01f;

	private bool levelCompleted;
	private int counter;

	private Rigidbody fishRigid;
	private MainScript ms;

	void Start () {
		levelCompleted = false;
		fishRigid = GetComponent<Rigidbody>();
		ms = GetComponent<MainScript>();
		StartCoroutine(generateRandomFish());
	}

	void Update () {

	}

	IEnumerator generateRandomFish() {
		while (!levelCompleted) {
			float waitTime = Random.Range (minWaitTime, maxWaitTime);
			yield return new WaitForSeconds (waitTime);
			Vector3 position = new Vector3 (Random.Range (minX, maxX), 0.0f, Random.Range (minZ, maxZ));
			GameObject newFish = (GameObject)Instantiate (prefab, position, Quaternion.Euler(new Vector3(0, -90, 0)));
			ms.incrementTotalNumberFishes();
		}
	}
}
