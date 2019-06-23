using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour, IAttackable
{
    public float health;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            StartCoroutine(BaseDestroy());
        }
    }

    void FixedUpdate()
    {
        float hc = 1 - health / 500;
        hc /= 4;
        sr.color = new Color(1 - hc, 1 - 2 * hc, 1 - 2 * hc);
    }

    IEnumerator BaseDestroy() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("DeadWindow");
    }

    public void Attack(float damage)
    {
        health -= damage;
    }

    public Vector2 GetPosition()
    {
        return rb.position;
    }
}
