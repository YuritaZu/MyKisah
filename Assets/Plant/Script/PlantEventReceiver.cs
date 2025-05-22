using UnityEngine;

public class PlantEventReceiver : MonoBehaviour
{
    public string plantName; // misal: "Basil", "Bayam", dll

    public Sprite spriteNormal;
    public Sprite spriteSerangga;
    public Sprite spriteAirHabis;
    public Sprite spriteAirBusuk;
    public Sprite spriteLayu;

    public SpriteRenderer plantRenderer;

    public void ApplyEvent(string eventType)
    {
        Debug.Log($"[{plantName}] Event terjadi: {eventType}");

        switch (eventType)
        {
            case "Serangga":
                plantRenderer.sprite = spriteSerangga;
                break;
            case "AirHabis":
                plantRenderer.sprite = spriteAirHabis;
                break;
            case "AirBusuk":
                plantRenderer.sprite = spriteAirBusuk;
                break;
            case "Layu":
                plantRenderer.sprite = spriteLayu;
                break;
            default:
                plantRenderer.sprite = spriteNormal;
                break;
        }
    }

    public void ResetVisual()
    {
        if (plantRenderer != null && spriteNormal != null)
            plantRenderer.sprite = spriteNormal;
    }
}
