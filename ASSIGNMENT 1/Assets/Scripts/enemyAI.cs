using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{

    bool canFire = true;
    bool canMove = true;
    int chanceToFire = 20;
    int chanceToMove = 20;
    int randomNumber;
    int moveRandomNumber;
    int moveChanceRandomNumber;

    public GameObject bulletPrefab;
    Rigidbody2D rb2d;
    Animator anim;
    SpriteRenderer sprite;
    int facing;

    DateTime timeSinceLastDecision = DateTime.Now;
    TimeSpan aiCooldown;

    // Start is called before the first frame update
    void Start()
    {
        aiCooldown = TimeSpan.FromMilliseconds(UnityEngine.Random.Range(800, 2000));
        Debug.Log(aiCooldown);
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        randomNumber = UnityEngine.Random.Range(0, 100);
        moveRandomNumber = UnityEngine.Random.Range(1, 6);
        moveChanceRandomNumber = UnityEngine.Random.Range(0, 100);
        //Debug.Log(moveRandomNumber);
        if (moveChanceRandomNumber < chanceToMove)
        {
            if (canMove)
            {
                canMove = false;
                if (moveRandomNumber == 1)
                {
                    rb2d.velocity = new Vector2(0, 1);
                    anim.Play("Enemy1");
                    sprite.flipY = false;
                    facing = 1;
                }
                else if (moveRandomNumber == 2)
                {
                    rb2d.velocity = new Vector2(0, -1);
                    anim.Play("Enemy1");
                    sprite.flipY = true;
                    facing = 2;
                }
                else if (moveRandomNumber == 3)
                {
                    rb2d.velocity = new Vector2(1, 0);
                    anim.Play("Enemy1-2");
                    sprite.flipX = false;
                    facing = 3;
                }
                else if (moveRandomNumber == 4)
                {
                    rb2d.velocity = new Vector2(-1, 0);
                    anim.Play("Enemy1-2");
                    sprite.flipX = true;
                    facing = 4;
                }
                else if(moveRandomNumber == 5)
                {
                    rb2d.velocity = new Vector2(0, 0);

                    anim.Play("");

                }
            }

        }

        if (DateTime.Now > timeSinceLastDecision + aiCooldown)
        {
            timeSinceLastDecision = DateTime.Now;
            canFire = true;
            canMove = true;
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
                    bulletRB2D.rotation = rb2d.rotation + 180;
                    break;
                case 3:
                    bulletRB2D.velocity = new Vector2(10, 0);
                    bulletRB2D.rotation = rb2d.rotation + 270;
                    break;
                case 4:
                    bulletRB2D.velocity = new Vector2(-10, 0);
                    bulletRB2D.rotation = rb2d.rotation + 90;
                    break;
                default:
                    bulletRB2D.velocity = new Vector2(0, 10);
                    break;

            }
        }

}
