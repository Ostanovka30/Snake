using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Movement Movement;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject Finish_fireworks;
    public int LevelIndex = 1;
    public Level Level_1;
    public Level Level_2;
    public Level Level_3;
    public bool flagPlaying = true;
    public bool flagCube = false;
    public GameObject Snake;
    public SnakeTail componentSnakeTail2;


    public void OnPlayerDied()
    {
        Movement.enabled = false;
        LoseScreen.SetActive(true);
        Snake.gameObject.SetActive(false);
        flagPlaying = false;
    }

    public void OnPlayerReachFinish()
    {

        if (flagPlaying) 
        {
            Movement.enabled = false;
            Finish_fireworks.SetActive(true);
            WinScreen.SetActive(true);
            Snake.gameObject.SetActive(false);
            flagPlaying = false;
        }
    }



    public void ReloadLevel()
    {
             
        switch (LevelIndex)
        {
            case 1:
                Level_2.gameObject.SetActive(false);
                Level_3.gameObject.SetActive(false);
                Level_1.gameObject.SetActive(true);
                Level_1.ChildON();
                break;
            case 2:
                Level_1.gameObject.SetActive(false);
                Level_3.gameObject.SetActive(false);
                Level_2.gameObject.SetActive(true);
                Level_2.ChildON();
                break;
            case 3:
                Level_1.gameObject.SetActive(false);
                Level_2.gameObject.SetActive(false);
                Level_3.gameObject.SetActive(true);
                Level_3.ChildON();
                break;
        }
        
    }


    public async void ContinueGame() 
    {
        if (!flagPlaying) 
        {
            flagPlaying = true;
            ReloadLevel();
            flagCube = true;
            Snake.transform.position = new Vector3(0, 0, 0);
            Snake.gameObject.SetActive(true);
            componentSnakeTail2.StartLevel();
            await Task.Delay(1000);
            
            WinScreen.SetActive(false);
            Finish_fireworks.SetActive(false);
            LoseScreen.SetActive(false);
            Movement.enabled = true;
            componentSnakeTail2.Length = componentSnakeTail2.LengthStart;
            
        }
    }

    public void ReloadGame()
    {
        flagPlaying = false;
        Movement.enabled = false;
        //flagCube = true;
        componentSnakeTail2.RemoveSnake();
        ContinueGame();
    }


}
