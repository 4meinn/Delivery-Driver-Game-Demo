using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage; // Paketlerin alınıp alınmadığını kontrol edebilmek için (true - false) bool mantıksal operatörünü kullandık.

    SpriteRenderer spRenderer; //spRenderer isminde bir SpriteRenderer tanımladık. 

    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();
    }

    /* void'in önündeki private'i kaldırdık, çünkü diğer classlarda da kullanacağız. */ 
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Hay Aksi!"); // Aracımız, sınırları olan herhangi bir yere çarptığında konsola yazdır.
    }

     void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage) // Üzerine geldiğin nesne "Package" etiketine sahipse ve haspackage değerin yok (false) ise,
        {
            Debug.Log("Paket alındı."); 
            hasPackage = true; // Paket alındıysa true değerini ata.
            spRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay); // Paket alındığında objeyi kaldır.
        }

        if (other.tag == "Customer" && hasPackage) // Üzerine geldiğin nesne "Customer" etiketine sahipse ve haspackage değerin var (true) ise,
        {
            Debug.Log("Paket teslim edildi.");
            hasPackage = false; // Paket teslim edildiyse false değerini ata aksi halde paket sürekli olarak alınmış gözükecek ve oyuncu paketi tekrar tekrar teslim edebilecek.
            spRenderer.color = noPackageColor;
        }
    }
}
