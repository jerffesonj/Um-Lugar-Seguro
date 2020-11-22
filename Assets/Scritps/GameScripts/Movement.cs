using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;

    public bool gameOver = false;

    void Update()
    {
        if(!gameOver)
            MovePlayer();
    }

    //seguir mouse/touch
    void MovePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            if (Controller.instance.estados == Controller.Estados.iniciou)
            {
                Vector3 pos = Input.mousePosition;
                pos.z = 10;
                pos = Camera.main.ScreenToWorldPoint(pos);
                transform.position = pos;
            }

            if (Controller.instance.estados == Controller.Estados.naoComecou)
            {
                Controller.instance.estados = Controller.Estados.iniciou;
            }
        }
        if (!Input.GetMouseButton(0))
        {
            if (Controller.instance.estados == Controller.Estados.iniciou)
            {
                Controller.instance.estados = Controller.Estados.terminou;
            }
        }
    }
}


