using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameStatusText : MonoBehaviour {
    private int score = 0;
    private int state;

	void Start () {
        Text();
	}
	
	void Update () {
		
	}

    void Text() {
        if (gameObject.name.Contains("Score"))
            state = 0;
        else
            state = 1;
    }

    void OnEnable() {
        GameEventManager.myGameScoreAction += gameScore;
        GameEventManager.myGameOverAction += gameOver;
    }

    void OnDisable() {
        GameEventManager.myGameScoreAction -= gameScore;
        GameEventManager.myGameOverAction -= gameOver;
    }

    void gameScore() {
        if (state == 0) {
            score++;
            this.gameObject.GetComponent<Text>().text = "Score: " + score;
        }
    } 

    void gameOver() {
        if (state == 1)
            this.gameObject.GetComponent<Text>().text = "Game Over!";
    }
}
