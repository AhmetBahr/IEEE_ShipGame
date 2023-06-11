using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    //Knk burasý çok gereksiz olmuþ, düþünce güzel ama C# ile bunu tek kod ile yapabiliyorz. Diðer kod satýrýnda (obstacle) yaptým 

    public float sure; // Baþlangýç süresi
    private float gecenSure; // Geçen süreyi tutmak için deðiþken
    private bool zamanDoldu; // Zamanýn dolduðunu kontrol etmek için deðiþken    

    private void Start()
    {
        gecenSure = sure;
        zamanDoldu = false;
    }

    private void Update()
    {
        if (!zamanDoldu)
        {
            // Zamaný azalt
            gecenSure -= Time.deltaTime;

            // Zamaný kontrol et
            if (gecenSure <= 0f)
            {
                gecenSure = 0f;
                zamanDoldu = true;
                ZamanDoldu();
            }

            
        }
    }

    private void ZamanDoldu()
    {
        Destroy(gameObject);  // obstacle objesini ve obstacle pattern objelerini yok ediyor.
        
    }

}
