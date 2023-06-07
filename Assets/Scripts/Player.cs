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
    private void Start()
    {
        health = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver==false) //oyun bitmediyse karakterin caný 0 olmadýysa
        //playerin pozisyonunu hedef pozisyon yapýyoruz yani karakteri hareket ettirdiðimiz kod
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed* Time.deltaTime); 

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
