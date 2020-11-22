using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    public bool utilizado = false;
    public GameObject pointsAnimCanvas;

    public GameObject explosao;

    [Header("Audios Clips")]
    public AudioClip naveSaindo;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!utilizado)
            {
                print("stop");
                Controller.instance.estados = Controller.Estados.noCheckpoint;

                GetComponent<SpritesMoviments>().enabled = false;

                if (Controller.instance.tempoNoCheck >= 2)
                {
                    OnCollisionExit2D(collision);

                    var audioSource = collision.gameObject.GetComponent<AudioSource>();
                    audioSource.clip = naveSaindo;
                    audioSource.Play();
                }
            }
        }

        if (collision.gameObject.CompareTag("Meteor") ||
        collision.gameObject.CompareTag("Astronaut"))
        {
            GameObject explosaoClone = Instantiate(explosao, this.transform);
            explosaoClone.transform.parent = explosaoClone.transform.parent.parent;
            StartCoroutine(CameraShake.instance.Shake(0.2f, 0.2f));
            print("isso");
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Controller.instance.tempoNoCheck >= 2)
            {

                GetComponent<SpritesMoviments>().enabled = true;
                this.utilizado = true;

                //if (Input.GetMouseButtonDown(0))
                //{
                Controller.instance.estados = Controller.Estados.iniciou;
                //}
                //else
                //{
                //    Controller.instance.estados = Controller.Estados.terminou;
                //}
                Controller.instance.tempoNoCheck = 0;
                GameObject obj = Instantiate(pointsAnimCanvas, this.transform);

                obj.GetComponentInChildren<TMP_Text>().text = "+" + (1000 * Controller.instance.astronautSaved).ToString();
                Controller.instance.points = Controller.instance.points + (1000 * Controller.instance.astronautSaved);
                Controller.instance.astronautSaved = 0;
            }
        }
    }
}
