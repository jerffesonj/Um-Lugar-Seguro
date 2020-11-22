using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    [Header("Buttons")]
    public Button startBtn;
    public Button creditsBtn;
    public Button returnCreditsBtn;
    public Button optionsBtn;

    [Header("Paineis")]
    public GameObject creditsPainel;

    void Start ()
    {
        creditsBtn.onClick.AddListener(delegate
        {
            creditsPainel.SetActive(true);
        });

        returnCreditsBtn.onClick.AddListener(delegate
        {
            creditsPainel.SetActive(false);
        });
    }
	
}
