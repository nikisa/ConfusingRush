using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getTime : MonoBehaviour {

    public Text time;

    public void Update() {
        time.text = (PlayerCoop.time).ToString("f2");
    }
    
}
