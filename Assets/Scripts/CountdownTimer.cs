using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public Text lblTimer;
    public float time = 120; //time in seconds per round
    public float CriticalTime = 10.0f;
    public Color InitialColor;
    public Color CriticlaColor;


    public void Start()
    {
        ResetColor();
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        time -= Time.deltaTime;

        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        var ms = (time * 1000) % 1000;

        //critical time, change color
        if (time <= CriticalTime)
        {
            lblTimer.color = CriticlaColor;
            

        }

        if (time > 0)
        {
            lblTimer.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, ms);
        }
        else
        {
            lblTimer.text = "0:00:000";
            this.enabled = false;
        }
    }

    public void ResetColor()
    {
        lblTimer.color = InitialColor;
      
    }
}
