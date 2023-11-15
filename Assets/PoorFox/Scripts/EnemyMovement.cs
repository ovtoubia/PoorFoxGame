using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;   // Velocidad de movimiento
    public float changeDirectionTime = 3f; // Tiempo para cambiar de dirección
    private float timer = 0f; // Variable para realizar el seguimiento del tiempo

    private int direction = -1;   // Dirección inicial: 1 para derecha, -1 para izquierda

    private Rigidbody2D rb; // Componente Rigidbody2D del enemigo

    private void Start()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        ChangeDirection();
    }

    void Update()
    {
        // Mover el enemigo en la dirección actual
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        // Contar el tiempo
        timer += Time.deltaTime;

        // Verificar si ha pasado el tiempo establecido para cambiar de dirección
        if (timer >= changeDirectionTime)
        {
            // Cambiar la dirección
            ChangeDirection();
            // Reiniciar el temporizador
            timer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Cambiar de dirección cuando se detecta una colisión
        ChangeDirection();
        timer = 0f;

    }

    void ChangeDirection()
    {
        // Cambiar la dirección a su opuesta
        direction = -direction;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
