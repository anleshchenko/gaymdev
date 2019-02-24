using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour, IAttackable
{
    public int health;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            StartCoroutine(BaseDestroy());
        }
    }

    IEnumerator BaseDestroy() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    public void Attack(int damage)
    {
        health -= damage;
    }

    public Vector2 GetPosition()
    {
        return rb.position;
    }
}
