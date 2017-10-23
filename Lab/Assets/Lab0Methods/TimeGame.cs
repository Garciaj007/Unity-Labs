using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGame : MonoBehaviour {

    float roundStartDelayTime = 3f;

    float roundStartTime;
    int waitTime;
    bool roundStarted;

	// Use this for initialization
	void Start () {
        print("Press spacebacr once you think the alloted time is up.");
        Invoke("SetNewRandomTime", roundStartDelayTime);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && roundStarted)
            InputRecieved();
	}

    void InputRecieved()
    {
        roundStarted = false;
        float playerWaitTime = Time.time - roundStartTime;
        float error = Mathf.Abs(waitTime - playerWaitTime);

        print("You waited for " + playerWaitTime + " seconds. That's " + CheckError(error));
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }

    string CheckError(float error)
    {

        string message;

        if(error < 0.5)
        {
            message = "Amazing";
        }else if(error < 1)
        {
            message = "Great";
        }else if(error < 1.5)
        {
            message = "Average";
        }
        else
        {
            message = "Try again";
        }

        return message;
    }

    void SetNewRandomTime()
    {
        waitTime = Random.Range(5, 21);
        roundStartTime = Time.time;
        roundStarted = true;

        print(waitTime + " Seconds.");
    }
}
