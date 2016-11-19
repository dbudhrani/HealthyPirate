using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	public int level; // level 1 = upper-body; level 2 = lower-body; level 3 = full body

	public Rigidbody fish;
	public Rigidbody stone;
	public Rigidbody tree;

	private fishGeneration fgScript;
	private StoneGeneration sgScript;
	private TreeGeneration tgScript;

	// Use this for initialization
	void Start () {

		Debug.Log("Level = " + level);

		fgScript = GetComponent<fishGeneration>();
		sgScript = GetComponent<StoneGeneration>();
		tgScript = GetComponent<TreeGeneration>();

		switch (level) {
			case 1:
				disableTrees();
				break;
			case 2:
				disableStones();
				break;
			case 3:
				
				break;
			default:
				Debug.Log("ERROR: level requested is " + level);
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void disableFishes() {
		fgScript.enabled = false;
		Destroy(fish.gameObject);
	}

	void disableStones() {
		sgScript.enabled = false;
		Destroy(stone.gameObject);
	}

	void disableTrees() {
		tgScript.enabled = false;
		Destroy(tree.gameObject);
	}

}
