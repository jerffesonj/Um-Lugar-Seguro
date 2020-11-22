using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameScene : MonoBehaviour
{
    public Button startBtn;
    Animator an;

    public bool restart = false;

    private void Start()
    {
        an = GetComponent<Animator>();

        startBtn.onClick.AddListener(delegate 
        {
            if (!restart)
                StartAnimation();
            else
                GoToHomeScene();
        });
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    private void StartAnimation()
    {
        if (an) an.SetTrigger("Close");
        else GoToGameScene();
    }

    private void GoToHomeScene()
    {
        Controller.instance.estados = Controller.Estados.naoComecou;
        SceneManager.LoadScene("Home");
    }

}
