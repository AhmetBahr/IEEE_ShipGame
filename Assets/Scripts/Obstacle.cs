using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;


    [SerializeField] private GameObject point;
    private float zAngle;
   // public AudioSource soundSource;
   // public AudioClip clip;

    private void Start()
    {
        
        Destroy(gameObject,10); // nesneyi 10 saniye sonra yok etmek i�in
        //soundSource = GetComponent<AudioSource>();
        //soundSource.clip=clip;
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (GameManager.gameOver==false)  //oyun bitmediyse karakterin can� 0 olmad�ysa
            transform.Translate(Vector2.left * speed * Time.deltaTime); // engelin sola do�ru gitmesi

        //A�a��daki kodu �al��t�rmak i�in 
        turnAround();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //soundSource.Play(); // normalde burda �arp��ma sesini vermesi laz�md� �al��m�yor.
            collision.GetComponent<Player>().health -= damage; //oyuncunun can� damage ile azal�r
            Debug.Log(collision.GetComponent<Player>().health);
            Camera.main.DOShakePosition(1,1,fadeOut:true);
            Camera.main.DOShakeRotation(1, 1, fadeOut: true);
            Destroy(gameObject); //engel yok edilir
        }
    }

    private void turnAround()
    {
        //Nesneyi kendi etraf�nda d�nmesini sa�lar
        point.transform.DORotate(new Vector3(0, 0, zAngle + 15), 1, RotateMode.WorldAxisAdd);

    }
}
