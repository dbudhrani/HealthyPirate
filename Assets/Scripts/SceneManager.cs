using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {
    //Starts the scenes

    public Button startButton;

    public Button upperButton;
    public Button downButton;
    public Button wholeButton;

    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(StartOnClick);

        Button upperbtn = upperButton.GetComponent<Button>();
        upperbtn.onClick.AddListener(setUpPart);

        Button downbtn = downButton.GetComponent<Button>();
        downbtn.onClick.AddListener(setDownPart);

        Button wholebtn = wholeButton.GetComponent<Button>();
        wholebtn.onClick.AddListener(setWholePart);
    }

    void StartOnClick()
    {
        Application.LoadLevel(1);
    }

    void setUpPart() {
        PlayerPrefs.SetInt("levelSelected",1);
    }

    void setDownPart(){
        PlayerPrefs.SetInt("levelSelected", 2);
    }

    void setWholePart()
    {
        PlayerPrefs.SetInt("levelSelected", 3);
    }

}
