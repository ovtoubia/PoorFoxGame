using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 VelocidadMovimiento;

    private Vector2 offset;
    private Material material;
    // Start is called before the first frame update
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = VelocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
