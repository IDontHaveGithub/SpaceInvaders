using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // moving right (not wrong) variables
    public float padding = 1f;
    float speed = 5;
    float move;
    float minx;
    float maxx;

    // shot variables
    public GameObject laser;
    public Transform firePoint;

    // HP and a variable called pointcap to give more HP per 1000.
    public float HP = 250f;
    public float pointcap = 1000f;

    
    void Start()
    {
        //This is so the player can't leave the screen.
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 mostLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 mostRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minx = mostLeft.x + padding;
        maxx = mostRight.x - padding;
    }

    
    void Update()
    {
        // print(HP); // just to check if it's working correctly
        // to move
        move = Mathf.Clamp((move += (Input.GetAxis("Horizontal") * Time.deltaTime * speed)), minx, maxx);
        transform.position = new Vector2(move, transform.position.y);

        // to shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, 0.5f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
        // to survive, I thought it would be fun to give the player a reward for surviving, so more health for more tortu- fun!
        if (Score.points == pointcap)
        {
            HP += 105f;
            pointcap += 1000f;
        }
    }

    // function to shoot projectiles.
    void Fire()
    {
        Vector3 startPositie = transform.position + new Vector3(0, 1.2f, 0);
        GameObject Straal = Instantiate(laser, startPositie, Quaternion.identity) as GameObject;
        Straal.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 6, 0);

    }

    // function to hit the player.
    void OnTriggerEnter2D(Collider2D col)
    {
        Shoot missile = col.GetComponent<Shoot>();
        if (missile)
        {
            HP -= missile.GetDamage();
            if (HP <= 0)
            {
                Destroy(gameObject);
                Die();
            }
            missile.Hit();
        }
    }

    public static void Die()
    {
        
        LevelManager.LoadNextLevel();
    }
}