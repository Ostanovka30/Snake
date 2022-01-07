using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth = 5.0f;
    public Vector3 offset = new Vector3(0, 30, 7.2f);
    void Update()
    {
        transform.position = new Vector3 (0, 30f, Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth).z);
    }
}
