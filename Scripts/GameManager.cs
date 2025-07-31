using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int score;
    public Text textScore;

    // Update is called once per frame
    public void AddScore()
    {
        score++;
        textScore.text = score.ToString();
    }
}
