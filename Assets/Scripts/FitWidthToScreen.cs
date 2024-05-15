using UnityEngine;

public class FitWidthToScreen : MonoBehaviour
{
    void Start()
    {
        // Отримуємо ширину видимого поля камери в світових координатах
        float screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        // Отримуємо компонент Renderer для доступу до розмірів об'єкта
        Renderer rend = GetComponent<Renderer>();

        // Перевірка, чи Renderer не null
        if (rend != null)
        {
            // Знаходимо потрібний масштаб, щоб ширина об'єкта дорівнювала ширині видимого поля камери
            float scaleFactor = screenWidth / rend.bounds.size.x;
            
            // Застосовуємо отриманий масштаб до об'єкта
            transform.localScale = new Vector3(scaleFactor, 2, 1);
        }
    }
}
