using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public int maxHealth;
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public float Health {
        set {
            health = value;

            if(health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 1;

    private void Start() {
        animator = GetComponent<Animator>(); 
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }

    public void Defeated(){ 
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    private void FixedUpdate() {
        if(target)
        {   

            int count = rb.Cast(

                moveDirection,
                movementFilter,
                castCollisions,
                speed * Time.fixedDeltaTime + 0.1f

            );

            if(count > 0) {
                moveDirection = Vector2.zero;
            }

            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;

            
        }
    }

    public void TakeDamage (float damageAmount) 
    {

    }
}