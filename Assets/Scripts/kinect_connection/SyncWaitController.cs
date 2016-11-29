using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SyncWaitController : MonoBehaviour {


	// Use this for initialization
	void Start () {
        GetComponent<Text>().enabled = true;

    }

    public void setVisibility(bool val)
    {
        GetComponent<Text>().enabled = val;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
