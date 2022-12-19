using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private Animator fadeAnim;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")) //jos pelaaja koskettaa ansaan
        {
            Die();
        }
    }

    private void Die()
    {
        fadeAnim.SetTrigger("ChangeScene"); //käynnistää fade animaation
        deathSoundEffect.Play(); //soittaa äänen
        rb.bodyType = RigidbodyType2D.Static; //pysäyttää pelaajan liikkeen
        anim.SetTrigger("death"); //pelaajan kuolema animaatio
    }

    private void RestartLevel() //tämä functio käynnistyy kuolema animaation päätyttyä
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //lataa saman scenen alusta
    }
}