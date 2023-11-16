using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionEnemigos : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            foreach(ContactPoint2D punto in other.contacts)
            {
                if (other.GetContact(0).normal.y <= -0.9)
                {
                    other.gameObject.GetComponent<PlayerMovement>().Rebote();
                    animator.SetTrigger("Hit");
                }
                else
                {
                    other.gameObject.GetComponent<PlayerLife>().DealDamage();
                }
            }
        }
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
