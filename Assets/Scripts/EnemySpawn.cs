using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	// get the object
	public GameObject enemyPrefab;

    // preferred width and height of the formation of enemies
	float height = 5f;
	float width = 8f;
	// leave speed to the inspector for now.
	public float speed;
    // so it keeps them from spawning a bit, there is a delay.
    public float spawnDelay = 0.5f;


	// start is spawning,
	void Start () {

        foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
		
	}
    // just to show the inspector where the width and height of the formation is.
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

	// update is the movement.
	void Update () {

		transform.Translate (Vector3.right * speed * Time.deltaTime);
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 mostLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 mostRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        
        if (transform.position.x >= mostRight.x - width/2 || transform.position.x <= width/2 + mostLeft.x)
        {
            speed = -speed;
        }

        // how to respawn, first call function... >> go to said function >>
        if (AllDead())
        {
            SpawnAgain();
        }
        //	speed = -speed;

    }

    // just checking if everyone if dead yet.
    bool AllDead()
    {
        foreach(Transform childpositionGameObject in transform)
        {
            if(childpositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    //this spawns them in the next available spot, or so it seems, it just follows the order of positions in the inspector.
    Transform NextFreePosition()
    {
        foreach(Transform childpositionGameObject in transform)
        {
            if(childpositionGameObject.childCount == 0)
            {
                return childpositionGameObject;
            }
        }
        return null;
    }

    // Respawn!  >nailed it<
    void SpawnAgain ()
    {
        Transform freePosition = NextFreePosition();// one function up
        if(freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("SpawnAgain", spawnDelay);
        }
    }



}