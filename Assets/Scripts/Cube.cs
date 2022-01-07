using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public int HP;
    public TextMeshPro PointsText;
    private AudioSource _audioBounce;
    public AudioClip AudioFall;
    public Game Game;



    private void Awake()
    {
        HP = UnityEngine.Random.Range(1, 11);
        PointsText.SetText(HP.ToString());
        ColorCube();
        _audioBounce = GetComponent<AudioSource>();
        Game = (Game)FindObjectOfType(typeof(Game));
      
    }

      
    private async void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out SnakeTail snakeTail)) return;

        int _hpOriginal = HP;
        int lengthOriginal = snakeTail.Length;
    

        if ((lengthOriginal - _hpOriginal) > 0)
        {
            for (int i = 0; i < _hpOriginal; i++)
            {
                AudioPlay();
                snakeTail.RemoveTail();
                HP--;
                PointsText.SetText(HP.ToString());
                snakeTail.LengthText.SetText(snakeTail.Length.ToString());
                await Task.Delay(200);
            }

            DestroyCube();
        }

        else 
        {
            
            for (int i = 1; i < lengthOriginal; i++)
            {
                AudioPlay();
                snakeTail.RemoveTail();
                HP--;
                PointsText.SetText(HP.ToString());
                snakeTail.LengthText.SetText(snakeTail.Length.ToString());
                await Task.Delay(200);
            }

            HP--;
            if (HP < 0) HP = 0;
            snakeTail.Length--;
            PointsText.SetText(HP.ToString());
            snakeTail.LengthText.SetText(snakeTail.Length.ToString());
            _audioBounce.PlayOneShot(AudioFall);
            snakeTail.Die();

        }
    }

    private void DestroyCube()
    {
        this.gameObject.SetActive(false);
    }

    public void AudioPlay()
    {
        _audioBounce.Play();
    }

  
    public void ColorCube() 
    {
        
        switch (HP)
        {
            case 1:
            case 2: gameObject.GetComponent<MeshRenderer>().material.color = new Color32(57, 195, 219, 255); break;
            case 3:
            case 4: gameObject.GetComponent<MeshRenderer>().material.color = new Color32(15, 118, 177, 255); break;
            case 5:
            case 6: gameObject.GetComponent<MeshRenderer>().material.color = new Color32(15, 51, 190, 255); break;
            case 7:
            case 8: gameObject.GetComponent<MeshRenderer>().material.color = new Color32(42, 32, 152, 255); break;
            case 9:
            case 10: gameObject.GetComponent<MeshRenderer>().material.color = new Color32(24, 10, 101, 255); break;
        }

    }


    //public void ReloadCube()
    //{
    //    Game.flagCube = false;
    //    HP = UnityEngine.Random.Range(1, 11);
    //    PointsText.SetText(HP.ToString());
    //    ColorCube();
    //}

    public async void ReloadCubeDelay()
    {
        await Task.Delay(200);
        HP = UnityEngine.Random.Range(1, 11);
        PointsText.SetText(HP.ToString());
        ColorCube();
        Game.flagCube = false;
    }


    private void Update()
    {
        if (Game.flagCube) ReloadCubeDelay();

        ColorCube();

    }
}
