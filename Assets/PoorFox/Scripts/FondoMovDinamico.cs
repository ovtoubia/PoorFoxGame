using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FondMovimientoDinamico : MonoBehaviour
{
    [SerializeField] private Vector2 VelocidadMovimiento;

    private Vector2 offset;
    private Material material;
    private CinemachineVirtualCamera camaraVirtual;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        camaraVirtual = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        lastPosition = camaraVirtual.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = (camaraVirtual.transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = camaraVirtual.transform.position;
        offset = (speed * 0.1f) * VelocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
