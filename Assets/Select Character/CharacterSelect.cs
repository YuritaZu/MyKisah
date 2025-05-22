using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public string characterName;

    public void SelectCharacter()
    {
        PlayerPrefs.SetString("SelectedCharacter", characterName);
        SceneManager.LoadScene("Gameplay");
    }
}