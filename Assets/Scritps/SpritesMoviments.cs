using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesMoviments : MonoBehaviour
{
    public float maxSpeed;
    public float minSpeed;

    public float speed;

    private float y;

    private void Start()
    {
        speed = Random.Range(maxSpeed, minSpeed);
        if (Controller.instance != null)
        {
            maxSpeed = maxSpeed + Controller.instance.aumentarspeed;
            minSpeed = minSpeed + Controller.instance.aumentarspeed;
        }
    }

    void Update()
    {
        
        y = transform.position.y;
        y -= speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
