using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveMotion : MonoBehaviour
{
    public Vector3 amplitude = new Vector3(6, 0, 0);

    public float velocidadeAngular = 50;

    public float angulo = 0;

    private Rigidbody2D rb;

    public Vector3 posicaoInicial;
    public Vector3 deslocamento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicaoInicial = GetComponent<Transform>().position;
    }

    void FixedUpdate()
    {
        Movimento();
    }


    void Movimento()
    {
        angulo = Mathf.Clamp(0, angulo + Time.deltaTime * velocidadeAngular, 360);

        if (angulo > 359.9f)
        {
            angulo = 0;
        }

        deslocamento = amplitude * Mathf.Sin(angulo * Mathf.Deg2Rad);

        rb.MovePosition(posicaoInicial + deslocamento);
    }
}
