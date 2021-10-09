using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBullet : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    public AudioClip Sound;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "grunt" || collision.tag == "Boss")
        {
            GruntScript grunt = collision.GetComponent<GruntScript>();
            GruntFinal boss = collision.GetComponent<GruntFinal>();
            JohnMovi john = collision.GetComponent<JohnMovi>();
            JohnLevel3 john3 = collision.GetComponent<JohnLevel3>();
            if (grunt != null)
            {
                grunt.Hit();
            }
            if (john != null)
            {
                john.Hit();
            }
            if (john3 != null)
            {
                john3.Hit();
            }
            if (boss != null)
            {
                boss.Hit();
            }
            DestroyBullet();
        }

    }

}
