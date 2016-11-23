using UnityEngine;
using System.Collections;

public class PresicionController : MonoBehaviour {

    //Connecting boat controller script in order to get the position
    public GameObject boatController;
    public DetectJoints boatScript;


    // Use this for initialization
    public Vector3 presicionLinePos;

    public float redLineWidth;

    //Presicion bar vars
    private float barWidth = 743f;
    private float scaled = 0.5f;
    private float barRange;

    

    private float boatRange = 1f;

    private float barFrom;
    private float barTo;

    private float boatFrom;
    private float boatTo;


    void Start () {
        //gameObject.GetComponent<RectTransform>().position = new Vector3(10, 0, 0);​
        presicionLinePos = gameObject.GetComponent<RectTransform>().anchoredPosition;

        //init boatScript
        boatScript = boatController.GetComponent<DetectJoints>();

        //init scales, used for calculating the position of the red line
        barRange = barWidth * scaled;

        
        barFrom = 0 - barRange / 2;
        barTo = barRange / 2;

        boatFrom = 0 - boatRange;
        boatTo = boatRange;

        redLineWidth = 29 * scaled;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(presicionLinePos);
        //Debug.Log(boatScript.objectPosition.z);
        //presicionLinePos.x = presicionLinePos.x + boatScript.objectPosition.z;
        float value = boatScript.objectPosition.z;
        presicionLinePos.x = -remap(value, boatFrom, boatTo, barFrom, barTo);
        //Debug.Log(remap(value, boatFrom, boatTo, barFrom, barTo));
        gameObject.GetComponent<RectTransform>().anchoredPosition = presicionLinePos;

    }

    //maps from one range to another
     float remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
