using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notGoingIn : MonoBehaviour
{

    public GameObject enemy1;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 8; i++)
        {
            Instantiate(enemy1, new Vector3(i-5, 0, 0), Quaternion.identity);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
