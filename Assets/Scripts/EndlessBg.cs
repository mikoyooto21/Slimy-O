using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBg : MonoBehaviour
{
    Camera cam; // Для зберігання посилання на компонент камери
    float hue = 0; // Початкове значення відтінку

    void Start()
    {
        cam = GetComponent<Camera>(); // Отримання компонента камери
        cam.clearFlags = CameraClearFlags.SolidColor; // Встановлення типу очищення камери як одноколірний
    }

    void Update()
    {
        hue += Time.deltaTime * 0.025f; // Збільшуємо значення відтінку залежно від часу
        if (hue > 1) hue -= 1; // Якщо hue перевищує 1, починаємо знову
        
        cam.backgroundColor = Color.HSVToRGB(hue, 1, 0.5f); // Встановлюємо колір фону за HSV
    }
}
