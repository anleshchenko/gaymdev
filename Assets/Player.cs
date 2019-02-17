using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float bulletSpeed;
    public Animator anim;
    public Bullet bullet;

    public Joystick joystick;
    public AttackButton attackButton;
    public ReloadButton reloadButton;
    public StabButton stabButton;


    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float x, y;
    
    private Vector2 direction;
    private float rotation;

    private bool canShoot = true;
    private bool isRunning = false;
    private bool isShooting = false;
    private bool isStabbing = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = joystick.Horizontal;
        y = joystick.Vertical;
        if (attackButton.isPressed && canShoot)
        {
            Shoot();
        }
        Vector2 moveInput = new Vector2(x, y);
        moveVelocity = moveInput * speed;
     
    }

    void FixedUpdate()
    {    
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
        Animate();
    }

    void Animate()
    {
        if (attackButton.isPressed)
        {
            if (!isShooting)
                anim.Play("player_shoot");
            isShooting = true;
            isRunning = false;
            isStabbing = false;
        }
        else if (stabButton.isPressed) {
            if (!isStabbing)
                anim.Play("player_stab");
            isStabbing = true;
            isShooting = false;
            isRunning = false;
        }
        else{
            if (x != 0f || y != 0f)
            {
                if (!isRunning || isShooting || isStabbing)
                    anim.Play("player_walk");
                isRunning = true;
                isShooting = false;
                isStabbing = false;
            }
            else
            {
                if (isRunning || isShooting || isStabbing)
                    anim.Play("player_idle");
                isRunning = false;
                isShooting = false;
                isStabbing = false;
            }           
        }

        if (x!= 0f || y!= 0f)
        {
            direction = new Vector2(x, y);
            rotation = Mathf.Atan2(y, x) * 180 / Mathf.PI;
            transform.eulerAngles = new Vector3(0, 0, rotation);
        }


    }

    void Shoot() {
        Bullet bulletClone = Instantiate(bullet, transform.position + (Vector3)(direction.normalized*0.47f - Vector2.Perpendicular(direction).normalized*0.15f), transform.rotation);
        bulletClone.direction = this.direction.normalized;
        bulletClone.rotation = this.rotation;
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay() {
        canShoot = false;
        yield return new WaitForSeconds(0.25f);
        canShoot = true;
    }
}
