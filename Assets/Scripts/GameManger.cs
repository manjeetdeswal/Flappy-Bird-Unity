using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    private int score;
    public Text text;
    public GameObject button;
    public GameObject gameOver;
    public Player player;


    private void Awake()
    {
        Pause();
    }

   public void Play()
    { 
        score =0;
        text.text = score + "";
        button.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipies[] pipe = FindObjectsOfType<Pipies>();

        foreach(Pipies pip in pipe)
        {
            Destroy(pip.gameObject);
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }
    public void IncreaseSc()
    {
        score++;
        text.text = score +"";
    }

   public void GameOver()
    {
        Debug.Log("GAme Over");
        player.audioSource.Stop();
        button.SetActive(true);
        gameOver.SetActive(true);

        Pause();

    }

    
    void Start()
    {
        
    }

  
}
