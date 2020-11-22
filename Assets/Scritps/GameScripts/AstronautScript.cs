using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AstronautScript : MonoBehaviour
{
    public GameObject AstroAnimCanvas;
    public GameObject explosao;

    public AudioClip audioClip;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        print("ok");
    //        Controller.instance.astronautSaved += 1;

    //        GameObject obj = Instantiate(AstroAnimCanvas, this.transform);
    //        obj.GetComponentInChildren<TMP_Text>().text = "+1";
    //        obj.transform.parent = obj.transform.parent.parent;

    //        Destroy(gameObject);
    //    }
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Astronaut"))
    //    {
    //        print("astro");

    //        GameObject explosaoClone = Instantiate(explosao, this.transform);
    //        explosaoClone.transform.parent = explosaoClone.transform.parent.parent;

    //        Destroy(collision.gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.CompareTag("Astronaut"))
            {
                print("ok");
                Controller.instance.astronautSaved += 1;

                GameObject obj = Instantiate(AstroAnimCanvas, this.transform);
                obj.GetComponentInChildren<TMP_Text>().text = "+1";
                obj.transform.SetParent(obj.transform.parent.parent);

                var audioSource = collision.gameObject.GetComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.Play();

                Destroy(gameObject);
            }

            if (this.CompareTag("GoldAstronaut"))
            {
                print("ok");
                Controller.instance.astronautSaved += 3;

                GameObject obj = Instantiate(AstroAnimCanvas, this.transform);
                obj.GetComponentInChildren<TMP_Text>().text = "+3";
                obj.transform.SetParent(obj.transform.parent.parent);

                var audioSource = collision.gameObject.GetComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.Play();

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Astronaut") || collision.gameObject.CompareTag("GoldAstronaut"))
        {
            print("astro");

            GameObject explosaoClone = Instantiate(explosao, this.transform);
            explosaoClone.transform.parent = explosaoClone.transform.parent.parent;

            Destroy(collision.gameObject);
        }
    }
}

   
