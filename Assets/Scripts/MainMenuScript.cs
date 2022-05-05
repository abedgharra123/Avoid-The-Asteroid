using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text highscore;
    private const string highScore = "HighScore";
    private void Start() {
        highscore.text = $"Highest Score : {PlayerPrefs.GetInt(highScore,0)}";
    }
    public void StartGame(){
        SceneManager.LoadScene("Scene_Game");
    }
}
