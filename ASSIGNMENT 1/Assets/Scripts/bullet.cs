using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public GameObject smallExplosion;
    public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
        GameManager.FireProjectile.Play();
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
                // if player1Lives = 0 then do the flagend
                // if player1Lives > 0 then set player1Lives down one and reinstatiate at the same position
                
                if (GameManager.player1Lives == 0)
                {
                    GameManager.flagDestroyed();
                } else
                {
                    Instantiate(playerPrefab, gameObject.transform.position, Quaternion.identity);
                    GameManager.player1Lives--;
                }
                
            
            
            
            }
            //if other.gameobject is an enemy then add points
            if (other.gameObject.CompareTag("Enemy"))
            {

            }
        }
    }
}
