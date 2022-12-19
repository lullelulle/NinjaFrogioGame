using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndMenu : MonoBehaviour
{
    private bool pressed;
    public Animator fadeAnim;
    public void Quit()
    {
        Application.Quit(); //sammuttaa pelin
    }

    public void Menu()
    {
        if (pressed == false)
        {
            pressed = true;
            fadeAnim.SetTrigger("ChangeScene");
            Invoke("ChangeToLevel", 2f);
        }
    }

    private void ChangeToLevel()
    {
        SceneManager.LoadScene("Start Screen"); //takaisin menuun
    }
}
