using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private Animator fadeAnim;
    private AudioSource finishSound;
    private Animator flagAnim;
    private bool levelCompleted = false;
    private void Start()
    {
        flagAnim = GetComponent<Animator>();
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted) //jos pelaaja koskettaa lippua ja bool levelCompleted on false
        {
            Invoke("StartFade", 0.5f);
            flagAnim.SetTrigger("Touched");
            levelCompleted = true; //vaihtaa muuttujan levelCompleted trueksi jotta tämä functio ei käynnisty uudestaan
            finishSound.Play(); //soittaa äänen
            Invoke("CompleteLevel", 2f); //odottaa 2 sekunttia ennenkuin vaihtaa scenen
        }
    }

    private void StartFade()
    {
        fadeAnim.SetTrigger("ChangeScene"); //käynnistää fade animaation
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
