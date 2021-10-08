using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntFinal : MonoBehaviour
{
    public Transform John;
    public GameObject BulletPrefab;
    public Transform Punt1;
    public Transform Punt2;
    public Transform Punt3;
    public Transform Punt4;
    public bool MoveToA = false;
    public bool MoveToB = false;
    private Rigidbody2D MyRb;
    public float Speed;

    private int Health = 4;
    private float LastShoot;
    private void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        MoveToA = true;
    }


    void Update()
    {
        if (John == null) return;

        Vector3 direction = John.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        else transform.localScale = new Vector3(-2.0f, 2.0f, 1.0f);

        float distance = Mathf.Abs(John.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.50f)
        {
            Shoot();
            LastShoot = Time.time;
        }


        if (MoveToA)
        {
            MyRb.transform.position = Vector2.MoveTowards(transform.position, Punt1.position, Speed * Time.deltaTime);

            if (transform.position.x <= Punt2.position.x)
            {
                MoveToA = false;
                MoveToB = true;
            }
        }

        if (MoveToB)
        {

            MyRb.transform.position = Vector2.MoveTowards(transform.position, Punt4.position, Speed * Time.deltaTime);

            if (transform.position.x >= Punt3.position.x)
            {
                MoveToA = true;
                MoveToB = false;
            }
        }
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<ScriptBullet>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}