using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IAttackable
{
    public float health;
    public float speed;
    public float bulletSpeed;
    public Bullet bullet;

    public Joystick joystick;
    public Button attackButton;
    public Button reloadButton;
    public Button stabButton;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator animator;
    public float x, y;
    
    public Vector2 direction;
    public float rotation;

    public bool isShooting = false;
    public bool isStabbing = false;
    public bool isReloading = false;

    private bool isFree = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(1);
        }
        else
        {
            x = joystick.Horizontal;
            y = joystick.Vertical;
            if (attackButton.isPressed && isFree)
            {
                isFree = false;
                isShooting = true;
                Shoot();
            }

            if (stabButton.isPressed && isFree)
            {
                isFree = false;
                isStabbing = true;
                StartCoroutine(Stab());
            }

            if (reloadButton.isPressed && isFree)
            {
                isFree = false;
                isReloading = true;
                StartCoroutine(Reload());
            }
            Vector2 moveInput = new Vector2(x, y);
            moveVelocity = moveInput * speed;
        }
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        Animate();
    }

    void Animate()
    {
        animator.SetFloat("velocity", Mathf.Abs(x + y));
        animator.SetBool("isShooting", isShooting);
        animator.SetBool("isStabbing", isStabbing);
        animator.SetBool("isReloading", isReloading);
        if (x != 0f || y != 0f)
        {
            direction = new Vector2(x, y);
            rotation = Mathf.Atan2(y, x) * 180 / Mathf.PI;
            transform.eulerAngles = new Vector3(0, 0, rotation);
        }
    }

    void Shoot() {
        Bullet bulletClone = Instantiate(bullet, transform.position + (Vector3)(direction.normalized*0.47f - Vector2.Perpendicular(direction).normalized*0.15f), transform.rotation);
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay() {
        isFree = false;
        yield return new WaitForSeconds(0.25f);
        isShooting = false;
        isFree = true;
    }

    IEnumerator Stab() {
        isFree = false;
        yield return new WaitForSeconds(1);
        isStabbing = false;
        isFree = true;
    }

    IEnumerator Reload() {
        isFree = false;
        yield return new WaitForSeconds(1f);
        isReloading = false;
        isFree = true;
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
