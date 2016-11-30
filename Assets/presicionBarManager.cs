using UnityEngine;
using System.Collections;

public class presicionBarManager : MonoBehaviour {

    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    // Use this for initialization
    void Start () {
	    if(PlayerPrefs.GetInt("levelSelected") == 2)
        {
            o1.SetActive(false);
            o2.SetActive(false);
            o3.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
