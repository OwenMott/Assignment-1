using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class notGoingIn : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject[] spawnGameObjects;

 
    // Start is called before the first frame update
    void Start()
    {
      


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnStart()
    {
        for (int i = 0; i < 3; i++)
        {
            makeEnemy(enemy1);
        }
    }
    
    public void makeEnemy(GameObject enemyType) 
    {
        Instantiate(enemyType, spawnGameObjects[Random.Range(0, 3)].transform.position, Quaternion.identity);
    }
}
