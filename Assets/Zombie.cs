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

    private bool isMoving;
    private bool isAttacking;
    
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
        rotation = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        transform.eulerAngles = new Vector3(0, 0, rotation);
        if (Vector2.Distance(rg.position, target.GetPosition()) < attackDistance)
        {
            if (!isAttacking)
                StartCoroutine(Attack());
        }
        else {
            direction = new Vector2(target.GetPosition().x - rg.position.x, target.GetPosition().y - rg.position.y).normalized;
            rg.MovePosition(rg.position + direction * speed * Time.fixedDeltaTime);
            isMoving = true;
        }
        Animate();
    }

    void Animate() {
        
        if (isMoving)
        {
            animator.Play("zombie_move");
        }
        else
        {
            if (isAttacking)
            {
                animator.Play("zombie_attack");
            }
            else {
                animator.Play("zombie_idle");
            }
        }
    }

    IEnumerator Attack() {
        isMoving = false;
        isAttacking = true;
        yield return new WaitForSeconds(0.25f);
        target.Attack(damage);
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
        isMoving = true;
    }

    void OnCollisionEnter() {
        if()
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
