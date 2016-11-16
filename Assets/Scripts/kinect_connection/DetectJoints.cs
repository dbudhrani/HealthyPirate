using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour {

	public GameObject BodySrcManager;

	public JointType TrackedJoint; //enum for tracking

    public Vector3 objectPosition;

	private BodySourceManager bodyManager;

	private Body[] bodies; //array of people

	public float multiplier = 10f;

	void Start () {
		if (BodySrcManager == null) {
			Debug.Log ("Assign tame object with body source manager");
		} else {
			bodyManager = BodySrcManager.GetComponent<BodySourceManager> ();
		}
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
				var pos = body.Joints [TrackedJoint].Position;

                Vector3 newPos = new Vector3(0, 0, -pos.X * multiplier);
                gameObject.transform.position = newPos;
                objectPosition = newPos;
                
            }
		}

	}
}
