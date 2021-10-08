using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frut3Script : MonoBehaviour
{
    public Transform[] puntos;
    public GameObject frut;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, 3);

        switch (i)
        {
            case 0:
                Instantiate(frut,puntos[0].position,frut.transform.rotation);
                break;
            case 1:
                Instantiate(frut, puntos[1].position, frut.transform.rotation);
                break;
            case 2:
                Instantiate(frut, puntos[2].position, frut.transform.rotation);
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
