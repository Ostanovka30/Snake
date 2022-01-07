using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour
{
    public Text LevelText;
    public Game Game;

   
    public void WriteText()
    {
        LevelText.text = "Level " + Game.LevelIndex.ToString();

    }

}
