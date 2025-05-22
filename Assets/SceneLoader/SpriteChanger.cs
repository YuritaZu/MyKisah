using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Sprite basilSprite;
    public Sprite seladaSprite;
    private SpriteRenderer sr;
    private bool isBasil = true;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = basilSprite;
    }

    public void ToggleSprite()
    {
        if (isBasil)
        {
            sr.sprite = seladaSprite;
        }
        else
        {
            sr.sprite = basilSprite;
        }
        isBasil = !isBasil;
    }
}
