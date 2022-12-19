using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TEXT : MonoBehaviour
{
    public Text text;
    public Image img;
    void Start()
    {
        TextEnabled(false);
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);
        TextSpeech("Im hungry!!!");
        yield return new WaitForSeconds(4);
        TextEnabled(false);
        yield return new WaitForSeconds(2);
        TextSpeech("I want to eat yummy cherries...");
        yield return new WaitForSeconds(4);
        TextEnabled(false);
        yield return new WaitForSeconds(3);
        TextSpeech("I need to find yummy cherries.");
        yield return new WaitForSeconds(4);
        TextEnabled(false);  
    }
    private void TextEnabled(bool setting)
    {
        img.enabled = setting;
        text.enabled = setting;
    }

    private void TextSpeech(string speech)
    {
        img.enabled = true;
        text.enabled = true;
        text.text = speech;
    }
}
