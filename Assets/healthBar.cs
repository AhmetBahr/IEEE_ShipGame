using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    Player player;
    public GameObject player1;
    // Start is called before the first frame update
    void Start()
    {

       //player = GameObject.FindWithTag("Player").GetComponent<Player>();
        image.sprite = sprites[4];
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.activeSelf && player==null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
        if (player!=null)
        {
        
        if (player.GetComponent<Player>().health==4)
        {
            image.sprite =sprites[4];
        }else if (player.GetComponent<Player>().health == 3)
        {
            image.sprite = sprites[3];
        }else if(player.GetComponent<Player>().health == 2)
        {
            image.sprite = sprites[2];
        }else if (player.GetComponent<Player>().health == 1)
        {
            image.sprite = sprites[1];
        }else if (player.GetComponent<Player>().health == 0)
        {
            image.sprite = sprites[0];
        }


        }
    }
}
