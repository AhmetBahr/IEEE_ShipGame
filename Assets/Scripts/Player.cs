using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;  // hedef pozisyon
    public float yIncrement;    // y yönündeki artýþ
    public float speed;         //y yönündeki artýþ hýzý 
    public int health;          //karakter saðlýðý

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>(); // oyun içersinden  "GameManager" tagli objeyi bulmak için 
            //Farklý objeler içersindeki kodlara ulaþmak için kullandýðým bir metot     

        health = 4;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver==false) //oyun bitmediyse karakterin caný 0 olmadýysa
        //playerin pozisyonunu hedef pozisyon yapýyoruz yani karakteri hareket ettirdiðimiz kod
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed* Time.deltaTime); 

        if(health <= 0)
        {
            gameObject.SetActive(false); //  oyuncunun caný kalmdýðý zaman görünümü kapat 
            gameManager.Gameover(); // yukarýda oluþturduðumuz nesne içersindeki fonksiyonu çalýþtýrýyoruz 

        }

    }
    /// <summary>
    /// butona týklandýðýnda yukarý hareket etme
    /// </summary>
    public void Upclick() 
    {
        //-y eksenindeyse veya y=0 ise yukarý doðru hareket et (çift týklamayý ve ekrandan çýkmayý engellemek için)
        if (transform.position.y == 0 || transform.position.y == -yIncrement) 
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
    }
    /// <summary>
    /// butona týklandýðýnda aþaðý hareket etme
    /// </summary>
    public void DownClick()
    {
        //+y eksenindeyse veya y=0 ise aþaðý doðru hareket et (çift týklamayý ve ekrandan çýkmayý engellemek için)
        if (transform.position.y==0 || transform.position.y == yIncrement)
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
    }
    
}
