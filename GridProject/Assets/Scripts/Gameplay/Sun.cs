using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    // Use this for initialization
    public void EndTurn ()
    {
        StopAllCoroutines ();
        StartCoroutine (MoveSun ());
    }

    public void SetTimeOfDay (int hour)
    {
        //print(Mathf.LerpAngle(-105.0f,-90.0f,val));
    }
    IEnumerator MoveSun ()
    {
        WaitForSeconds delay = new WaitForSeconds (1 / 60f);
        Vector3 rot = new Vector3 (1.0f, 0.0f, 0.0f);
        for (int i = 0; i < 15; i++)
        {
            yield return delay;
            transform.Rotate (rot, Space.World);
        }
    }
}