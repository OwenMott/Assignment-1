using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuManager : MonoBehaviour {


    public GameObject player;
    public GameObject menu;
    public GameObject pointer;
    public GameObject playerNumber;
    public GameObject[] pointerPostions;
    public GameObject[] levels;
     


    Text actualNum;

   

    bool onButton;

    // Use this for initialization
    void Start () {
        onButton = false;
        actualNum = playerNumber.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        // if button press down, move pointer
        // move character
        
        // if button press up, move pointer
        // flip the boolean onButton
       if (Input.GetKeyDown("s") || Input.GetKeyDown("down") || Input.GetKeyDown("w") || Input.GetKeyDown("up"))
       {

            if (onButton == false)
            {
                onButton = true;
            }  else 
            {
                onButton = false;
            }
            
        }


        if (onButton == false)
        {
            pointer.transform.position = pointerPostions[0].transform.position;
        }
        else
        {
            pointer.transform.position = pointerPostions[1].transform.position;
        }


        //if return is pressed and onButton equals true
        //then start the game

        if (Input.GetKeyDown("return") && onButton == true)
        {
            //player.SetActive(true);
            //Instantiate();
            menu.SetActive(false);
            levels[0].SetActive(true);

        }
        //if return is pressed and onButton equals false
        //then change number of players

        if(Input.GetKeyDown("return") && onButton == false)
        {
            if (actualNum.text == "1")
            {
                actualNum.text = "2";
            }
            else {
                actualNum.text = "1";
            }
        }

        //if position top set onButton to false
        //if position bottom set onButton to true

        //if (Input.GetKey("return"))
        //{
        //    player.SetActive(true);
        //    menu.SetActive(false);
        //}

    }
}
