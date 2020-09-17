using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

    Rigidbody2D rb2d;
    Animator anim;
    SpriteRenderer sprite;


	// Use this for initialization
	void Start () {
        Debug.Log("its working");
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
       

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb2d.velocity = new Vector2(0, 2);
            anim.Play("PlayerMove");
            sprite.flipY = false;
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb2d.velocity = new Vector2(0, -2);
            anim.Play("PlayerMove");
            sprite.flipY = true;
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(2, 0);
            anim.Play("PlayerMoveLR");
            sprite.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-2, 0);
            anim.Play("PlayerMoveLR");
            sprite.flipX = true;
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);

            anim.Play("");

        }

    }

}
