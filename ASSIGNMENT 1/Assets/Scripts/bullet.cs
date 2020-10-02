using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public GameObject smallExplosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == null )
        {
            Destroy(gameObject);
            return;   }

        if (other.CompareTag(gameObject.tag ))
        {
            //Debug.Log("Hitself");

        }
        else {
            //Debug.Log("gottem lol");
            Destroy(gameObject);
            Instantiate(smallExplosion, gameObject.transform.position, Quaternion.identity);
        }
    }
}
