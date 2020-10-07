using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuManager : MonoBehaviour {


    public GameObject player;
    public GameObject playerPrefab;
    public GameObject player1Spawn;
    public GameObject menu;
    public GameObject pointer;
    public GameObject playerNumber;
    public GameObject[] pointerPostions;
    public GameObject[] levels;
    public GameObject playArea;
    public Camera mainCamera;
    public Camera playCamera;

    GameObject level1PreFab;
    notGoingIn notGoingInScript;

    Text actualNum;

    int levelNum;

    bool onButton;

    // Use this for initialization
    void Start () {
        onButton = false;
        actualNum = playerNumber.GetComponent<Text>();
        levelNum = 0;
        
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
            if (actualNum.text == "1")
            {
                
                Instantiate(playerPrefab, player1Spawn.transform.position, Quaternion.identity);
                menu.SetActive(false);
                Instantiate(levels[levelNum]);

                level1PreFab = GameObject.FindGameObjectWithTag("Level");
                notGoingInScript = level1PreFab.GetComponent<notGoingIn>();
                
                mainCamera.enabled = false;
                playCamera.enabled = true;

                playArea.SetActive(true);
                Debug.Log("playarea should be working");
                notGoingInScript.spawnStart();

                
            }
            else
            {
                Instantiate(playerPrefab, new Vector3(-1, -4.5f, 0), Quaternion.identity);
                Instantiate(playerPrefab, new Vector3(1, -4.5f, 0), Quaternion.identity);
                menu.SetActive(false);
                levels[0].SetActive(true);

                mainCamera.enabled = false;
                playCamera.enabled = true;
                playArea.SetActive(true);
            }
            

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
