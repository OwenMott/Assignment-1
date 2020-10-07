using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameObject menu;
    public static GameObject playArea;
    public static GameObject endGameScreen;


    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
        playArea = GameObject.FindGameObjectWithTag("PlayArea");
        playArea.SetActive(false);
        endGameScreen = GameObject.FindGameObjectWithTag("EndGameScreen");
        endGameScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async static void flagDestroyed()
    {
        //Pause game for 3 seconds
         
        await System.Threading.Tasks.Task.Delay(2000);
        //display game over screen
        endGameScreen.SetActive(true);
        playArea.SetActive(false);

        //go to menu
    }
}
