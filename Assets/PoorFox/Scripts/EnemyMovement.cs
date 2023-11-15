using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;   // Velocidad de movimiento
    public float changeDirectionTime = 3f; // Tiempo para cambiar de direcci�n
    private float timer = 0f; // Variable para realizar el seguimiento del tiempo

    private int direction = -1;   // Direcci�n inicial: 1 para derecha, -1 para izquierda

    private Rigidbody2D rb; // Componente Rigidbody2D del enemigo

    private void Start()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        ChangeDirection();
    }

    void Update()
    {
        // Mover el enemigo en la direcci�n actual
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        // Contar el tiempo
        timer += Time.deltaTime;

        // Verificar si ha pasado el tiempo establecido para cambiar de direcci�n
        if (timer >= changeDirectionTime)
        {
            // Cambiar la direcci�n
            ChangeDirection();
            // Reiniciar el temporizador
            timer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Cambiar de direcci�n cuando se detecta una colisi�n
        ChangeDirection();
        timer = 0f;

    }

    void ChangeDirection()
    {
        // Cambiar la direcci�n a su opuesta
        direction = -direction;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
