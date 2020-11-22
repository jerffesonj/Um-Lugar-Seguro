using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{

    public TMP_Text pointsText;
    public TMP_Text timeText;
    public TMP_Text astronautText;
    public TMP_Text highscoreText;

    // Update is called once per frame
    void Update()
    {
        pointsText.text = Controller.instance.points.ToString();
        timeText.text = Controller.instance.time.ToString();
        astronautText.text = Controller.instance.astronautSaved.ToString();
        highscoreText.text = Controller.instance.highscore.ToString();
    }
}
