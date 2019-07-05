using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAnim : MonoBehaviour {

    //this script was just for fun, I found a fireball sprite with multiple frames, 
    // so I just used an older anim-script we used in a earlier game.
	public float FPS;
	private int sprite;
	public Sprite[] fireball;
	private float time;
	

	// Use this for initialization
	void Start () {
		time = 1 / FPS;
		StartCoroutine (AnimatieRoutine ());
		GetComponent<SpriteRenderer> ().sprite = fireball[sprite];
	}

	IEnumerator AnimatieRoutine () {

		if (sprite >= fireball.Length) {
			sprite = 0;
		}

		yield return new WaitForSeconds (time);

		GetComponent<SpriteRenderer> ().sprite = fireball[sprite];
		sprite++;

		StartCoroutine (AnimatieRoutine ());

	}
}