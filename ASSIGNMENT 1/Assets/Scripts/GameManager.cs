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
    public static GameObject level;
    public static GameObject player;
    public static bool gameIsOver = false;

    public AudioSource FireProjectile_ref;
    public static AudioSource FireProjectile;

    public static int player1Lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
        playArea = GameObject.FindGameObjectWithTag("PlayArea");
        playArea.SetActive(false);
        endGameScreen = GameObject.FindGameObjectWithTag("EndGameScreen");
        endGameScreen.SetActive(false);

        FireProjectile = FireProjectile_ref;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async static void flagDestroyed()
    {
        //Pause game for 3 seconds
        gameIsOver = true;
        await System.Threading.Tasks.Task.Delay(2000);
        //display game over screen
        level = GameObject.FindGameObjectWithTag("Level");
        Destroy(level);
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);
        endGameScreen.SetActive(true);
        playArea.SetActive(false);

        //go to menu
        await System.Threading.Tasks.Task.Delay(2000);
        menu.SetActive(true);
        endGameScreen.SetActive(false);

    }
}
