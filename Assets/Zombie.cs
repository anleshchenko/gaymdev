using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour, IAttackable
{
    public Player player;
    public Base car;
    public float attackDistance;
    public float speed;
    public int health;
    public int damage;
    public Animator animator;
    public ZombieWave zw;

    private bool isMoving = true;
    private bool isAttacking;
    private bool canAttack;
    
    private Rigidbody2D rg;
    private Vector2 direction;
    private float rotation;
    private IAttackable target;
    

    // Start is called before the first frame update
    void Start()
    {     
        rg = GetComponent<Rigidbody2D>();
        chooseTarget();    
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

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player != null){
            if (health <= 0)
            {
                Destroy(gameObject);
                zw.KillZombie();
            }
            else {
                direction = target.GetPosition() - rg.position;
                rotation = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
                transform.eulerAngles = new Vector3(0, 0, rotation);
                if (canAttack && !isAttacking) {
                    StartCoroutine(AttackTarget());
                }
                if (!isAttacking) {
                    rg.MovePosition(rg.position + direction.normalized * speed * Time.fixedDeltaTime);
                }
                Animate();
            }
        }
    }

    void Animate() {

        if (!isAttacking)
        {
            animator.Play("zombie_move");
        }
        else {
            animator.Play("zombie_attack");
        }
    }

    IEnumerator AttackTarget() {
        if (!isAttacking)
        {
            isAttacking = true;
            yield return new WaitForSeconds(0.3f);
            if (canAttack)
                target.Attack(10);
            isAttacking = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Attack(10);
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


    void OnTriggerExit2D(Collider2D collision)
    {
        canAttack = false;
        isAttacking = false;
    }



    public Vector2 GetPosition()
    {
        return rg.position;
    }

    public void Attack(int damage)
    {
        health -= damage;
    }

}
