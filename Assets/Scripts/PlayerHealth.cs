using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameOverHandler gameOverHandler;
    public void Crash(){
        AudioManager.instance.Play("Crash");
        gameOverHandler.EndGame(); 
        gameObject.SetActive(false);
    }
}
