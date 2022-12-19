using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool IsPaused;
    void Start()
    {
        IsPaused = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false); //pausemenu objekti
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) //jos painaa escape
        {
            if (IsPaused == false) //jos peli ei ole pausetettu
            {
                Debug.Log("GAME PAUSED");
                PauseGame();
            }
            else
            {
                Debug.Log("GAME RESUMED");
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true); //laittaa menun näkyviin
        Time.timeScale = 0f; //pysäyttää pelin
        IsPaused = true;
    }

    public void ResumeGame()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false); //laittaa menun pois näkyvistä
        Time.timeScale = 1f; //jatkaa pelin kulkua
        IsPaused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen"); //menee takaisin start menuun
    }

    public void Quit()
    {
        Application.Quit(); //sammuttaa pelin
    }
}
