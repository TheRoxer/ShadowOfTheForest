using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    public HealthBar healthBar;

    Vector2 movementInput;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    [SerializeField] private AudioSource swingEffect;
    [SerializeField] private AudioSource deathEffect;
    [SerializeField] private AudioSource dashEffect;
    [SerializeField] private TrailRenderer trailRenderer;

    // private bool canDash = true;
    // private bool isDashing = false;  
    // private float dashingPower = 4f;
    // private float dashingTime = 0.2f;
    // private float dashingCooldown = 1f;


    bool canMove = true;
    
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

    public float health = 25;
    public float maxHealth = 25;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar.SetMaxHealth((int)maxHealth);
    }

    void FixedUpdate() 
    {   

        // if(isDashing) {
        //     return;
        // }

        if(canMove) {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                    if(!success) {
                        success = TryMove(new Vector2(movementInput.x, 0));
                    }

                    if(!success) {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                

                animator.SetBool("isMoving", success);

            } else {
                animator.SetBool("isMoving", false);
            }

            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;

            } else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }

    }
    

    private bool TryMove(Vector2 direction) 
    {

        if(direction != Vector2.zero) {
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset
            );

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    } 

    // Movement mehanics //

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire() 
    {
        animator.SetTrigger("swordAttack");
    }

    // void OnDash() 
    // {
    //     if(canDash) {
    //         StartCoroutine(Dash());
    //     }
    // }

    public void lockMovement() 
    {
        canMove = false;
    }

    public void unlockMovement() 
    {
        canMove = true;
    }

    public void EndSwordAttack() 
    {
        swordAttack.StopAttack();
        unlockMovement();
    }

    public void SwordAttack() {
        lockMovement();

        if(spriteRenderer.flipX == true){
            swordAttack.AttackLeft();
        } else {
            swordAttack.AttackRight();
        }
        swingEffect.Play();

    }

    // Death mehanics //

    public void Defeated(){ 
        animator.SetTrigger("PlayerDefeated");
        deathEffect.Play();
    }

    public void RemovePlayer() {
        Destroy(gameObject);
        SceneManager.LoadScene(2);

    }

    public void TakeDamage(float damage) {
        Health -= damage;
        healthBar.setHealth((int)health);
    }

    // private IEnumerator Dash() {
        
    //     canDash = false;
    //     isDashing = true;

    //     if(spriteRenderer.flipX == true){
    //         // rb.AddForce(Vector2.left * dashingPower, ForceMode2D.Impulse);
    //         rb.velocity = new Vector2(transform.localScale.x * dashingPower * -1, 0f);
    //     } else {
    //         // rb.AddForce(Vector2.right * dashingPower, ForceMode2D.Impulse);
    //         rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
    //     }

    //     // rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

    //     trailRenderer.emitting = true;
    //     yield return new WaitForSeconds(dashingTime);
    //     trailRenderer.emitting = false;
    //     isDashing = false;
    //     yield return new WaitForSeconds(dashingCooldown);
    //     canDash = true;

    // }

}



