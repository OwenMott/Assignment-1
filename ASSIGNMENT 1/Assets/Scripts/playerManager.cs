using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

    public GameObject bulletPrefab;

    Rigidbody2D rb2d;
    Animator anim;
    SpriteRenderer sprite;
    int facing;
    bool canShoot = true;

    DateTime timeSinceShot;
    TimeSpan shootCooldown;

    // Use this for initialization
    void Start () {
        Debug.Log("its working");
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        shootCooldown = TimeSpan.FromMilliseconds(3000);
        timeSinceShot = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update () {
       

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb2d.velocity = new Vector2(0, 1);
            anim.Play("PlayerMove");
            sprite.flipY = false;
            facing = 1;
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb2d.velocity = new Vector2(0, -1);
            anim.Play("PlayerMove");
            sprite.flipY = true;
            facing = 2;
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(1, 0);
            anim.Play("PlayerMoveLR");
            sprite.flipX = false;
            facing = 3;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-1, 0);
            anim.Play("PlayerMoveLR");
            sprite.flipX = true;
            facing = 4;
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);

            anim.Play("");

        }


        //spacebar pressed, bullet schut
        if (Input.GetKeyDown("space") && canShoot == true)
        {
            GameObject thisBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRB2D = thisBullet.GetComponent<Rigidbody2D>();
            canShoot = false;
            timeSinceShot = DateTime.Now;
            switch (facing)
            {
                case 1:
                    bulletRB2D.velocity = new Vector2(0, 10);
                    break;

                case 2:
                    bulletRB2D.velocity = new Vector2(0, -10);
                    bulletRB2D.rotation = 180;
                    break;
                case 3:
                    bulletRB2D.velocity = new Vector2(10, 0);
                    bulletRB2D.rotation = 270;
                    break;
                case 4:
                    bulletRB2D.velocity = new Vector2(-10, 0);
                    bulletRB2D.rotation = 90;
                    break;
                default:
                    bulletRB2D.velocity = new Vector2(0, 10);
                    break;
                    
            }

            //wait an amount of time then set canShoot back to true
           

            //if (facing == "up")
            //{
            //    bulletRB2D.velocity = new Vector2(0, 10);
            //} 
            //else if (facing == "down") 
            //{
            //    bulletRB2D.velocity = new Vector2(0, -10);
            //    bulletRB2D.rotation = 180;
            //}
            //else if (facing == "right")
            //{
            //    bulletRB2D.velocity = new Vector2(10, 0);
            //    bulletRB2D.rotation = 270;
            //}
            //else if (facing == "left")
            //{
            //    bulletRB2D.velocity = new Vector2(-10, 0);
            //    bulletRB2D.rotation = 90;
            //}


        }

        if (DateTime.Now > timeSinceShot + shootCooldown) //&& canShoot == false
        {

            canShoot = true;

            //play a ding noise

            //Debug.Log(DateTime.Now);
            //Debug.Log(timeSinceShot + shootCooldown);

        }
        else
        {
            //Debug.Log(DateTime.Now);
            //Debug.Log(timeSinceShot + shootCooldown);
        }

    }

}
