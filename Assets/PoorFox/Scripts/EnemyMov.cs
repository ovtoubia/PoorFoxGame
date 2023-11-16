using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public float speed;
    private bool esDerecha=true;
    private float tiempoCambiarDireccion;
    public float TiempoCaminar; //tiempo para ir en una direccion
    public Rigidbody2D rb;
    public float fuerzaSalto;

    void Start()
    {
        tiempoCambiarDireccion = TiempoCaminar;
        InvokeRepeating("Saltar", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //Cambiar de direccion
        if (esDerecha)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(1.5f,1.5f,1);
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }
        tiempoCambiarDireccion -= Time.deltaTime;
        if(tiempoCambiarDireccion <= 0)
        {
            tiempoCambiarDireccion = TiempoCaminar;
            esDerecha = !esDerecha;
        }
    }

    private void Saltar()
    {
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
    }
}
