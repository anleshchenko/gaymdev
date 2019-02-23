using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector2 direction;
    public float speed;
    public float rotation;


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0, 0, rotation);       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction*speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SendMessage("Attack", 10);
        }
        DestroyImmediate(gameObject);
    }
}
