using UnityEngine;
using System.Collections;
using System;

public class MainScript : MonoBehaviour {

    public int level; // level 1 = upper-body; level 2 = lower-body; level 3 = full body

    public Rigidbody fish;
    public Rigidbody stone;
    public Rigidbody tree;

    public Rigidbody LowerIntro;

    public bool hasGameStarted;

    private StoneGeneration sgScript;
    private TreeGeneration tgScript;

    private int numFishes;
    private int numStones;
    private int numTrees;

    private int capturedFishes;
    private int collidedStones;
    private int collidedTrees;

    private int gameLevel;

    public float lifetime;

    //Timer
    private myTimer timerScript;
    public GameObject textTimerObject;

    //InfoText
    private SyncWaitController infoTextScript;
    public GameObject infoTextObject;

    //Kinect 
    private DetectJoints kinectScript;
    public GameObject boatControllerJump;
    public GameObject boatControllerSide;

    //PresicionGreenLine
    public GameObject greenLine;
    PresicionGreenController greenScript;

    // Use this for initialization
    void Start() {

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

        //set dynamically timer script
        timerScript = textTimerObject.GetComponent<myTimer>();

        //set dynamically info script
        infoTextScript = infoTextObject.GetComponent<SyncWaitController>();

        //set kinect script
        if(level == 1)
        {
            kinectScript = boatControllerSide.GetComponent<DetectJoints>();
        }

        if(level == 2)
        {
            kinectScript = boatControllerJump.GetComponent<DetectJoints>();
        }

        //set green line
        greenScript = greenLine.GetComponent<PresicionGreenController>();


        hasGameStarted = true;
    }

    private void startGame()
    {
        switch (level)
        {
            case 1:
                sgScript.enabled = true;
                //Destroy(tree.gameObject);
                //Debug.Log("intro" + LowerIntro);
                //Destroy(LowerIntro.gameObject, lifetime);
                greenScript.setHasGameStarted(true);
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
        
        if (kinectScript.isBodyTracked && hasGameStarted)
        {
            startGame();
            timerScript.setIsGameStart(true);
            infoTextScript.setVisibility(false);

            
            //start the game only once
            hasGameStarted = false;
            
        }
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
