using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public static bool gameOver;
    public float sure=5f; // Baþlangýç süresi
    private float gecenSure; // Geçen süreyi tutmak için deðiþken
    public Score score;


    [SerializeField] private RectTransform DeathMenu; // Ölüm ekranýný burada tanýmlýyoruz 

    void Start()
    {
        gecenSure = sure;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Player>().health<=0) //playerin caný o ýn altýna düþtüyse gameover true yap
        {
            gameOver = true;
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


    public void Gameover()
    {

        DeathMenu.DOAnchorPos(new Vector2(0,0), 0.3f);  //Tweeen ile menüyü bir öbje gibi hareket ettiriyoruz.

    }

}
