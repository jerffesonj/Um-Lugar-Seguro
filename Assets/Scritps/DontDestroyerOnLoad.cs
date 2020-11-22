using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyerOnLoad : MonoBehaviour
{
    public static DontDestroyerOnLoad instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

}
