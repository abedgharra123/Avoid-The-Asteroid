using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button continueButton;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private TMP_Text GameOverScore;
    [SerializeField] private Spawner StoneSpawner;
    [SerializeField] private GameObject GameOverDisplay;
    [SerializeField] private TMP_Text HighestScore;

    private const string highScore = "HighScore";

    private void Start() {
        HighestScore.text = $"Highest Score : {PlayerPrefs.GetInt(highScore,0)}";
    }
    public void EndGame(){
        StoneSpawner.enabled = false;
        
        int score = scoreSystem.EndGame();
        GameOverScore.text = "Youe Score : "+score;

        
        
        GameOverDisplay.gameObject.SetActive(true);
    }
    public void PlayAgain(){
        SceneManager.LoadScene(1);
    }
    public void Menu(){
        SceneManager.LoadScene(0);
    }

    public void ContinueButton(){
        AdManager.instance.ShowAd(this);
        continueButton.interactable = false;
    }

    public void ContinueGame()
    {
        scoreSystem.StartTimer();
        StoneSpawner.enabled = true;
        GameOverDisplay.gameObject.SetActive(false);
        
        player.transform.position = Vector3.zero;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.SetActive(true);

    }
}
