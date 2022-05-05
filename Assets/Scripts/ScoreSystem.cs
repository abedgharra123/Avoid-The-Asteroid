using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text score; 
    [SerializeField] private float scoreMultiplier;
    private float int_score;

    private bool count = true;

    private const string highScore = "HighScore";


    // Update is called once per frame
    void Update()
    {
        if (!count) return;
        int_score += Time.deltaTime*scoreMultiplier;
        score.text = ((int)int_score).ToString();
    }

    public int EndGame(){
        count = false;
        score.text = string.Empty;
        int OldScore = PlayerPrefs.GetInt(highScore,0);
        if (int_score > OldScore){
            PlayerPrefs.SetInt(highScore,(int)int_score);
        }
        return (int)int_score;
    }

    internal void StartTimer()
    {
        count = true;
        
    }
}
