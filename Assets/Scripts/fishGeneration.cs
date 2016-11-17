using UnityEngine;
using System.Collections;

public class fishGeneration : MonoBehaviour {

	public GameObject prefab;
	public float minX = 10.0f;
	public float maxX = 12.0f;
	public float minZ = -1f;
	public float maxZ = 1f;
	public float minWaitTime = 2.0f;
	public float maxWaitTime = 4.0f;
	public float minScale = 0.005f;
	public float maxScale = 0.01f;

	private bool levelCompleted;
	private int counter;

	private Rigidbody fishRigid;
	// Use this for initialization
	void Start () {
		levelCompleted = false;
		StartCoroutine(generateRandomFish());
		fishRigid = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void Move()
	{
		float randomY  = Random.Range(-3, 4);
		Vector3 vector = new Vector3 (0f, randomY, 0f);
		//transform.Translate(Vector3.left * speed * Time.deltaTime);
		fishRigid.MovePosition (vector);
	}

	IEnumerator generateRandomFish() {
		while (!levelCompleted) {
			float waitTime = Random.Range (minWaitTime, maxWaitTime);
			yield return new WaitForSeconds (waitTime);
			Vector3 position = new Vector3 (Random.Range (minX, maxX), 0.0f, Random.Range (minZ, maxZ));
			//Debug.Log(position);
			GameObject newStone = (GameObject)Instantiate (prefab, position, Quaternion.Euler(new Vector3(0, -90, 0)));
		}
	}
}
