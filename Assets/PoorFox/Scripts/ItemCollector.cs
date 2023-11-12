using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int gems = 0;
    [SerializeField] private Text gemsText;
   private void OnTriggerEnter2D(Collider2D collision) 
   {
    if (collision.gameObject.CompareTag("Gem"))
    {
        Destroy(collision.gameObject);
        gems++;
        gemsText.text = "Gems: " +gems;
        //Ausilio
    }
   }
}
