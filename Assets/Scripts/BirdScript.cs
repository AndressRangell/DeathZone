using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Transform Punt1;
    public Transform Punt2;
    public Transform Punt3;
    public Transform Punt4;
    public bool MoveToA = false;
    public bool MoveToB = false;
    private Rigidbody2D MyRb;
    public float Speed;
    private Animator animator;

    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        MoveToA = true;
    }


    void Update()
    {

        if (MoveToA)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
            MyRb.transform.position = Vector2.MoveTowards(transform.position, Punt1.position, Speed * Time.deltaTime);

            if (transform.position.x <= Punt2.position.x)
            {
                MoveToA = false;
                MoveToB = true;
            }
        }

        if (MoveToB)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);


            MyRb.transform.position = Vector2.MoveTowards(transform.position, Punt4.position, Speed * Time.deltaTime);

            if (transform.position.x >= Punt3.position.x)
            {
                MoveToA = true;
                MoveToB = false;
            }
        }

    }


}