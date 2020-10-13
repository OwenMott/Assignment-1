using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class notGoingIn : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject[] spawnGameObjects;
    public GameObject spawnSmoke;

    int theRange;
 
    // Start is called before the first frame update
    void Start()
    {
      


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void spawnStart(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            
            
            makeEnemy(enemy1);
            await System.Threading.Tasks.Task.Delay(5000);
        }
    }
    
    public async void makeEnemy(GameObject enemyType) 
    {
        //make a spawning sprite
        if (enemyType == null)
        {
            return;
        }else
        {
            theRange = Random.Range(0, 3);
            Instantiate(spawnSmoke, spawnGameObjects[theRange].transform.position, Quaternion.identity);
            await System.Threading.Tasks.Task.Delay(1000);
            Instantiate(enemyType, spawnGameObjects[theRange].transform.position, Quaternion.identity);
        }
        
    }
}
