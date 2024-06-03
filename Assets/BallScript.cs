using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5;
    private float flip = 1;
    public TMP_Text ScoreP1_Text;
    public TMP_Text ScoreP2_Text;
    private int ScoreP1 = 0;
    private int ScoreP2 = 0;
    private Vector3 StartTransform;

    // Start is called before the first frame update
    void Start()
    {
        StartTransform = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
        if (col.gameObject.name == "PaddleLeft")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "PaddleRight")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WallPongLeft"))
        {
            ScoreP2++;
            ScoreP2_Text.text = ScoreP2.ToString();
            transform.position = StartTransform;
        }
        else if (collision.gameObject.CompareTag("WallPongRight"))
        {
            ScoreP1++;
            ScoreP1_Text.text = ScoreP1.ToString();
            transform.position = StartTransform;
        }
    }
}
