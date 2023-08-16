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
       // gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>(); // oyun içersinden  "GameManager" tagli objeyi bulmak için 
                                                                                         //Farklý objeler içersindeki kodlara ulaþmak için kullandýðým bir metot
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
