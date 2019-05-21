using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour, IAttackable
{
    public Player player;
    public Base car;
    public float attackDistance;
    public float speed;
    public float health;
    public float damage;
    public Animator animator;
    public ZombieWave zw;

    private bool isMoving = true;
    private bool isAttacking;
    private bool canAttack;
    
    private Rigidbody2D rg;
    private SpriteRenderer spriteRenderer;
    private Vector2 direction;
    private float rotation;
    private IAttackable target;
    

    // Start is called before the first frame update
    void Start()
    {     
        rg = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        chooseTarget();
        // Значение усиления атаки (может быть отрицательным)
        float powerBuff = Random.value - 0.5f;
        // Значение усиления скорости (обратно пропорционально усилению атаки)
        float speedBuff = -powerBuff;
        // Применение усилений
        damage += powerBuff*10;
        speed += speedBuff / 2; 
    }

    private void chooseTarget() {
        if (Random.value > 0.5)
        {
            target = player;
        }
        else
        {
            target = car;
        }
    }

    void FixedUpdate()
    {
        if(player != null){
            if (health <= 0)
            {
                StartCoroutine(Die());
            }
            else {
                direction = target.GetPosition() - rg.position;
                rotation = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
                transform.eulerAngles = new Vector3(0, 0, rotation);
                if (canAttack && !isAttacking) {
                    StartCoroutine(AttackTarget());
                }
                rg.MovePosition(rg.position + direction.normalized * speed * Time.fixedDeltaTime);    
                Animate();
            }
        }
    }

    void Animate() {
        animator.SetBool("isAttacking", canAttack);
        animator.SetFloat("velocity", speed);
        if (!isAttacking)
        {
            animator.Play("zombie_move");
        }
        else {
            animator.Play("zombie_attack");
        }
        float hc = health / 100 + 0.25f;
        spriteRenderer.color = new Color(1, hc, hc);
    }

    IEnumerator AttackTarget() {
        if (!isAttacking)
        {
            isAttacking = true;
            yield return new WaitForSeconds(0.75f);
            if (canAttack)
                target.Attack(10);
            isAttacking = false;
        }
    }

    IEnumerator Die() {
        animator.Play("zombie_die");
        yield return 0.5f;
        Destroy(gameObject);
        zw.KillZombie();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Attack(20);
        }
        if (collision.gameObject.tag.Equals("MeleeAttack")) {
            if (player.isStabbing)
                Attack(33);
        }
        if (collision.gameObject.tag.Equals("Player")) {
            target = player;
            canAttack = true;
        }
        if (collision.gameObject.tag.Equals("Ally")) {
            target = car;
            canAttack = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("MeleeAttack"))
        {
            if (player.isStabbing)
            {
                Attack(25);
                player.isStabbing = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        canAttack = false;
        isAttacking = false;
    }



    public Vector2 GetPosition()
    {
        return rg.position;
    }

    public void Attack(float damage)
    {
        health -= damage;
    }

}
