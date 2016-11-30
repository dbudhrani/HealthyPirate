using UnityEngine;
using System.Collections;
using Windows.Kinect;
using System;

public class DetectJoints : MonoBehaviour {

    public bool isBodyTracked;

	public GameObject BodySrcManager;

	public JointType TrackedJoint; //enum for tracking

    public Vector3 objectPosition;

    public Vector3 jumpPosition;

	private BodySourceManager bodyManager;

    public bool detectSides = false;
    public bool detectJump = false;

    private int levelSelected;

	private Body[] bodies; //array of people

	public float multiplier = 10f;

    //jump params
    public float jumpMultiplier = 5f;

    private float jumpMin = 0.3f; //use this for calibration of the jump

    private float newValJump = 0;

    public GameObject boatHelper;
    private BoatPositionHelper boatHelperScript;

    void Start () {

        if (PlayerPrefs.GetInt("levelSelected") == 0)
        {
            levelSelected = 1;
           
        }
        else {
            levelSelected = PlayerPrefs.GetInt("levelSelected");
        }



        if (BodySrcManager == null) {
			Debug.Log ("Assign tame object with body source manager");
		} else {
			bodyManager = BodySrcManager.GetComponent<BodySourceManager> ();
		}

        boatHelperScript =  boatHelper.GetComponent<BoatPositionHelper>();
	}
	
	// Update is called once per frame
	void Update () {
		if (bodyManager == null) {
			return;
		}

		bodies = bodyManager.GetData();

		if (bodies == null) {
			return;
		}

		foreach (var body in bodies) {
			if (body == null) {
				continue;
			}

			if (body.IsTracked) {

                bodyIsTracked();

                if (levelSelected == 1 && detectSides) {
                  
                    var pos = body.Joints[TrackedJoint].Position;
                    //upper body is selected
                    Vector3 newPos = new Vector3(0, 0, -pos.X * multiplier);
                    gameObject.transform.position = newPos;
                    objectPosition = newPos;
                }

                //jump mode
                if(levelSelected == 2 && detectJump)
                {
                    var pos = body.Joints[TrackedJoint].Position;
                    //Debug.Log(-pos.Y);

                    if (-pos.Y < jumpMin)
                    {
                        newValJump = 3f;
                    }
                    else {
                        newValJump = 0f;
                    }
                        
                    Vector3 newPos = new Vector3(0, newValJump, 0);
                    gameObject.transform.position = newPos;
                }

                if(levelSelected == 3)
                {

                    float newValJump  = 0;

                    if (detectJump)
                    {
                        var pos = body.Joints[TrackedJoint].Position;
                        //Debug.Log(-pos.Y);
                        

                        if (-pos.Y < jumpMin)
                        {
                            newValJump = 3f;
                        }
                        else
                        {
                            newValJump = 0f;
                        }

                        boatHelperScript.boatPosition.y = newValJump;
                        
                    }

                    if (detectSides)
                    {
                        var pos = body.Joints[TrackedJoint].Position;
                        //upper body is selected
                        boatHelperScript.boatPosition.z = -pos.X * multiplier;
                        
                    }

                    gameObject.transform.position = boatHelperScript.boatPosition;
                    
                }


               }     
        }
	}

    private void bodyIsTracked()
    {
        isBodyTracked = true;
    }
}
