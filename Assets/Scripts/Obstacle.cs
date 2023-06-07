using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    
    // Start is called before the first frame update
    private void Update()
    {
        if (GameManager.gameOver==false)  //oyun bitmediyse karakterin caný 0 olmadýysa
            transform.Translate(Vector2.left * speed * Time.deltaTime); // engelin sola doðru gitmesi
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().health -= damage; //oyuncunun caný damage ile azalýr
            Debug.Log(collision.GetComponent<Player>().health);
            Destroy(gameObject); //engel yok edilir
        }
    }

}
