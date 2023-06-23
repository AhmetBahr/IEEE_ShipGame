using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public static bool gameOver;
    public float sure=5f; // Ba�lang�� s�resi
    private float gecenSure; // Ge�en s�reyi tutmak i�in de�i�ken
    public Score score;
    public GameObject gameOverPanel;
    void Start()
    {
        gecenSure = sure;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Player>().health<=0) //playerin can� o �n alt�na d��t�yse gameover true yap
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
        }
        if(gameOver==false) //oyun bitmediyse skoru artt�r oyun bittiyse artt�rma
            addScore();
    }
    void addScore()
    {
        // Zaman� kontrol et
        if (gecenSure <= 0f)
        {
            gecenSure = sure;

            //gecenSure -= Time.deltaTime;
            score.Scored();  // belli bir saniye arayla oyuncuya puan ekliyor 
        }
        else
            gecenSure -= Time.deltaTime;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOver = false;
        Player.GetComponent<Player>().health = 3;
    } 
    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        gameOver= false;
        Player.GetComponent<Player>().health = 3;
    }
}
