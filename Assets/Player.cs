using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    //public Sprite[] sprites = new Sprite[8];
    public Joystick joystick;
    public Animator anim;


    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float x, y;
    private float angle;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = joystick.Horizontal;
        y = joystick.Vertical;
       

        Vector2 moveInput = new Vector2(x, y);
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        Animate();
    }

    void Animate() {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(y, x) * 180 / Mathf.PI);
        if (x != 0f || y != 0f)
        {
            if (!isRunning)
                anim.Play("player_walk");
            isRunning = true;
        }
        else
        {
            if (isRunning)
                anim.Play("player_idle");
            isRunning = false;
        }
    }

    //void Animate()
    //{
    //    int anX, anY;
    //    if (x > 0) {
    //        anX = x > 0.25 ? 1 : 0;
    //    }
    //    else {
    //        anX = x < -0.25 ? -1 : 0;
    //    }
    //    if (y > 0)
    //    {
    //        anY = y > 0.25 ? 1 : 0;
    //    }
    //    else
    //    {
    //        anY = y < -0.25 ? -1 : 0;
    //    }

    //    if (anY > 0)
    //    {
    //        if (anX > 0)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
    //        }
    //        if (anX < 0)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
    //        }
    //        if (anX == 0)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
    //        }
    //    }
    //    if (anY < 0)
    //    {
    //        if (anX > 0)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
    //        }
    //        if (anX < 0)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
    //        }
    //        if (anX == 0)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
    //        }
    //    }
    //    if (anY == 0)
    //    {
    //        if (anX > 0)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
    //        }
    //        if (anX < 0)
    //        {
    //            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
    //        }
    //    }
    //}
}
