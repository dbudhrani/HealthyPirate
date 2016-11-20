using UnityEngine;
using System.Collections;
using System;

public class MainScript : MonoBehaviour {

	public int level; // level 1 = upper-body; level 2 = lower-body; level 3 = full body

	public Rigidbody fish;
	public Rigidbody stone;
	public Rigidbody tree;

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

        setLevel();
		Debug.Log("Level = " + level);

		numFishes = 0;
		numStones = 0;
		numTrees = 0;

		capturedFishes = 0;
		collidedStones = 0;
		collidedTrees = 0;

		sgScript = GetComponent<StoneGeneration>();
		tgScript = GetComponent<TreeGeneration>();

		switch (level) {
			case 1:
				sgScript.enabled = true;
				Destroy(tree.gameObject);
				break;
			case 2:
				tgScript.enabled = true;
				Destroy(stone.gameObject);
				break;
			case 3:
				sgScript.enabled = true;
				tgScript.enabled = true;
				tgScript.setIncludeCognitiveChallenge(false);
				break;
			case 4:
				sgScript.enabled = true;
				tgScript.enabled = true;
				tgScript.setIncludeCognitiveChallenge(true);
				break;
			default:
				Debug.Log("ERROR: level requested is " + level);
				break;
		}

	}

    private void setLevel()
    {
        level = PlayerPrefs.GetInt("levelSelected");
    }

    // Update is called once per frame
    void Update () {
	
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
