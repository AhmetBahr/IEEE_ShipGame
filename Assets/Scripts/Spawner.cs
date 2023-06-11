using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] obstaclePatterns;
    private float timeBtwSpawn;
    [SerializeField] private float starttimeBtwSpawn;
    [SerializeField] private float decreaseTime; //azaltma zamaný
    [SerializeField] private float minTime;
    int rand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver==false) { //oyun bitmediyse can 0lanmadýysa
            rand = Random.Range(0, obstaclePatterns.Length);  //patterns dizisi uzunluðunda random deðer
            if (timeBtwSpawn <= 0)
            {
                Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);  //rastgele pattern oluþturma
                                                                                               //bu oluþturduðumuz objenin içinde spawnpoint scripti var onunla obstacle ý oluþturuyoz
                timeBtwSpawn = starttimeBtwSpawn;
                if (starttimeBtwSpawn > minTime)
                    starttimeBtwSpawn -= decreaseTime;
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
        
    }
}
