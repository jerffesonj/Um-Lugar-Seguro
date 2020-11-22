using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public bool play = false;

    public GameObject[] prefabObg;
    public float timeSpawn;
    public float currentTime;

    public bool posRandom = false;
    public float posicaoMaxY;
    public float posicaoMinY;

    public bool timeRandom = false;
    public float timeMax;
    public float TimeMin;

    public bool obstaculo = false;

    private float posicao;

    public bool inHomeScene = false;

    void Start()
    {
        if (timeRandom)
        {
            timeSpawn = Random.Range(TimeMin, timeMax);
        }
    }

    void Update() {

        if (Controller.instance != null)
        {
            if (Controller.instance.points >= Controller.instance.nextscore)
            {
                timeMax = timeMax - Controller.instance.timetoreducespawn;
                TimeMin = TimeMin - Controller.instance.timetoreducespawn;
            }
        }
        if (timeMax <= 1)
        {
            timeMax = 1;
        }
        if (TimeMin <= 0.5)
        {
            TimeMin = 0.5f;
        }

        if (!inHomeScene)
        {
            if (Controller.instance.estados == Controller.Estados.iniciou)
            {
                PlaySpawn();
            }
            if (Controller.instance.estados == Controller.Estados.terminou)
            {
                StopSpawn();
            }
        }

        if (play)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timeSpawn)
            {
                currentTime = 0;
                GameObject tempPrefab = Instantiate(prefabObg[Random.Range(0, prefabObg.Length)], transform, false) as GameObject;
                if (posRandom)
                {
                    posicao = Random.Range(posicaoMinY, posicaoMaxY);
                    tempPrefab.transform.position = new Vector3(transform.position.x, posicao, tempPrefab.transform.position.z);
                }
                else
                {
                    tempPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, tempPrefab.transform.position.z);
                }

                if (timeRandom)
                {
                    timeSpawn = Random.Range(TimeMin, timeMax);
                }

            }
        }
        
    }

    public void PlaySpawn()
    {
        play = true;
    }

    public void StopSpawn()
    {
        play = false;
    }

    public void SingleSpawn()
    {
        GameObject tempPrefab = Instantiate(prefabObg[Random.Range(0, prefabObg.Length)]) as GameObject;
        tempPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void NotSingleSpawn(int level)
    {
        GameObject tempPrefab = Instantiate(prefabObg[level]) as GameObject;
        tempPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}