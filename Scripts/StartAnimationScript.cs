using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartAnimationScript : MonoBehaviour
{
    public Animator fadeAnim;
    public int Time;
    private bool canSkip = false;
    void Start()
    {
        Invoke("setCanSkip", 3);
        Invoke("fadeAnimation", Time -3);
        Invoke("ChangeScene", Time);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && canSkip)
        {
            fadeAnimation();
            Invoke("ChangeScene", 2f);
        }
    }

    private void setCanSkip()
    {
        canSkip = true;
    }
    private void fadeAnimation()
    {
        canSkip = false;
        fadeAnim.SetTrigger("ChangeScene");
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
