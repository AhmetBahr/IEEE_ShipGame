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
        
        Destroy(gameObject,10); // nesneyi 10 saniye sonra yok etmek için
        //soundSource = GetComponent<AudioSource>();
        //soundSource.clip=clip;
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (GameManager.gameOver==false)  //oyun bitmediyse karakterin caný 0 olmadýysa
            transform.Translate(Vector2.left * speed * Time.deltaTime); // engelin sola doðru gitmesi

        //Aþaðýdaki kodu çalýþtýrmak için 
        turnAround();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //soundSource.Play(); // normalde burda çarpýþma sesini vermesi lazýmdý çalýþmýyor.
            collision.GetComponent<Player>().health -= damage; //oyuncunun caný damage ile azalýr
            Debug.Log(collision.GetComponent<Player>().health);
            Camera.main.DOShakePosition(1,1,fadeOut:true);
            Camera.main.DOShakeRotation(1, 1, fadeOut: true);
            Destroy(gameObject); //engel yok edilir
        }
    }

    private void turnAround()
    {
        //Nesneyi kendi etrafýnda dönmesini saðlar
        point.transform.DORotate(new Vector3(0, 0, zAngle + 15), 1, RotateMode.WorldAxisAdd);

    }
}
