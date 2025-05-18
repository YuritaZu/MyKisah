using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartSelect : MonoBehaviour
{
    public TextMeshProUGUI IsiText;
    public GameObject PanelText;
    public string[] dialogue;
    private int index;

    public GameObject Button;
    public float speedText;
    public bool openPanel;

    void Start()
    {
        index = 0;
        PanelText.SetActive(true); // ketika masuk scene panel untuk memunculkan teks akan ditampilkan
        StartCoroutine(Typing()); // memanggil fungsi typing dan mulai mengetik
    }

    void Update()
    {
        if ((IsiText.text == dialogue[index]) && (Input.GetKeyDown(KeyCode.E)))
        {
            Button.SetActive(true);
            Next(); // sama seperti klik tombol UI
        }
    }

    public void ZeroText() // ketika selesai mengetik dan tidak ada text lagi panel akan ditutup
    {
        IsiText.text = "";
        index = 0;
        PanelText.SetActive(false);
    }

    IEnumerator Typing() // mulai mengetik
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            IsiText.text += letter; // teks terisi
            yield return new WaitForSeconds(speedText); // kecepatan teks
            yield return null; // meminimalisir delay
        }
        Button.SetActive(true); // ketika selesai mengetik tombol next akan muncul
    }

    public void Next() // menjalankan fungsi next untuk tombol dan juga hotkey
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
}
