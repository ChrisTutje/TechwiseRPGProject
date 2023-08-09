using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{

    public Transform playerTransform;

    void Start()
   {
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY"))
        {
            float playerX = PlayerPrefs.GetFloat("PlayerX");
            float playerY = PlayerPrefs.GetFloat("PlayerY");
            Vector2 savedPosition = new Vector3(playerX, playerY);
            playerTransform.position = savedPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
