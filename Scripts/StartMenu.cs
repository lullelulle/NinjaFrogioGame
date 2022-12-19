using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Animator FadeAnim;
    [SerializeField] Animator MusicAnim;

    [SerializeField] Animator FrogAnim;
    private bool pressed = false;
    public void StartGame()
    {
        if (pressed == false)
        {
            pressed = true;
            FrogAnim.SetTrigger("StartGame");
            FadeAnim.SetTrigger("ChangeScene");
            MusicAnim.SetTrigger("FadeOut");
            Invoke("ChangeToLevel", 2f);
        }
    }

    private void ChangeToLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
