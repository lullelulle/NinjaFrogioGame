using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMode : MonoBehaviour
{
    PlayerMovement player;

    ItemCollector item;
    SpriteRenderer sprite;

    private bool shadowModeAccess = true;

    public ParticleSystem shadowPS;
    public ParticleSystem shadowStartPS;
    void Start()
    {
        item = GetComponent<ItemCollector>();
        player = GetComponent<PlayerMovement>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("ShadowMode") && shadowModeAccess == true && item.cherries > 0)
        {
            ShadowModeOn();
        }

    }
    
    private void ShadowModeOn()
    {
        shadowStartPS.Play();
        shadowPS.Play();
        player.Speed = 8f;
        player.maxDoubleJumps = 2;
        sprite.color = new Color (0, 0, 0, 0.5f);
        shadowModeAccess = false;
        Invoke("ShadowModeOff", item.cherries);
        item.cherries = 0;
        item.update_text();
    }

    private void ShadowModeOff()
    {
        shadowPS.Stop();
        player.Speed = 5f;
        player.maxDoubleJumps = 1;
        sprite.color = new Color (1, 1, 1, 1);
        shadowModeAccess = true;
    }
}
