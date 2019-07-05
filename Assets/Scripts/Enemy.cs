using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	
	public GameObject enemy;
	
    public GameObject laser;
    public float laserspeed;
    public float SPS = 0.5f;

    public float HP = 150f;
    public float points = 25;
	

	void Update () {
        // mogelijkheid is de hoeveelheid keren die een enemy kn schieten in een seconde.
        float mogelijkheid = Time.deltaTime * SPS;
        // de random value is to keep the enemy from always shooting in unison and to keep the surprise in it a little
        if(Random.value < mogelijkheid)
        {
            Fire();
        }
	}
	
    // initiate the taking damage ;p
	void OnTriggerEnter2D (Collider2D col) {
        Shoot missile = col.GetComponent<Shoot>();
        if (missile)
        {
            HP -= missile.GetDamage();
            if (HP <= 0)
            {
                Destroy(gameObject);
                Score.points += points;
            }
            missile.Hit();
        }
	}

    // initiate the shooting
    void Fire()
    {
        
        GameObject beam = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserspeed);
    }
}
