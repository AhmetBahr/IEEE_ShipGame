using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highscore;
    public TMP_Text scoretable;  // canvas score text
    public TMP_Text highscoretable; // canvas highscore text

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
        
        scoretable.text = score.ToString(); //score ý text e yazýyor
        highscore = PlayerPrefs.GetInt("highscore"); //playerprefs den highscore deðiþkenini çekiyor ve highscore a eþitliyor.
        highscoretable.text = highscore.ToString();  // highscore ý text e yazýyor.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Scored()
    {
        score++; //score ý artýr
        scoretable.text = score.ToString();
        if (score > highscore) //score highscore dan büyükse playerprefsdeki highscore ý score a güncelle texte yaz
        {
            highscore = score;
            highscoretable.text = highscore.ToString();
            PlayerPrefs.SetInt("highscore", highscore);
        } 
    }
}
