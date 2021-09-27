using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    /*public Transform John;
    Vector3 vel = Vector3.zero;
    public float Tiem = 0.15f;


    void FixedUpdate()
    {
        Vector3 pos = John.position;
        pos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref vel, Tiem);
    }*/

    public GameObject John;


    Vector3 position;
    void Start()
    {
        position = transform.position - John.transform.position;

    }

    void Update()
    {
        transform.position = John.transform.position + position;
    }

 
}