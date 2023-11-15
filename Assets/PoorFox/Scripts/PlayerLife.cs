using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;
    private Animator anim;
    private Rigidbody2D rb;
    public int CurrentHealth;
    public int MaxHealth;
    public float invincibleLength=1.0f;
    public float invincibleCounter=2.0f;

    private SpriteRenderer rbSprite;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
    }
    /*
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die(); 
            StartCoroutine(RestartLevelAfterDelay());
        }
    }
    */
    private void Die()
    {
        anim.SetTrigger("death");
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        rb.bodyType =  RigidbodyType2D.Static;
        RestartLevelAfterDelay();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private IEnumerator RestartLevelAfterDelay()
    {
        yield return new WaitForSeconds(2);
        RestartLevel();
    }

    private void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
            if(invincibleCounter <= 0)
            {
                rbSprite.color = new Color(rbSprite.color.r,rbSprite.color.g,rbSprite.color.b,1f);
            }
        }
    }

    public void DealDamage()
    {
        if (invincibleCounter<=0)
        {
            CurrentHealth--;
            if (CurrentHealth <= 0)
            {
                Die();
            }
            else
            {
                invincibleCounter = invincibleLength;
                rbSprite.color = new Color(rbSprite.color.r, rbSprite.color.g, rbSprite.color.b, 0.5f);
                anim.SetTrigger("Hurt");
                PlayerMovement.instance.knockback();
            }
            UIController.Instance.UpdateHealthDisplay();
        }
        
        
    }
}
