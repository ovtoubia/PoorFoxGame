using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float moveDistance = 10.0f;  // Distancia de movimiento
    public float speed = 2.0f;   // Velocidad de movimiento

    private float minX;  // Posición mínima en X
    private float maxX;  // Posición máxima en X
    private int direction = 1;   // Dirección inicial (1 para derecha, -1 para izquierda)

    void Start()
    {
        // Inicializar las posiciones mínima y máxima
        minX = transform.position.x - moveDistance;
        maxX = transform.position.x + moveDistance;
    }

    void Update()
    {
        // Mover la plataforma
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);

        // Cambiar de dirección si se alcanza el límite
        if (transform.position.x > maxX)
        {
            direction = -1;  // Cambiar a la izquierda
        }
        else if (transform.position.x < minX)
        {
            direction = 1;   // Cambiar a la derecha
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
