using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    // just the basic scoreholding script, get text component and put in the text.

    public Text score;
    public static float points;
    public static float Endscore;

	// Use this for initialization
	void Start () {
        score = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + points;
        
        
	}
}
