using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject John;


    Vector3 position;
    void Start()
    {
         position = transform.position - John.transform.position;

    }

    void Update()
    {
        if (John != null)
        {
            transform.position = John.transform.position + position;
        }
        
    }

 
}