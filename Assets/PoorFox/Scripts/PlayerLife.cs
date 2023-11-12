using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die(); 
            StartCoroutine(RestartLevelAfterDelay());
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        rb.bodyType =  RigidbodyType2D.Static;
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
}
