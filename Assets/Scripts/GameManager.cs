using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text time;

    public Text winner;

    bool P1W = Player.P1Winning;

    private int sceneID;

     void Start() {
         sceneID = SceneManager.GetActiveScene().buildIndex;
    }

    

    // Update is called once per frame
    void Update () {
        if (sceneID == 3) {
            getTime();
        } else if (sceneID == 4) {
            getWinner();
        }
        
        
    }

    public void changeToScene(int changeTheScene) {
        SceneManager.LoadScene(changeTheScene);
    }

    public void getTime() {
        time.text = (PlayerCoop.time).ToString("f2");
    }

    public void getWinner() {
        if (P1W) {
            winner.text = "P1";
        } else {
            winner.text = "P2";
        }
    }
    
}
