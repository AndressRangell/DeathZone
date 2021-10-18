using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySe : MonoBehaviour
{
    public float velocidad;
    public Transform player;
    public Rigidbody2D rg;
     
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;

            if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);


            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rg.position, objetivo, velocidad * Time.deltaTime);
            rg.MovePosition(nuevaPos);

         }
        
    }
}
