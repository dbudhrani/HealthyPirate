using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

    public float Seconds = 59;
    public float Minutes = 0;

    void Update()
    {
        if (Seconds <= 0) 
        {
            Seconds = 59;
            if (Minutes >= 1) 
            {
                Minutes--;
            }
            else
            {
                Minutes = 0;
                Seconds = 0;
            }
        }
        else
        {
            Seconds = Time.deltaTime;
        }
      }

}





