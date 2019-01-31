using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCoop : MonoBehaviour {

    public Text timerText;

    public static float t;

    string minutes,seconds;

    public GameObject player;


    private float startTime;


    // Use this for initialization
    void Start () {
        startTime = Time.time;
 
    }
	
	// Update is called once per frame
	void Update () {
         t = Time.time - startTime;

         minutes = ((int)t / 60).ToString();
         seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
        

    }

}
