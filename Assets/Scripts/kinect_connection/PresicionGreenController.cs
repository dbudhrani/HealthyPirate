using UnityEngine;
using System;
using System.Collections;

public class PresicionGreenController : MonoBehaviour {

    public Vector3 presicionGreenPos;

    //Redline 
    public PresicionController redLineScript;
    public GameObject redLineObject;

    //StoneGenerator
    public StoneGeneration stoneGenScript;
    public GameObject brain;

    //Presicion bar vars
    private float barWidth = 718f; //718
    private float scaled = 0.5f;
    private float barRange;

    private float greenLineWidth = 95f;

    private float moveLimit;

    private Vector3 redLinePos;

    private Queue stoneQueue;
    private GameObject stoneDequeued;

    IEnumerator Start () {
        yield return new WaitForSeconds(6f);
        presicionGreenPos = gameObject.GetComponent<RectTransform>().anchoredPosition;

        //get the script from redline gameobject
        redLineScript = redLineObject.GetComponent<PresicionController>();

        //get the stone generation script from brain
        stoneGenScript = brain.GetComponent<StoneGeneration>();

        stoneQueue = stoneGenScript.stoneQueue;
      
        changeStone(); //get the first stone - init

        //init scales, used for calculating the position of the red line
        barRange = barWidth * scaled;
        greenLineWidth = greenLineWidth * scaled;

        moveLimit = (barRange / 2) - (greenLineWidth * scaled/2); //max limit of the position of the green line to one side

        //Debug.Log(moveLimit);

        //InvokeRepeating("changeGreenLinePos", 3.0f, 2.0f); //repeats the method every 2sec
    }
	
	// Update is called once per frame
	void Update () {
        
        //Debug.Log(stoneQueue.ToArray());
        //new stone had come close so the greenline needs to be refreshed according to new stone coming
        if (stoneDequeued.transform.position.x < 24f)
        {
            updateGreenLine(stoneDequeued.transform.position);
            changeStone();
        }

        redLinePos = redLineScript.presicionLinePos;

        if (isRedLineInGreen(redLinePos.x))
        {
            //TODO - add point that user had reached the greenline
        }
        
    }

    private void updateGreenLine(Vector3 stonePos)
    {
        float newPos = 0;
        if(stonePos.z < 0)
        {
            newPos = -Mathf.Floor(UnityEngine.Random.value * moveLimit);
        }
        else
        {
            newPos = Mathf.Floor(UnityEngine.Random.value * moveLimit);
        }
        float stoneMiddle = 0.9f;
        float leftStoneMiddle = stoneMiddle + 0.4f;
        float rightStoneMiddle = stoneMiddle - 0.4f;

        //if the stone is in the middle, the green line needs to be changed
        if (stonePos.z > leftStoneMiddle && stonePos.z < rightStoneMiddle) {
            if(UnityEngine.Random.value < 0.5f)
            {
                newPos = -90;
            }
            else
            {
                newPos = 90;
            }
        }

         
        presicionGreenPos.x = newPos;

        gameObject.GetComponent<RectTransform>().anchoredPosition = presicionGreenPos;
    }

    private bool isRedLineInGreen(float redLinePos)
    {
        //calcualte the relative range of green line posiiton
        float minRange = presicionGreenPos.x - greenLineWidth / 2;
        float maxRange = presicionGreenPos.x + greenLineWidth / 2;

        float redLineWidth =  redLineScript.redLineWidth;

        //need to get both left and right edge position cause redLinePos is just middle pos
        float redLineLeftEdge = redLinePos - (redLineWidth / 2);
        float redLineRightEdge = redLinePos + (redLineWidth / 2);

        if (minRange < redLineLeftEdge && redLineRightEdge < maxRange)
        {
            return true;
        }
        return false;

    }

    void changeGreenLinePos()
    {
        //finds a new position for gree line
        float newPos = Mathf.Floor(UnityEngine.Random.value * moveLimit) - Mathf.Floor(UnityEngine.Random.value * moveLimit);

        presicionGreenPos.x = newPos;
        Debug.Log(newPos);

        gameObject.GetComponent<RectTransform>().anchoredPosition = presicionGreenPos;
    }

    void changeStone()
    {
        stoneDequeued = (GameObject)stoneQueue.Dequeue();
        //Debug.Log(stoneDequeued);  
    }
}
