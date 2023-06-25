using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public static bool gameOver;
    public float sure=5f; // Ba�lang�� s�resi
    private float gecenSure; // Ge�en s�reyi tutmak i�in de�i�ken
    public Score score;


    [SerializeField] private RectTransform DeathMenu; // �l�m ekran�n� burada tan�ml�yoruz 
    [SerializeField] private RectTransform Menu; // Menu ekran�n� burada tan�ml�yoruz 
    [SerializeField] private RectTransform PlayPanel; // Menu ekran�n� burada tan�ml�yoruz 



    void Start()
    {
        gecenSure = sure;
        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Player>().health<=0) //playerin can� o �n alt�na d��t�yse gameover true yap
        {
            gameOver = true;
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


    public void StartGame()
    {
        Menu.DOAnchorPos(new Vector2(0, -1350), 0.4f);  //Tweeen ile men�y� bir �bje gibi hareket ettiriyoruz.
        PlayPanel.DOAnchorPos(new Vector2(0, 0), 0.4f);  //Tweeen ile men�y� bir �bje gibi hareket ettiriyoruz.
        gameOver = false;

        Player.SetActive(true);

    }

    public void Gameover()
    {

        DeathMenu.DOAnchorPos(new Vector2(0,0), 0.3f);  //Tweeen ile men�y� bir �bje gibi hareket ettiriyoruz.

    }

}
