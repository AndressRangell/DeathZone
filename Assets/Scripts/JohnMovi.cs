using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JohnMovi : MonoBehaviour
{
    public GameObject BulletPrefab;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    public float Speed;
    public float JumpForce;
    private float LastShoot;
    private int Health = 5;
    public string textValue;
    public Text textEdit;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }
        
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) 
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if(Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }

        Animator.SetBool("running", Horizontal != 0.0f);

        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }

        
        textEdit.text = Health.ToString(); ;
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f , Quaternion.identity);
        bullet.GetComponent<ScriptBullet>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) 
        { 
            Destroy(gameObject);
            Resect();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemi")
        {
            Destroy(gameObject);
            Resect();
        }

        if (collision.gameObject.tag == "ball")
        {
            Destroy(gameObject);
            Resect();
        }

        if (collision.gameObject.tag == "vacio")
        {
            Destroy(gameObject);
            Resect();
        }

        if (collision.gameObject.tag == "finish")
        {
            SceneManager.LoadScene("CartoonOne");
        }
    }

    private void Resect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    



}
