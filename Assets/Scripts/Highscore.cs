using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    // This script is going to show the scores gotten locally, because making an entire database for just a simple game is too hard. ;p
    // it doesn't work tho, so I guess I'll just disable the button going to the ScoreScene.
    public Text Highscores;
    public float[] scores;
    public float endscore;

	void Start () {
       
        endscore = Score.points;
        scores[1] = endscore;
	}
	
	// Update is called once per frame
	void Update () {
        Highscores.text = "" + scores;
	}
}
