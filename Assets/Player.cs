using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Sprite[] sprites = new Sprite[8];
    public Joystick joystick;


    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Mathf.Round(joystick.Horizontal);
        y = Mathf.Round(joystick.Vertical);
        Vector2 moveInput = new Vector2(x, y);
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        Animate();
    }

    void Animate()
    {
        if (y > 0)
        {
            if (x > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
            }
            if (x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            }
            if (x == 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
            }
        }
        if (y < 0)
        {
            if (x > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
            }
            if (x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
            }
            if (x == 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
            }
        }
        if (y == 0)
        {
            if (x > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
            }
            if (x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            }
        }
    }
}
