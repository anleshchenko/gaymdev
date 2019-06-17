using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;
    public float speed;

    private float rotation;
    private Vector2 direction;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        direction = player.direction.normalized;
        rotation = player.rotation;
        rb = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0, 0, rotation);       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction*speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Tree") || collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("MeleeAttack"))
            return;
        else if (collision.gameObject.tag.Equals("Map"))
            StartCoroutine(DestroyWithDelay());
        else
            Destroy(gameObject);
    }

    IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    
}
