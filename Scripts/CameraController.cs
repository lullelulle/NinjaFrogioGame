using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform player; //Pelaajan positio

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); //Kamera liikkuu pelaajan mukana
    }
}
