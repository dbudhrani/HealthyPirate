using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public int fishValue;
    public Text scoreText;
    private MainScript ms;


	// Use this for initialization
	void Start () {
        fishValue = 0;
        ms = GameObject.Find("Brain").GetComponent<MainScript>();
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = ms.getCapturedNumberFishes().ToString();
    

    }

   /* void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "cruscarp(Clone)")
        {
            fishValue = fishValue = 1;
        }
    }*/
}
