using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public Image heart1, heart2, heart3;

    public Sprite HeartFull;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealthDisplay()
    {
        switch (PlayerLife.instance.CurrentHealth)
        {
            case 3:
                heart1.sprite = HeartFull; 
                heart2.sprite = HeartFull;
                heart3.sprite = HeartFull;
                break;
            case 2:
                heart1.sprite = HeartFull;
                heart2.sprite = HeartFull;
                heart3.enabled = false;
                break;
            case 1:
                heart1.sprite = HeartFull;
                heart2.enabled = false;
                heart3.enabled = false;
                break;
            case 0:
                heart1.enabled = false;
                heart2.enabled = false;
                heart3.enabled = false;
                break;
        }
    }
}
