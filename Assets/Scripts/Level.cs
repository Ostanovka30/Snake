using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    private Transform[] _child;

    private void Awake() 
    {
        _child = getChildsWithTag();
    }


    public void ChildON() 
    {
        foreach (Transform child in _child)
        {
            child.gameObject.SetActive(true);
        }
    }


    private Transform[] getChildsWithTag()
    {
        List<Transform> result = new List<Transform>();

        foreach (Transform child in this.GetComponentsInChildren<Transform>())
        {
            result.Add(child);
        }
        return result.ToArray();
    }




}
