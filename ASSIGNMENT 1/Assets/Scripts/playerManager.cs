using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

    Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
        Debug.Log("its working");
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey("w"))
        {
            rb2d.velocity = new Vector2(0, 2);
        }
        else if (Input.GetKey("s"))
        {
            rb2d.velocity = new Vector2(0, -2);
        }
        else if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(2, 0);
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-2, 0);
        }

    }

}
