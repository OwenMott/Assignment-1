using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == null )
        {return;   }

        if (other.CompareTag("Player"))
        {
            //Debug.Log("Hit!");

        }
        else {
            Debug.Log("gottem lol");
        }
    }
}
