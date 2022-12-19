using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int cherries = 0;
    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry")) //Jos pelaaja koskee kirsikkaan
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject); //Tuhoaa kirsikan
            cherries++; //Lisää cherries muuttujaan +1
            update_text();
            
        }
    }

    public void update_text()
    {
        cherriesText.text = "Cherries: " + cherries; //Päivittää tekstin
    }
}