using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    PlayerController player;

    public ContactFilter2D movementFilter;
    public int maxHealth;
    public float damage = 3;

    [SerializeField] float speed = 5f;
    [SerializeField] private AudioSource slimeEffect;

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
        GetComponent<LootBag>().InstantiateLoot(transform.position);
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
                speed * Time.fixedDeltaTime

            );

            if(count > 0) {
                moveDirection = Vector2.zero;
            }

            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
            animator.SetBool("isMoving", true);

            if(moveDirection.x > 0) {
                transform.localScale = new Vector3(1, 1, 1);
            } else if(moveDirection.x < 0) {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null) {
                player.TakeDamage(damage);
                slimeEffect.Play();
            }
        }
    } 
}