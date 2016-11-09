using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    public Text countText;
    public Text winText;
    private int count;

    // Use this for initialization
    void Start ()
    {
        Player = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        void OnTriggerEnter(Collider other)
{
            if (other.gameObject.CompareTag("Pick Up"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();

            }


        }
        void SetCountText ()
{
            count Text.text = "count: " + count.ToString();
            if (count >= 10)
                winText.text = "You Win !";
        }
    }
}