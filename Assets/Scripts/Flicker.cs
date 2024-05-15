using UnityEngine;

public class Flicker : MonoBehaviour
{
    public float minAlpha = 0.5f;  // Мінімальна яскравість
    public float maxAlpha = 1.0f;  // Максимальна яскравість
    public float flickerSpeed = 5.0f;  // Швидкість зміни яскравості

    private SpriteRenderer spriteRenderer;
    private Color baseColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColor = spriteRenderer.color;
    }

    void Update()
    {
        float red = Mathf.Lerp(185f / 255f, 1f, 255); // Значення R від 185 до 255
        spriteRenderer.color = new Color(red, baseColor.g, baseColor.b, 255);
    }
}
