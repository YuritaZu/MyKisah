using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public GameObject BasilPlant;
    public GameObject BayamPlant;
    public GameObject BawangPlant;
    public GameObject SeladaPlant;
    public GameObject SawiPlant;
    public GameObject PakcoyPlant;
    public GameObject SeledriPlant;

    void Start()
    {
        string selected = PlayerPrefs.GetString("SelectedCharacter", "");

        // Matikan semua dulu
        BasilPlant.SetActive(false);
        BayamPlant.SetActive(false);
        BawangPlant.SetActive(false);
        SeladaPlant.SetActive(false);
        SawiPlant.SetActive(false);
        PakcoyPlant.SetActive(false);
        SeledriPlant.SetActive(false);

        // Aktifkan yang dipilih
        switch (selected)
        {
            case "basil":
                BasilPlant.SetActive(true);
                break;
            case "bayam":
                BayamPlant.SetActive(true);
                break;
            case "bawang":
                BawangPlant.SetActive(true);
                break;
            case "selada":
                SeladaPlant.SetActive(true);
                break;
            case "sawi":
                SawiPlant.SetActive(true);
                break;
            case "pakcoy":
                PakcoyPlant.SetActive(true);
                break;
            case "seledri":
                SeledriPlant.SetActive(true);
                break;
        }
    }
}
