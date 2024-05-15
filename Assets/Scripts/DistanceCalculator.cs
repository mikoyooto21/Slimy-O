using UnityEngine;
using TMPro;  // Додати цей namespace для доступу до TextMeshPro

public class DistanceCalculator : MonoBehaviour
{
    public TMP_Text distanceText; // Змініть тип з Text на TMP_Text
    public float speed = 3500f; // Швидкість руху персонажа (одиниць за секунду)

    private float totalDistance = 0f;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        totalDistance = (Time.time - startTime) * speed;
        distanceText.text = "Score: " + Mathf.Round(totalDistance).ToString(); // Округлення до цілого числа
    }
}
