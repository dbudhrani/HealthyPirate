using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class myTimer : MonoBehaviour {

    public float playerTimer = 99;
    public Text timerText;

	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        playerTimer -= Time.deltaTime;
        timerText.text = playerTimer.ToString("f0");
        print(playerTimer);
	}
}
