using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudio : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip clip;
    bool noise;
    //GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        noise = false;
       // gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>(); // oyun i�ersinden  "GameManager" tagli objeyi bulmak i�in 
                                                                                         //Farkl� objeler i�ersindeki kodlara ula�mak i�in kulland���m bir metot
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOverAudio==true && noise==false)
        {
            noise=true;
            soundSource.PlayOneShot(clip);           
        }
    }
}
