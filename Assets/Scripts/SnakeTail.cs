using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SnakeTail : MonoBehaviour
{
    public Game Game;
    public Transform SnakeHead;
    public float CircleDiameter;
    public int Length = 1;
    public int LengthStart = 5;
    public TextMeshPro LengthText;
    public AudioSource _audio;


    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {

        if (Game.LevelIndex == 1) Game.ReloadLevel();

        positions.Add(SnakeHead.position);
        AddTail();
        AddTail();
        AddTail();
        AddTail();
        LengthText.SetText(Length.ToString());
    }


    private void Update()
    {
        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddTail()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
        Length++;
    }

    public void RemoveTail()
    {
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(1);
        Length--;
    }

    public void RemoveSnake() 
    {
        while (Length > 1) RemoveTail();
    }



    public void Die()
    {
        Game.OnPlayerDied();
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachFinish();
        LengthStart = Length;

        RemoveSnake();

    }


    public void StartLevel() 
    {
     
        for (int i = 0; i < LengthStart-1; i++)
        {
            AddTail();
            LengthText.SetText(LengthStart.ToString());
        }
   
    }

    public void AudioPlay()
    {
        _audio.Play();
    }

    


}
