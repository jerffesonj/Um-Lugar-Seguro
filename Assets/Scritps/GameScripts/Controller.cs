using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public static Controller Instance { get { return instance; } }

    public static Controller instance;
    public GameObject player;

    private GameObject painelGameover;

    public float time;
    float timefloat;

    public int points;
    public int astronautSaved;

    public int highscore;
    public int nextscore = 5000;
    public float timetoreducespawn = 0;
    public float aumentarspeed=0;

    public float tempoNoCheck = 0;

    public enum Estados
    {
        iniciou,
        terminou,
        naoComecou,
        noCheckpoint
    }
    public Estados estados;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance!= this)
        {
            Destroy(gameObject);
        }
        estados = Estados.naoComecou;
        points = 0;
    }

    private void Start()
    {
        
    }

    void Update()
    {

        highscore = PlayerPrefs.GetInt("Score", 0);

        

        switch (estados)
        {
            case Estados.iniciou:

                timefloat += Time.deltaTime;
                time = Mathf.RoundToInt(timefloat);

                points += 1;

                break;

            case Estados.terminou:

                print("cabou");
                print("dead");
                player.SetActive(false);
                
                
                if(points > highscore)
                {
                    PlayerPrefs.SetInt("Score", points);
                }


                painelGameover = GameObject.FindGameObjectWithTag("GameOver");
                if (painelGameover)
                {
                    painelGameover.GetComponent<GameOver>().painel.SetActive(true);
                    painelGameover.GetComponent<GameOver>().pointsTxt.text = points.ToString();
                }
                player.SetActive(false);
                //points = 0;

                //estados = Estados.naoComecou;
                //player.SetActive(true);
                //timefloat = 0;
                //time = 0;


                break;
            case Estados.noCheckpoint:
                print("check da massa");
                
                tempoNoCheck += Time.deltaTime;
                

                break;
            case Estados.naoComecou:
                player.SetActive(true);
                points = 0;
                astronautSaved = 0;
                break;
        }


        if (points >= nextscore)
        {
            nextscore += 5000;
            timetoreducespawn += 0.05f;
        }
    }


}
