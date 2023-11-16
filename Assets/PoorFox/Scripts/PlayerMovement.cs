using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;

    private float dirX = 0f;
    public static PlayerMovement instance;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private LayerMask jumpableGround;

    [Header("Rebote")]
    [SerializeField] private float velocidadRebote;

    private PlayerLife recuperacion;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private float damageCooldown = 3.0f; // Tiempo en segundos que debe pasar antes de que el enemigo pueda dañar al jugador nuevamente
    private float lastDamageTime; // La última vez que el enemigo dañó al jugador

    private enum MovementState { idle, running, jumping, hurt, dead, falling }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        // Inicializa lastDamageTime a un valor suficientemente pequeño
        lastDamageTime = -damageCooldown;


    }

    // Update is called once per frame
    private void Update()
    {
        if (knockBackCounter <= 0)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);

            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            sprite.flipX = false;
            state = MovementState.running;
        }
        else if (dirX < 0f)
        {
            sprite.flipX = true;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {

            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .2f, jumpableGround);
    }


    public void knockback()
    {
        knockBackCounter = knockBackLength;
        rb.velocity = new Vector2(0f, knockBackForce);
    }
    private bool IsFalling()
    {
        return rb.velocity.y < 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Comprueba si ha pasado suficiente tiempo desde la última vez que el enemigo dañó al jugador
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                if (!IsFalling())
                {
                    PlayerLife.instance.DealDamage();
                    // Actualiza lastDamageTime a la hora actual
                    lastDamageTime = Time.time;
                }
                else
                {
                    other.gameObject.SetActive(false);
                }
            }
        }
    }

    public void Rebote()
    {
        rb.velocity = new Vector2(rb.velocity.x, velocidadRebote);
    }

}
