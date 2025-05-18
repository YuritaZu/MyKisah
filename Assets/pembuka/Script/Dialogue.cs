using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI IsiText;
    public GameObject PanelText;
    public string[] dialogue;
    private int index;

    public GameObject Button;
    public float speedText;
    public bool openPanel;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (PanelText.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                PanelText.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(IsiText.text == dialogue[index])
        {
            Button.SetActive(true);
        }
    }

    public void ZeroText()
    {
        IsiText.text = "";
        index = 0;
        PanelText.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            IsiText.text += letter;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void Next()
    {

        Button.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            IsiText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }

    private void OnEnter()
    {
        if (!openPanel)
        {
            openPanel = true;
        }
    }

    private void OnExit()
    {
        if (!openPanel)
        {
            openPanel = false;
            ZeroText();
        }
    }
}
