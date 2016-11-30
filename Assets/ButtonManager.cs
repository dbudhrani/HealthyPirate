using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ButtonManager : MonoBehaviour {

    public Button returnButton;

    // Use this for initialization
    void Start () {

        Button btn = returnButton.GetComponent<Button>();
        btn.onClick.AddListener(returnToMenu);
    }

    private void returnToMenu()
    {
        Application.LoadLevel(0);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
