using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{

    public GameObject explosao;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        print("player");

    //        if (Controller.instance.estados != Controller.Estados.noCheckpoint)
    //        {
    //            GameObject explosaoClone = Instantiate(explosao, collision.transform);
    //            explosaoClone.transform.parent = explosaoClone.transform.parent.parent;
    //            print("ok fim");
    //            Controller.instance.estados = Controller.Estados.terminou;
    //        }
    //    }
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Astronaut"))
    //    {
    //        GameObject explosaoClone = Instantiate(explosao, collision.transform);
    //        explosaoClone.transform.parent = explosaoClone.transform.parent.parent;

    //        Destroy(collision.gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("player");

            if (Controller.instance.estados != Controller.Estados.noCheckpoint)
            {
                StartCoroutine(CameraShake.instance.Shake(0.2f, 0.2f));
                GameObject explosaoClone = Instantiate(explosao, collision.transform);
                explosaoClone.transform.parent = explosaoClone.transform.parent.parent;
                print("ok fim");
                StartCoroutine(GameOver());

                collision.gameObject.GetComponent<Movement>().gameOver = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Astronaut"))
        {
            GameObject explosaoClone = Instantiate(explosao, collision.transform);
            explosaoClone.transform.parent = explosaoClone.transform.parent.parent;
            StartCoroutine(CameraShake.instance.Shake(0.2f, 0.2f));
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        Controller.instance.estados = Controller.Estados.terminou;
    }
}
