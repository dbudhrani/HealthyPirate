using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class myTimer : MonoBehaviour {

    public float playerTimer = 99;
    public Text timerText;
    public bool isGameStart;

	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
        isGameStart = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isGameStart)
        {
            playerTimer -= Time.deltaTime;
            timerText.text = playerTimer.ToString("f0");
            //print(playerTimer);
            
        }
    }

    public float getPlayerTime()
    {
        return playerTimer;
    }
    public void setIsGameStart(bool val)
    {
        isGameStart = val;
    }
}
