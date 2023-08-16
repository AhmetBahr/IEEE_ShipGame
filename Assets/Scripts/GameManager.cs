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
    public float sure=5f; // Baþlangýç süresi
    private float gecenSure; // Geçen süreyi tutmak için deðiþken
    public Score score;
    public GameObject btnopen, btnclose; // ses açma kapama butonlarý
    bool soundactive;     // sesin açýk olup olmadýðýný kontrol etme
    public AudioSource soundcontrol;   //müzik kaynaðý
    public AudioSource soundcontrolClick;  //butona basýldýðýnda çýkan ses kaynaðý
    public AudioSource soundcontrolGameOver; // gameover ses kaynaðý


    [SerializeField] private RectTransform DeathMenu; // Ölüm ekranýný burada tanýmlýyoruz 
    [SerializeField] private RectTransform Menu; // Menu ekranýný burada tanýmlýyoruz 
    [SerializeField] private RectTransform PlayPanel; // Menu ekranýný burada tanýmlýyoruz 



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
        if (Player.GetComponent<Player>().health<=0) //playerin caný o ýn altýna düþtüyse gameover true yap
        {
            gameOver = true;
            gameOverAudio = true;
        }
        if(gameOver==false) //oyun bitmediyse skoru arttýr oyun bittiyse arttýrma
            addScore();
    }
    void addScore()
    {
        // Zamaný kontrol et
        if (gecenSure <= 0f)
        {
            gecenSure = sure;

            //gecenSure -= Time.deltaTime;
            score.Scored();  // belli bir saniye arayla oyuncuya puan ekliyor 
        }
        else
            gecenSure -= Time.deltaTime;
    }


    public void StartGame() //start butonuna týklandýðýnda çalýþýr
    {
        Menu.DOAnchorPos(new Vector2(0, -1350), 0.4f);  //Tweeen ile menüyü bir öbje gibi hareket ettiriyoruz.
        PlayPanel.DOAnchorPos(new Vector2(0, 0), 0.4f);  //Tweeen ile menüyü bir öbje gibi hareket ettiriyoruz.
        gameOver = false;
        gameOverAudio = false;

        Player.SetActive(true);

    }

    public void Gameover()
    {

        DeathMenu.DOAnchorPos(new Vector2(0,0), 0.3f);  //Tweeen ile menüyü bir öbje gibi hareket ettiriyoruz.
        soundcontrol.mute = true;
        soundcontrolClick.mute = true;
    }
    public void Restart() //restart butonuna týklandýðýnda çalýþýr.
    {
        /* PlayPanel.DOAnchorPos(new Vector2(0, 0), 0.4f);  //Tweeen ile menüyü bir öbje gibi hareket ettiriyoruz.
         gameOver=false;
         Player.GetComponent<Player>().health = 3;
         Player.SetActive(true);
         DeathMenu.DOAnchorPos(new Vector2(0, -1350), 0.3f);  //Tweeen ile menüyü bir öbje gibi hareket ettiriyoruz.
         score.ScoreRestart(); // score ý sýfýrlama */
    }
    public void MainMenu()  //menu butonuna týklandýðýnda çalýþýr.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // sahneyi baþtan baþlatmak menüye döner.
        gameOver=false;
        gameOverAudio = false;
        Player.GetComponent<Player>().health = 4;
    }
    public void SoundClick()  //ses açma kapama tuþlarýna onClick() metoduyla baðlý
    {
        if (soundactive==true)  //ses kapama
        {
            btnopen.SetActive(false);  //ses açýk butonunu kapat
            btnclose.SetActive(true); //ses kapalý butonunu aç
            soundactive=false;
            soundcontrol.mute = true;
            soundcontrolClick.mute = true;
            soundcontrolGameOver.mute = true;
            //PlayerPrefs.SetInt("soundSituation", 0);
        }
        else  //ses açma
        {
            btnopen.SetActive(true); //ses açýk butonunu aç
            btnclose.SetActive(false); //ses kapalý butonunu kapat
            soundactive=true;
            soundcontrol.mute = false;
            soundcontrolClick.mute = false;
            soundcontrolGameOver.mute = false;
            //PlayerPrefs.SetInt("soundSituation", 1);
        }
            
    }

}
