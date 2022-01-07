using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    public Game Game;
    private AudioSource _audioFinish;

    private void Awake()
    {
        _audioFinish = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (Game.flagPlaying) 
        {
            if (!collision.collider.TryGetComponent(out SnakeTail snakeTail)) return;
            {
                snakeTail.ReachFinish();
                _audioFinish.Play();
            }

            if (Game.LevelIndex < 3)
            {
                Game.LevelIndex++;
            }
            else Game.LevelIndex = 1;
        }
    }
}
