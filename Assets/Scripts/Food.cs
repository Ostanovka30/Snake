using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out SnakeTail snakeTail)) return;
        if (snakeTail.Length <= 0) return;
        snakeTail.AudioPlay();
        snakeTail.AddTail();
        snakeTail.LengthText.SetText(snakeTail.Length.ToString());
        DestroyFood();
    }


    private void DestroyFood()
    {
        this.gameObject.SetActive(false);
    }

}
