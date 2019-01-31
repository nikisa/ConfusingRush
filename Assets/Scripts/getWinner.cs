using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getWinner : MonoBehaviour {

    public Text winner;

    bool P1W = Player.P1Winning;

    public void Update() {
        if (P1W) {
            winner.text = "P1";
        } else {
            winner.text = "P2";
        }

    }
}

   
