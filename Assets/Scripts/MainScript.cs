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

	private int numFishes;
	private int numStones;
	private int numTrees;

	private int capturedFishes;
	private int collidedStones;
	private int collidedTrees;

	// Use this for initialization
	void Start () {

		Debug.Log("Level = " + level);

		numFishes = 0;
		numStones = 0;
		numTrees = 0;

		capturedFishes = 0;
		collidedStones = 0;
		collidedTrees = 0;

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

        Debug.Log("kukujaku" +  PlayerPrefs.GetInt("levelSelected"));
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

	public void incrementTotalNumberFishes() {
		numFishes++;
	}

	public void incrementCapturedNumberFishes() {
		capturedFishes++;
	}

	public void incrementTotalNumberStones() {
		numStones++;
	}

	public void incrementCollidedNumberStones() {
		collidedStones++;
	}

	public void incrementTotalNumberTrees() {
		numTrees++;
	}

	public void incrementCollidedNumberTrees() {
		collidedTrees++;
	}

	public int getTotalNumberFishes() {
		return numFishes;
	}

	public int getCapturedNumberFishes() {
		return capturedFishes;
	}

	public int getTotalNumberStones() {
		return numStones;
	}

	public int getCollidedNumberStones() {
		return collidedStones;
	}

	public int getTotalNumberTrees() {
		return numTrees;
	}

	public int getCollidedNumberTrees() {
		return collidedTrees;
	}

}
