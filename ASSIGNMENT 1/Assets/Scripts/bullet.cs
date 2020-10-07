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
            return;   
        }

        if (other.CompareTag(gameObject.tag))
        {
            //Debug.Log("Hitself");

        }
        else if (other.CompareTag("Unbreakable"))
        {
            Debug.Log("hit unbreakable");
            Destroy(gameObject);

        } 
        else
        {
            //Debug.Log("gottem lol");
            Destroy(gameObject);
            Instantiate(smallExplosion, gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

            //if other.gameobject is player end game
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.flagDestroyed();
            }
            //if other.gameobject is an enemy then add points
            if (other.gameObject.CompareTag("Enemy"))
            {

            }
        }
    }
}
