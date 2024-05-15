using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeIMObstacle : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && transform.position.x - player.transform.position.x <= -10f)
        {
            Destroy(gameObject); // Видаляємо сам об'єкт DestroyMeIMObstacle
        }
    }
}
