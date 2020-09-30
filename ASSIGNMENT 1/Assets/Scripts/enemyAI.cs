using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{

    bool canFire = true;
    int chanceToFire = 5;
    int randomNumber;

    public GameObject bulletPrefab;
    Rigidbody2D rb2d;
    Animator anim;
    SpriteRenderer sprite;
    int facing;

    DateTime timeSinceLastDecision = DateTime.Now;
    TimeSpan aiCooldown = TimeSpan.FromSeconds(1);

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        randomNumber = UnityEngine.Random.Range(0, 100);

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb2d.velocity = new Vector2(0, 2);
            anim.Play("PlayerMove");
            sprite.flipY = false;
            facing = 1;
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb2d.velocity = new Vector2(0, -2);
            anim.Play("PlayerMove");
            sprite.flipY = true;
            facing = 2;
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(2, 0);
            anim.Play("PlayerMoveLR");
            sprite.flipX = false;
            facing = 3;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-2, 0);
            anim.Play("PlayerMoveLR");
            sprite.flipX = true;
            facing = 4;
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);

            anim.Play("");

        }

        if (DateTime.Now > timeSinceLastDecision + aiCooldown)
        {
            timeSinceLastDecision = DateTime.Now;
        }
        else
        {
            return;
        }
        //chance to fire
        if (randomNumber < chanceToFire)
        {

            if (canFire)
            {
                enemyFire();
            }

        }
    }
        //chance to move


        //function that fires for the enemy
        private void enemyFire()
        {
            canFire = false;
            //instantiate projectile
            GameObject thisBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRB2D = thisBullet.GetComponent<Rigidbody2D>();

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
        }

}
