using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text fishNumber;
    public Text rockNumber;
    public Text presNumber;
    public Text treeNumber;


    // Use this for initialization
    void Start () {
        //fishNumber = GetComponent<Text>();
        //rockNumber = GetComponent<Text>();
        if(rockNumber != null)
        {
            rockNumber.text = PlayerPrefs.GetInt("avoidedStones").ToString();
        }

        if(treeNumber != null)
        {
            treeNumber.text = PlayerPrefs.GetInt("avoidedTrees").ToString();
        }

        if(presNumber != null)
        {
           // presNumber.text = (PlayerPrefs.GetFloat("presicion")*100).ToString() + "%";
        }
        fishNumber.text = PlayerPrefs.GetInt("capturedFish").ToString();
        
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
