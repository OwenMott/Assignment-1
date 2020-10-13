using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class powerUpManager : MonoBehaviour
{
    public powerUpType thisPowerUp = powerUpType.grenade;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.gameObject == null)
        {
            return;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            

            switch (thisPowerUp)
            {
                case powerUpType.grenade:
                    GameObject[] spawnedEnemies = GameObject.FindGameObjectsWithTag("Enemy");

                    if (spawnedEnemies.Length > 0)
                    {
                        for (int i = 0; i < spawnedEnemies.Length; i++)
                        {
                            Destroy(spawnedEnemies[i]);
                        }
                    }
                    break;

                case powerUpType.extraLife:
                    GameManager.player1Lives++;
                        break;
            }
            Destroy(gameObject);
        }

    }

    public enum powerUpType
    {
        grenade = 0,
        extraLife
        //other ideas (extra life, clock, rapidfire, speedup)
    }
}
