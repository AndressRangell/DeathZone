using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFrut : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public Transform p3;
    public GameObject frut;

    void Start()
    {
        int i = Random.Range(0, 3);

        switch (i)
        {
            case 0:
                Instantiate(frut, p1.position, frut.transform.rotation);
                break;
            case 1:
                Instantiate(frut, p2.position, frut.transform.rotation);
                break;
            case 2:
                Instantiate(frut, p3.position, frut.transform.rotation);
                break;
        }


    }
}
