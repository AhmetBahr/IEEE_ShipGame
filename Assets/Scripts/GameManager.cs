using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public static bool gameOver;
    public static bool gameOverAudio;
    public float sure=5f; // Ba�lang�� s�resi
    private float gecenSure; // Ge�en s�reyi tutmak i�in de�i�ken
    public Score score;
    public GameObject btnopen, btnclose; // ses a�ma kapama butonlar�
    bool soundactive;     // sesin a��k olup olmad���n� kontrol etme
    public AudioSource soundcontrol;   //m�zik kayna��
    public AudioSource soundcontrolClick;  //butona bas�ld���nda ��kan ses kayna��
    public AudioSource soundcontrolGameOver; // gameover ses kayna��


    [SerializeField] private RectTransform DeathMenu; // �l�m ekran�n� burada tan�ml�yoruz 
    [SerializeField] private RectTransform Menu; // Menu ekran�n� burada tan�ml�yoruz 
    [SerializeField] private RectTransform PlayPanel; // Menu ekran�n� burada tan�ml�yoruz 



    void Start()
    {
        gecenSure = sure;
        gameOver = true;
        soundcontrol.GetComponent<AudioSource>();
        soundactive = true;
        soundcontrolClick.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Player>().health<=0) //playerin can� o �n alt�na d��t�yse gameover true yap
        {
            gameOver = true;
            gameOverAudio = true;
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


    public void StartGame() //start butonuna t�kland���nda �al���r
    {
        Menu.DOAnchorPos(new Vector2(0, -1350), 0.4f);  //Tweeen ile men�y� bir �bje gibi hareket ettiriyoruz.
        PlayPanel.DOAnchorPos(new Vector2(0, 0), 0.4f);  //Tweeen ile men�y� bir �bje gibi hareket ettiriyoruz.
        gameOver = false;
        gameOverAudio = false;

        Player.SetActive(true);

    }

    public void Gameover()
    {

        DeathMenu.DOAnchorPos(new Vector2(0,0), 0.3f);  //Tweeen ile men�y� bir �bje gibi hareket ettiriyoruz.
        soundcontrol.mute = true;
        soundcontrolClick.mute = true;
    }
    public void Restart() //restart butonuna t�kland���nda �al���r.
    {
        /* PlayPanel.DOAnchorPos(new Vector2(0, 0), 0.4f);  //Tweeen ile men�y� bir �bje gibi hareket ettiriyoruz.
         gameOver=false;
         Player.GetComponent<Player>().health = 3;
         Player.SetActive(true);
         DeathMenu.DOAnchorPos(new Vector2(0, -1350), 0.3f);  //Tweeen ile men�y� bir �bje gibi hareket ettiriyoruz.
         score.ScoreRestart(); // score � s�f�rlama */
    }
    public void MainMenu()  //menu butonuna t�kland���nda �al���r.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // sahneyi ba�tan ba�latmak men�ye d�ner.
        gameOver=false;
        gameOverAudio = false;
        Player.GetComponent<Player>().health = 4;
    }
    public void SoundClick()  //ses a�ma kapama tu�lar�na onClick() metoduyla ba�l�
    {
        if (soundactive==true)  //ses kapama
        {
            btnopen.SetActive(false);  //ses a��k butonunu kapat
            btnclose.SetActive(true); //ses kapal� butonunu a�
            soundactive=false;
            soundcontrol.mute = true;
            soundcontrolClick.mute = true;
            soundcontrolGameOver.mute = true;
            //PlayerPrefs.SetInt("soundSituation", 0);
        }
        else  //ses a�ma
        {
            btnopen.SetActive(true); //ses a��k butonunu a�
            btnclose.SetActive(false); //ses kapal� butonunu kapat
            soundactive=true;
            soundcontrol.mute = false;
            soundcontrolClick.mute = false;
            soundcontrolGameOver.mute = false;
            //PlayerPrefs.SetInt("soundSituation", 1);
        }
            
    }

}
