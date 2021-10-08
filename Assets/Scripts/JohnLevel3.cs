using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class JohnLevel3 : MonoBehaviour
{
    public GameObject BulletPrefab;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    public float Speed;
    public float JumpForce;
    private float LastShoot;
    private int Health = 7;
    public string textValue;
    public Text textEdit;
    public string textScore;
    public Text textEditScore;
    private int score = 600;
    public GameObject Boss;

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
        else if (Horizontal > 0.0f)
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


        textEdit.text = Health.ToString();
        textEditScore.text = score.ToString();
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

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
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

        if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
            Resect();
        }

        if (collision.gameObject.tag == "finish" && score == 900 && Boss == null)
        {
            SceneManager.LoadScene("Credits");
        }
    }

    private void Resect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "frutCharries")
        {
            Destroy(GameObject.FindWithTag("frutCharries"));
            Score();
            Debug.Log("choca con fruta");
        }

        if (collision.gameObject.tag == "frut")
        {
            Destroy(GameObject.FindWithTag("frut"));
            Score();
            Debug.Log("choca con fruta");
        }

        if (collision.gameObject.tag == "frutOrange")
        {
            Destroy(GameObject.FindWithTag("frutOrange"));
            Score();
            Debug.Log("choca con fruta");
        }

    }

    public void Score()
    {
        score += 100;
        Debug.Log("scoreeee" + score);
    }

    public int getScore(int score)
    {
        return score;
    }

}




