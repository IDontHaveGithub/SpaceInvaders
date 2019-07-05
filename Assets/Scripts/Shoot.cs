using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    // the script of the projectiles, called shoot with this one, as I had to do it without internet.
    public float schade = 100f;
    public float GetDamage()
    {
        return schade;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

	void Update () {
		Destroy(gameObject, 4);
	}
}
