using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text lblScore;
    public Color InitialColor;
    public string textPrefix = "Score: ";


    private int CurrentScore =0;
    // Use this for initialization
    public void Start () {
        ResetScore();
    }
	
	// Update is called once per frame
	public void FixedUpdate () {
        lblScore.text = string.Format("{0} {1}", textPrefix, CurrentScore);
    }

    public void ResetScore()
    {
        lblScore.color = InitialColor;
        CurrentScore = 0;

    }

    public int GetCurrentScore()
    {
        return CurrentScore;
    }

    public void AddScore(int ScoreToAdd)
    {
        CurrentScore += ScoreToAdd;
    }
}

