using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float ForwardSpeed = 5;
    public float Sensitivity = 50;



 
    private Rigidbody componentRigidbody;
    private SnakeTail componentSnakeTail;

    public Vector3 touchLastPos;
    private float sidewaysSpeed;
  


    private void Start()
    {
      
        componentRigidbody = GetComponent<Rigidbody>();
        componentSnakeTail = GetComponent<SnakeTail>();

  

    }

    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;

        }
        else if (Input.GetMouseButton(0))

        {
            Vector3 delta = Input.mousePosition - touchLastPos;
            sidewaysSpeed += delta.x * Sensitivity;

            touchLastPos = Input.mousePosition;


        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        componentRigidbody.velocity = new Vector3(sidewaysSpeed * 5, 0, ForwardSpeed*2);

        sidewaysSpeed = 0;
       
    }


   




}

