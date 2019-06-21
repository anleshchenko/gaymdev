using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour, IAttackable
{

    public float health;
    public float speed;
    public float bulletSpeed;
    public Bullet bullet;
    public GameObject weaponIcon;

    public Weapon Weapon { get; set; }

    public RuntimeAnimatorController rifleAnimator;
    public RuntimeAnimatorController pistolAnimator;

    public Joystick joystick;
    public Button attackButton;
    public Button reloadButton;
    public Button stabButton;  

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator animator;
    public float x { get; set; }
    public float y { get; set; }

    private Weapon pistol;
    private Weapon rifle;

    public Vector2 direction { get; set; }
    public float rotation { get; set; }

    public bool isShooting { get; set; }
    public bool isStabbing { get; set; }
    public bool isReloading { get; set; }

    private bool isFree { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        pistol = GetComponentInChildren<Pistol>();
        rifle = GetComponentInChildren<Rifle>();

        Weapon = pistol;
        animator.runtimeAnimatorController = pistolAnimator;
        Weapon.Reload();
        Weapon.UpdateText();
        isFree = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("DeadWindow");
        }
        else
        {
            x = joystick.Horizontal;
            y = joystick.Vertical;
            if (attackButton.isPressed && isFree && Weapon.CanShoot())
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

            if (reloadButton.isPressed && isFree && Weapon.CanReload())
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
        Bullet bulletClone = Instantiate(bullet, transform.position + (Vector3)(direction.normalized*0.5f - Vector2.Perpendicular(direction).normalized*0.22f), transform.rotation);
        Weapon.Shoot();
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay() {
        isFree = false;
        yield return new WaitForSeconds(Weapon.ShootDelay);
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
        Weapon.Reload();
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

    public void SwitchWeapon()
    {
        if (Weapon.Equals(rifle))
        {
            Weapon = pistol;
            weaponIcon.GetComponent<Image>().sprite = pistol.GetComponent<SpriteRenderer>().sprite;
            animator.runtimeAnimatorController = pistolAnimator;
        }
        else if (Weapon.Equals(pistol))
        {
            Weapon = rifle;
            weaponIcon.GetComponent<Image>().sprite = rifle.GetComponent<SpriteRenderer>().sprite;
            animator.runtimeAnimatorController = rifleAnimator;
        }
        Weapon.UpdateText();
    }

}
